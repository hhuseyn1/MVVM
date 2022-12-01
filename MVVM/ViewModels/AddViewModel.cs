using MVVM.Models;
using MVVM.Commands;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM.ViewModels;

public class AddViewModel
{
    public Car NewCar { get; set; } = new();

    public bool MyDialogResult { get; set; }

    public ICommand AcceptCommand { get; set; }
    public ICommand CancelCommand { get; set; }


    public AddViewModel()
    {
        AcceptCommand = new RelayCommand(ExecuteAcceptCommand, CanExecuteAcceptCommand);
        CancelCommand = new RelayCommand(ExecuteCancelCommand);
    }

    void ExecuteAcceptCommand(object? parametr)
    {
        if (parametr is Window window)
        {
            MyDialogResult = true;
            window.DialogResult = true;
        }
    }

    bool CanExecuteAcceptCommand(object? parametr)
    {

        if (parametr is Window window && window.Content is StackPanel stackPanel)
        {
            foreach (var txt in stackPanel.Children.OfType<TextBox>())
                if (txt.Text.Length < 2)
                    return false;

            return true;
        }

        return false;
    }

    void ExecuteCancelCommand(object? parametr)
    {
        if (parametr is Window window)
            window.DialogResult = false;
    }

}
