using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Core.TableEntityes;

namespace DesktopClient.Conf
{
    static class AppConfig
    {
        public static User CurrentUser { get; set; }
        public static Test SelectedTest { get; set; }
        public static PassingTest CurrentPassingTest { get; set; }
    }
}
