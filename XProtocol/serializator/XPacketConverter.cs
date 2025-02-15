using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace XProtocol.Serializator
{
    public class XPacketConverter
    {
        public static XPacket Serialize(XPacketType type, object obj, bool strict = false)
        {
            // Если объект является строкой, обрабатываем его отдельно.
            if (obj is string s)
            {
                var typeTuple = XPacketTypeManager.GetType(type);
                var packet = XPacket.Create(typeTuple.Item1, typeTuple.Item2);
                // Преобразуем строку в байты UTF8
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
                // Записываем байты в поле с ID = 1
                packet.SetValueRaw(1, bytes);
                return packet;
            }

            // Для остальных типов используется существующая логика...
            var fields = GetFields(obj.GetType());
            var xpacket = XPacket.Create(
                XPacketTypeManager.GetType(type).Item1,
                XPacketTypeManager.GetType(type).Item2);

            foreach (var tuple in fields)
            {
                var field = tuple.Item1;
                var fieldId = tuple.Item2;
                var value = field.GetValue(obj);

                // Если значение равно null, можно либо пропустить поле, либо присвоить default
                if (value == null)
                {
                    if (strict)
                        throw new Exception($"Значение поля '{field.Name}' равно null.");
                    else
                        continue; // пропускаем это поле
                }

                var bytes = FixedObjectToByteArray(value);
                if (bytes.Length > ushort.MaxValue)
                    throw new Exception("Object is too big. Max length is 65535 bytes.");
                xpacket.SetValueRaw(fieldId, bytes);
            }

            return xpacket;
        }




        public static XPacket Serialize(byte type, byte subtype, object obj, bool strict = false)
        {
            var fields = GetFields(obj.GetType());

            if (strict)
            {
                var usedUp = new List<byte>();

                foreach (var field in fields)
                {
                    if (usedUp.Contains(field.Item2))
                    {
                        throw new Exception("One field used two times.");
                    }

                    usedUp.Add(field.Item2);
                }
            }

            var packet = XPacket.Create(type, subtype);

            foreach (var field in fields)
            {
                packet.SetValue(field.Item2, field.Item1.GetValue(obj));
            }

            return packet;
        }

        public static T Deserialize<T>(XPacket packet, bool strict = false)
        {
            // Если тип T - string, сразу возвращаем содержимое поля с ID = 1
            if (typeof(T) == typeof(string))
            {
                // Если поле с ID = 1 отсутствует, возвращаем пустую строку
                if (!packet.HasField(1))
                    return (T)(object)string.Empty;
                string s = packet.GetValue<string>(1);
                return (T)(object)s;
            }

            // Для остальных типов – стандартная логика
            var fields = GetFields(typeof(T));

            T instance;
            if (fields.Count == 0)
            {
                instance = Activator.CreateInstance<T>();
                return instance;
            }
            else
            {
                instance = Activator.CreateInstance<T>();
            }

            foreach (var tuple in fields)
            {
                var field = tuple.Item1;
                var packetFieldId = tuple.Item2;

                if (!packet.HasField(packetFieldId))
                {
                    if (strict)
                        throw new Exception($"Couldn't get field[{packetFieldId}] for {field.Name}");
                    continue;
                }

                var method = typeof(XPacket).GetMethod("GetValue")?.MakeGenericMethod(field.FieldType);
                if (method == null)
                {
                    if (strict)
                        throw new Exception($"Couldn't create generic method for field {field.Name}");
                    continue;
                }
                var value = method.Invoke(packet, new object[] { packetFieldId });
                if (value == null)
                {
                    if (strict)
                        throw new Exception($"Couldn't get value for field[{packetFieldId}] for {field.Name}");
                    continue;
                }
                field.SetValue(instance, value);
            }

            return instance;
        }



        private static List<Tuple<FieldInfo, byte>> GetFields(Type t)
        {
            return t.GetFields(BindingFlags.Instance |
                                     BindingFlags.NonPublic |
                                     BindingFlags.Public)
                .Where(field => field.GetCustomAttribute<XFieldAttribute>() != null)
                .Select(field => Tuple.Create(field, field.GetCustomAttribute<XFieldAttribute>().FieldID))
                .ToList();
        }

        public static byte[] FixedObjectToByteArray(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            // Если значение является строкой, используем UTF8
            if (value is string str)
            {
                return Encoding.UTF8.GetBytes(str);
            }

            int size = Marshal.SizeOf(value);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(value, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return arr;
        }
    }
}
