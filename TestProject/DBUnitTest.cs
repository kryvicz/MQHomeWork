using Xunit;
using MQHomeWork.DB;
using System.Diagnostics;
using System;
using Xunit.Abstractions;
using System.Linq;

namespace TestProject
{
    public class DBUnitTest
    {
        string _filePath = "geobase.dat";
        byte[] _data;
        Database _db;
        TimeSpan _fileLoadTime;
        TimeSpan _fileParseTime;
        ITestOutputHelper _testOutput;
        Repository _repository;
        public DBUnitTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;

            Stopwatch sw = Stopwatch.StartNew();
            _data = new FileLoader(_filePath).Load();
            sw.Stop();
            _fileLoadTime = sw.Elapsed;
            sw.Restart();
            _db = new Parser(_data).Parse();
            sw.Stop();
            _fileParseTime = sw.Elapsed;

            _repository = new Repository(_db);
            
        }

        [Fact]
        public void Print_Load_Speed()
        {
            Assert.True(_fileLoadTime < TimeSpan.FromMilliseconds(30));
            _testOutput.WriteLine($"File loaded for {_fileLoadTime.TotalMilliseconds} ms");
        }

        [Fact]
        public void Print_Parse_Speed()
        {
            _testOutput.WriteLine($"File parsed for {_fileParseTime.TotalMilliseconds} ms");
        }

        [Fact]
        public void File_Loaded()
        {
            Assert.IsType<byte[]>(_data);
            Assert.True(_data.Length > 0);
        }

        [Fact]
        public void Database_Parsed_Correcty()
        {
            Assert.True(_db.Header is not null);
            Assert.True(_db.Ranges.Count() == _db.Header.Records);
            Assert.True(_db.Locations.Count() == _db.Header.Records);
            Assert.True(_db.Indices.Count() == _db.Header.Records);
        }

        [Fact]
        public void Database_Contains_cit_I_192_Times()
        {
            var data = _repository.GetLocations("cit_I");
            Assert.True(data.Count() == 192);
        }
        [Fact]
        public void Database_Does_Not_Contain_Garbage()
        {
            var data = _repository.GetLocations("cit_I sdf adf ");
            Assert.False(data.Count() > 0);
        }
        [Fact]
        public void Database_Contains_Correct_IP()
        {
            var data = _repository.GetLocation(System.Net.IPAddress.Parse("1.1.1.1"));
            Assert.True(data.City == "cit_Ykojof");
        }
    }
}