namespace MQHomeWork.DB
{
    public record Range : IDbItem
    {
        public uint IPFrom { get; set; }
        public uint IPTo { get; set; }
        public uint LocationIndex { get; set; }
    }
}
