﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Core.TableEntityes
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
