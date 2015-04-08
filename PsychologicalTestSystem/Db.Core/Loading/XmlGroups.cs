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
        public class XmlUsers
        {
            public Group GroupInfo { get; set; }
            public List<User> Users { get; set; }

            public XmlUsers()
            {
                Users = new List<User>();
            }
        }

        public List<XmlUsers> GroupsWithUsers { get; set; }

        public XmlGroups()
        {
            GroupsWithUsers = new List<XmlUsers>();
        }
    }
}
