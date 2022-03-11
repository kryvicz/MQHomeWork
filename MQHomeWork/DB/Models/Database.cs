namespace MQHomeWork.DB
{
    public record Database
    {
        public Header? Header { get; init; }
        // IReadOnlyList работает быстрее простого массива
        public IReadOnlyList<Range> Ranges { get; init; }
        public IReadOnlyList<Location> Locations { get; init; }
        public IReadOnlyList<Index> Indices { get; init; }
    }
}
