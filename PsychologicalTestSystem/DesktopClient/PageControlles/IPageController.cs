﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DesktopClient.PageControlles
{
    interface IPageController
    {
        //Page ControllerPage { get; }
        Window ControllerWindow { get; }

        void SetupToWindow();
    }
}
