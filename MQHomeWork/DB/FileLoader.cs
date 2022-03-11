namespace MQHomeWork.DB
{

    /// <summary>
    /// Получение содержимого GeoBase из указанного файла
    /// </summary>
    public class FileLoader : ILoader
    {
        string _filePath;
        public FileLoader(string FilePath)
        {
            _filePath  = FilePath;
        }

        /// <summary>
        /// Чтение файла
        /// </summary>
        /// <returns>Массив byte базы GeoBase</returns>
        /// <exception cref="ArgumentNullException">Необходимо передать путь к файлу</exception>
        /// <exception cref="FileNotFoundException">Файл не найден</exception>
        public byte[] Load()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                throw new ArgumentNullException(nameof(_filePath));
            }
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"File {_filePath} is not found");
            }
            return File.ReadAllBytes(_filePath);
        }
    }

}
