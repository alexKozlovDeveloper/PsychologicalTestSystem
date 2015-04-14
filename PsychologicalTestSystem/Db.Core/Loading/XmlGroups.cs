using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.TableEntityes;

namespace Db.Core.Loading
{
    public class XmlGroups
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

        public List<XmlGroup> GroupsWithUsers { get; set; }

        public XmlGroups()
        {
            GroupsWithUsers = new List<XmlGroup>();
        }
    }
}
