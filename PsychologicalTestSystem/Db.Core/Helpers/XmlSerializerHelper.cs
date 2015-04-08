using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Db.Core.Helpers
{
    public static class XmlSerializerHelper
    {
        public static Stream Serialize<T>(T obj)
        {
            var s = new XmlSerializer(typeof(T));

            var ms = new MemoryStream();

            s.Serialize(ms, obj);

            ms.Position = 0;

            return ms;
        }

        public static T Deserialize<T>(Stream ms)
        {
            var s = new XmlSerializer(typeof(T));

            var res = s.Deserialize(ms);

            return (T)res;
        }

        public static T Deserialize<T>(string xml)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(xml);
            writer.Flush();
            stream.Position = 0;

            var s = new XmlSerializer(typeof(T));

            var res = s.Deserialize(stream);

            return (T)res;
        }
    }
}
