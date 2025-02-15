using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace XProtocol
{
    public class XPacket
    {
        public byte PacketType { get; private set; }
        public byte PacketSubtype { get; private set; }
        public List<XPacketField> Fields { get; set; } = new List<XPacketField>();
        public bool Protected { get; set; }
        private bool ChangeHeaders { get; set; }

        private XPacket() { }

        public XPacketField GetField(byte id)
        {
            foreach (var field in Fields)
            {
                if (field.FieldID == id)
                    return field;
            }
            return null;
        }

        public bool HasField(byte id)
        {
            return GetField(id) != null;
        }

        private T ByteArrayToFixedObject<T>(byte[] bytes)
        {
            T structure;
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                structure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
            return structure;
        }

        public byte[] FixedObjectToByteArray(object value)
        {
            if (value is string s)
            {
                return System.Text.Encoding.UTF8.GetBytes(s);
            }
            int rawSize = Marshal.SizeOf(value);
            byte[] rawData = new byte[rawSize];
            var handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            try
            {
                Marshal.StructureToPtr(value, handle.AddrOfPinnedObject(), false);
            }
            finally
            {
                handle.Free();
            }
            return rawData;
        }

        public T GetValue<T>(byte id)
        {
            var field = GetField(id);
            if (field == null)
            {
                throw new Exception($"Field with ID {id} wasn't found.");
            }

            if (typeof(T) == typeof(string))
            {
                string s = System.Text.Encoding.UTF8.GetString(field.Contents);
                s = s.Trim('\0'); // удаляем завершающие нулевые символы
                return (T)(object)s;
            }

            if (!typeof(T).IsValueType)
            {
                throw new Exception($"Тип {typeof(T)} не поддерживается. Поддерживаются только значимые типы и string.");
            }

            int neededSize = Marshal.SizeOf(typeof(T));
            if (field.FieldSize != neededSize)
            {
                throw new Exception($"Невозможно преобразовать поле в тип {typeof(T).FullName}. Получено {field.FieldSize} байт, а требуется {neededSize}.");
            }

            return ByteArrayToFixedObject<T>(field.Contents);
        }

        public void SetValue(byte id, object structure)
        {
            // Если передан строковый тип, обрабатываем его отдельно
            if (structure is string str)
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(str);
                // Здесь замените byte.MaxValue на ushort.MaxValue
                if (bytes.Length > ushort.MaxValue)
                {
                    throw new Exception("Object is too big. Max length is 65535 bytes.");
                }

                var field = GetField(id);
                if (field == null)
                {
                    field = new XPacketField { FieldID = id };
                    Fields.Add(field);
                }

                field.FieldSize = (ushort)bytes.Length;
                field.Contents = bytes;
                return;
            }

            // Для остальных типов (value types)
            if (!structure.GetType().IsValueType)
            {
                throw new Exception("Only value types are available.");
            }

            var fieldExisting = GetField(id);
            if (fieldExisting == null)
            {
                fieldExisting = new XPacketField { FieldID = id };
                Fields.Add(fieldExisting);
            }

            var bytesValue = FixedObjectToByteArray(structure);

            if (bytesValue.Length > ushort.MaxValue)
            {
                throw new Exception("Object is too big. Max length is 65535 bytes.");
            }

            fieldExisting.FieldSize = (ushort)bytesValue.Length;
            fieldExisting.Contents = bytesValue;
        }


        public byte[] GetValueRaw(byte id)
        {
            var field = GetField(id);
            if (field == null)
                throw new Exception($"Field with ID {id} wasn't found.");
            return field.Contents;
        }

        public void SetValueRaw(byte id, byte[] rawData)
        {
            var field = GetField(id);
            if (field == null)
            {
                field = new XPacketField { FieldID = id };
                Fields.Add(field);
            }

            if (rawData.Length > ushort.MaxValue)
            {
                throw new Exception("Object is too big. Max length is 65535 bytes.");
            }

            field.FieldSize = (ushort)rawData.Length;
            field.Contents = rawData;
            Console.WriteLine($"[SERIALIZE] SetValueRaw: FieldID={id}, Size={field.FieldSize}");
        }


        public static XPacket Create(XPacketType type)
        {
            var t = XPacketTypeManager.GetType(type);
            return Create(t.Item1, t.Item2);
        }

        public static XPacket Create(byte type, byte subtype)
        {
            return new XPacket
            {
                PacketType = type,
                PacketSubtype = subtype
            };
        }

        public byte[] ToPacket()
        {
            var packet = new MemoryStream();
            // Записываем заголовок (5 байт)
            byte[] header = ChangeHeaders
                ? new byte[] { 0x95, 0xAA, 0xFF, PacketType, PacketSubtype }
                : new byte[] { 0xAF, 0xAA, 0xAF, PacketType, PacketSubtype };
            packet.Write(header, 0, header.Length);

            // Сортируем поля по ID
            var fieldsOrdered = Fields.OrderBy(field => field.FieldID);
            foreach (var field in fieldsOrdered)
            {
                // Записываем FieldID (1 байт)
                packet.WriteByte(field.FieldID);
                // Записываем FieldSize (2 байта)
                byte[] sizeBytes = BitConverter.GetBytes(field.FieldSize);
                packet.Write(sizeBytes, 0, sizeBytes.Length);
                // Записываем содержимое поля
                packet.Write(field.Contents, 0, field.Contents.Length);
            }

            // Записываем завершающие байты (2 байта)
            packet.Write(new byte[] { 0xFF, 0x00 }, 0, 2);
            return packet.ToArray();
        }

        public static XPacket Parse(byte[] packetData, bool markAsEncrypted = false)
        {
            // Минимальный размер пакета – 7 байт
            if (packetData.Length < 7)
                return null;

            bool encrypted = false;
            if (packetData[0] != 0xAF || packetData[1] != 0xAA || packetData[2] != 0xAF)
            {
                if (packetData[0] == 0x95 || packetData[1] == 0xAA || packetData[2] == 0xFF)
                    encrypted = true;
                else
                    return null;
            }

            int mIndex = packetData.Length - 1;
            if (packetData[mIndex - 1] != 0xFF || packetData[mIndex] != 0x00)
                return null;

            byte type = packetData[3];
            byte subtype = packetData[4];
            var xpacket = new XPacket { PacketType = type, PacketSubtype = subtype, Protected = markAsEncrypted };

            int index = 5;
            while (index < packetData.Length - 2) // до последних 2 байт окончания пакета
            {
                byte fieldId = packetData[index];
                index++;
                // Считываем 2 байта для размера
                if (index + 1 >= packetData.Length)
                    break;
                ushort fieldSize = BitConverter.ToUInt16(packetData, index);
                index += 2;

                byte[] contents = new byte[fieldSize];
                Array.Copy(packetData, index, contents, 0, fieldSize);
                index += fieldSize;

                xpacket.Fields.Add(new XPacketField
                {
                    FieldID = fieldId,
                    FieldSize = fieldSize,
                    Contents = contents
                });
            }
            return encrypted ? DecryptPacket(xpacket) : xpacket;
        }


        public static XPacket EncryptPacket(XPacket packet)
        {
            if (packet == null)
                return null;
            var rawBytes = packet.ToPacket();
            var encrypted = XProtocolEncryptor.Encrypt(rawBytes);
            var p = Create(0, 0);
            p.SetValueRaw(0, encrypted);
            p.ChangeHeaders = true;
            return p;
        }

        public XPacket Encrypt()
        {
            return EncryptPacket(this);
        }

        public XPacket Decrypt()
        {
            return DecryptPacket(this);
        }

        private static XPacket DecryptPacket(XPacket packet)
        {
            if (!packet.HasField(0))
                return null;
            var rawData = packet.GetValueRaw(0);
            var decrypted = XProtocolEncryptor.Decrypt(rawData);
            return Parse(decrypted, true);
        }
    }
}
