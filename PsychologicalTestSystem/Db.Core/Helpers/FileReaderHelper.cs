using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.Helpers
{
    public static class FileReaderHelper
    {
        public static void WriteStreamInFile(Stream stream, string filePath)
        {
            using (var fileStream = File.Create(filePath, (int)stream.Length))
            {
                var data = new byte[stream.Length];

                stream.Read(data, 0, data.Length);
                fileStream.Write(data, 0, data.Length);
            }
        }

        public static Stream ReadStreamFromFile(string filePath)
        {
            using (var fileStream = File.Open(filePath, FileMode.Open))
            {
                var data = new byte[fileStream.Length];

                fileStream.Read(data, 0, data.Length);

                var ms = new MemoryStream();

                ms.Write(data, 0, data.Length);

                ms.Position = 0;

                return ms;
            }
        }

        public static void WriteInFileWithSerialize<T>(T item, string filePath)
        {
            var fs = XmlSerializerHelper.Serialize<T>(item);

            if (File.Exists(filePath) == true)
            {
                File.Delete(filePath);
            }

            using (var fi = File.Create(filePath)) { }

            WriteStreamInFile(fs, filePath);
        }

        public static T ReadFromFileWithDeserialize<T>(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException(string.Format("Not Found file [{0}]", filePath));
            }

            var fs = ReadStreamFromFile(filePath);

            return XmlSerializerHelper.Deserialize<T>(fs);
        }
    }
}
