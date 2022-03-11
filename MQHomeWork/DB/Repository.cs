using System.Net;

namespace MQHomeWork.DB
{
    public class Repository
    {
        private Database _database;
        uint _minip;
        uint _maxip;
        string _mincity;
        string _maxcity;
        public Repository(Database Database)
        {
            _database = Database;
            _minip = _database.Ranges[0].IPFrom;
            _maxip = _database.Ranges[_database.Header.Records - 1].IPTo;
            _mincity = _database.Locations[(int)_database.Indices[0].Value].City;
            _maxcity = _database.Locations[(int)_database.Indices[_database.Header.Records - 1].Value].City;
        }


        /// <summary>
        /// Осуществляет поиск локации по ip-адресу
        /// </summary>
        /// <param name="IPaddress">IP-адрес</param>
        /// <returns>Локация</returns>
        public Location? GetLocation(IPAddress IPaddress)
        {
            byte[] ipbytes = IPaddress.GetAddressBytes();
            if(BitConverter.IsLittleEndian) //если байты адреса попали в массив в обратном порядке, его следует развернуть
            {
                Array.Reverse(ipbytes);
            }
            uint ip = BitConverter.ToUInt32(ipbytes, 0);
            if(ip < _minip || ip > _maxip)
            {
                return null;
            }
            Range? index = BinaryIPSearch(ip);

            if(index != null)
            {
                return _database.Locations[(int)index.LocationIndex];
            }
            return null;
        }
        public IEnumerable<Location> GetLocations(string City)
        {
            if(City == null || string.Compare(City, _mincity) < 0 || string.Compare(City, _maxcity) > 0)
            {
                return Enumerable.Empty<Location>();
            }
            return BinaryCitySearch(City);
        }

        /// <summary>
        /// Обыкновенный бинарный поиск по отсортированному массиву IP-адресов
        /// </summary>
        /// <param name="ip">IP адрес для поиска в массиве IP-адресов</param>
        /// <returns>Возвращает элемент Range базы данных GeoBase</returns>
        private Range? BinaryIPSearch(uint ip)
        {
            int left = 0;
            int right = _database.Header.Records - 1;
            while(left <= right)
            {
                int avg = (left + right) / 2;
                Range avgItem = _database.Ranges[avg];
                if (ip < avgItem.IPFrom)
                {
                    right = avg - 1;
                }
                else if(ip > avgItem.IPTo)
                {
                    left = avg + 1;
                }
                else if(avgItem.IPFrom <= ip && ip <= avgItem.IPTo)
                {
                    return avgItem;
                }
            }
            return null;
        }

        ///TODO: Возможно, лучше подошло бы сопоставление по хэш-таблицам.
        /// <summary>
        /// Бинарный поиск в базе GeoBase. 
        /// </summary>
        /// <param name="city">Город</param>
        /// <returns>Перечисление местоположений</returns>
        private IEnumerable<Location> BinaryCitySearch(string city)
        {
            int left = 0;
            int right = _database.Header.Records - 1;
            while (left <= right)
            {
                int avg = (left + right) / 2;
                Index avgIndex = _database.Indices[avg];
                Location avgItem = _database.Locations[(int)avgIndex.Value];
                int comparison = string.Compare(city, avgItem.City);
                if (comparison < 0) // следует искать в той части, что расположена до середины диапазона
                {
                    right = avg - 1;
                }
                else if(comparison > 0) // следует искать в той части, что расположена после середины диапазона
                {
                    left = avg + 1;
                }
                else if( comparison == 0) // найдено совпадение, необходимо проверить, не соответствуют ли соседние записи тому же городу
                {
                    yield return avgItem;
                    
                    for(int i = avg; i > left; i--) // поиск слева от найденного индекса
                    {
                        Index nextIndex = _database.Indices[i];
                        Location nextLocation = _database.Locations[(int)nextIndex.Value];
                        if (nextLocation.City.Equals(city))
                        {
                            yield return nextLocation;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = avg; i < right; i++) // поиск справа от найденного индекса
                    {
                        Index nextIndex = _database.Indices[i];
                        Location nextLocation = _database.Locations[(int)nextIndex.Value];
                        if (nextLocation.City.Equals(city))
                        {
                            yield return nextLocation;
                        }
                        else
                        {
                            break;
                        }
                    }
                    yield break;
                }
            }
        }
    }
}
