namespace MQHomeWork.DB
{
    public record Location : IDbItem
    {
        public string? Country { get; init; }        // название страны (случайная строка с префиксом "cou_")
        public string? Region { get; init; }        // название области (случайная строка с префиксом "reg_")
        public string? Postal { get; init; }        // почтовый индекс (случайная строка с префиксом "pos_")
        public string? City { get; init; }         // название города (случайная строка с префиксом "cit_")
        public string? Organization { get; init; }  // название организации (случайная строка с префиксом "org_")
        public float Latitude { get; init; }          // широта
        public float Longitude { get; init; }         // долгота
    }
}
