namespace MQHomeWork.DB
{
    /// <summary>
    /// Реализация парсера GeoBase
    /// </summary>
    public class Parser : IParser
    {
        private readonly byte[] _data; 
        private Header _header;
        private IReadOnlyList<Range> _ranges;
        private IReadOnlyList<Location> _locations;
        private IReadOnlyList<Index> _indices;
        private const int COUNTRY_LENGTH = 8;
        private const int REGION_LENGTH = 12;
        private const int POSTAL_LENGTH = 12;
        private const int CITY_LENGTH = 24;
        private const int ORGANIZATION_LENGTH = 32;
        private const int DBNAME_LENGTH = 32;
        private const int LOCATION_SIZE = 96;
        public Parser(byte[] Data)
        {
            _data = Data;
        }
        public Database Parse()
        {
            /// Разбор заголовка
            _header = ParseHeader();

            /// Вызов метода Parse для разбора набора Range в файле. 3-й параметр - функция выделения отдельного Range
            _ranges = Parse<Range>(_header.OffsetRanges, _header.Records, (reader) =>
                new Range
                {
                    IPFrom = reader.ReadUInt32(),
                    IPTo = reader.ReadUInt32(),
                    LocationIndex = reader.ReadUInt32()
                });

            /// Вызов метода Parse для разбора набора Location в файле. 3-й параметр - функция выделения отдельного Location
            _locations = Parse<Location>(_header.OffsetLocations, _header.Records, (reader) =>
                new Location
                {
                    Country = reader.ReadCharString(COUNTRY_LENGTH),
                    Region = reader.ReadCharString(REGION_LENGTH),
                    Postal = reader.ReadCharString(POSTAL_LENGTH),
                    City = reader.ReadCharString(CITY_LENGTH),
                    Organization = reader.ReadCharString(ORGANIZATION_LENGTH),
                    Latitude = reader.ReadSingle(),
                    Longitude = reader.ReadSingle()
                });
            var aa = _locations.GroupBy(l => l.City).OrderByDescending(g => g.Count()).Take(1000).Select(g => g.Key).ToList();
            
            /// Вызов метода Parse для разбора набора Index в файле. 3-й параметр - функция выделения отдельного Index. 
            /// Так как в индексе указано смещение, то порядковый номер можно вычислить, разделив на размер одной записи
            _indices = Parse<Index>(_header.OffsetCities, _header.Records, (reader) =>
            {
                var s = reader.ReadUInt32();
                return new Index
                {
                    Value = s / LOCATION_SIZE 
                };
            });

            /// Сборка Database и возврат
            return new Database
            {
                Header = _header,
                Ranges = _ranges,
                Locations = _locations,
                Indices = _indices
            };
        }        

        /// <summary>
        /// Метод, разбирающий заголовок файла базы данных
        /// </summary>
        private Header ParseHeader()
        {
            using MemoryStream stream = new(_data);
            using BinaryReader reader = new(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return new Header
            {
                Version = reader.ReadInt32(),
                Name = reader.ReadCharString(DBNAME_LENGTH),
                Timestamp = reader.ReadUInt64(),
                Records = reader.ReadInt32(),
                OffsetRanges = reader.ReadUInt32(),
                OffsetCities = reader.ReadUInt32(),
                OffsetLocations = reader.ReadUInt32(),
            };
        }
        /// <summary>
        /// Метод, разбирающий основное содержимое файла базы данных
        /// </summary>
        /// <typeparam name="T">Тип извлекаемых данных, реализует интерфейс IDbItem</typeparam>
        /// <param name="Offset">Смещение в файле</param>
        /// <param name="Cnt">Количество записей</param>
        /// <param name="Extractor">Метод, извлекающий отдельную запись</param>
        /// <returns>Возвращает массив извлеченных данных</returns>
        private IReadOnlyList<T> Parse<T>(uint Offset, int Cnt, Func<BinaryReader, IDbItem> Extractor) where T : IDbItem
        {
            using MemoryStream stream = new(_data);
            using BinaryReader reader = new(stream);    // открыть бинарный поток на чтение
            stream.Seek(Offset, SeekOrigin.Begin);      // сдвинуть указать на начало области чтения
            var items = new T[Cnt];
            for (int i = 0; i < Cnt; i++)
            {
                items[i] = (T)Extractor(reader);        // конкретный Extractor будет передан в метод при вызове
            }
            return items;
        }
    }
}
