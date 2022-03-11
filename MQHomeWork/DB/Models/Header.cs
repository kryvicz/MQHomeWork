namespace MQHomeWork.DB
{
    /// <summary>
    /// Заголовки файла GeoBase
    /// </summary>
    public record Header
    {
        public int Version { get; init; }
        public string Name { get; init; }
        public ulong Timestamp { get; init; }
        public int Records { get; init; }
        public uint OffsetRanges { get; init; }
        public uint OffsetCities { get; init; }
        public uint OffsetLocations { get; init; }

    }
}
