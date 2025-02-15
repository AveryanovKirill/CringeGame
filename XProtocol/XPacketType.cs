namespace XProtocol
{
    public enum XPacketType
    {
        Unknown,
        Handshake,
        GameUpdate,    // новый тип для состояния игры
        PlayerAction
    }
}
