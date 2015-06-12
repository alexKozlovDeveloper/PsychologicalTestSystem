using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.Helpers
{
    public class StringHelper
    {
        public const int DefaultStringLenght = 15;

        public static string GetShortString(string str, int size = DefaultStringLenght)
        {
            if (str.Length < size)
            {
                return str;
            }

            var res = "";

            for (var i = 0; i < size; i++)
            {
                res += str[i];
            }

            res += "...";

            return res;
        }
    }
}
