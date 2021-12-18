using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Da_projekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SplashScreen ss;

        App()
        {
            ss = new SplashScreen("splash_screen.jpg");
            ss.Show(true);
        }
    }
}
