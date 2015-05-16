using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.TableEntityes;
using System.Xml.Serialization;

namespace Db.Core.Loading
{
    public class XmlGroup
    {
        public Group GroupInfo { get; set; }
        public List<User> Users { get; set; }

        public XmlGroup()
        {
            Users = new List<User>();
        }
    }
}
