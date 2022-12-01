using MVVM.Repositories.Abstracts;
using MVVM.Repositories.Concretes;
using MVVM.Views;
using MVVM.ViewModels;
using System.Windows;

namespace MVVM;

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
