using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ICarRepository carRepository = new FakeCarRepository();
            MainViewModel mainViewModel = new(carRepository);

            MainView mainView = new();
            mainView.DataContext = mainViewModel;

            mainView.Show();

        }
    }
}
