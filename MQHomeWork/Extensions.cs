namespace MQHomeWork
{
    /// <summary>
    /// Чтение из потока BinaryReader строки заданной длины с избавлением от лишних символов
    /// </summary>
    public static class Extensions
    {
        public static string ReadCharString(this BinaryReader Reader, int CharsCount) => new string(Reader.ReadChars(CharsCount)).TrimEnd('\0', ' ');
    }
}
