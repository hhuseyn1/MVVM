using MVVM.Models;
using MVVM.Commands;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVM.ViewModels;

public class EditViewModel
{
    public Car SelectedCar { get; set; }

    public ICommand AcceptCommand { get; set; }
    public ICommand CancelCommand { get; set; }


    public EditViewModel(Car selectedCar)
    {
        SelectedCar = selectedCar;

        AcceptCommand = new RelayCommand(ExecuteAcceptCommand, CanExecuteAcceptCommand);
        CancelCommand = new RelayCommand(ExecuteCancelCommand);
    }

    void ExecuteAcceptCommand(object? parametr)
    {
        if (parametr is Window window && window.Content is StackPanel stackPanel)
        {
            foreach (var txt in stackPanel.Children.OfType<TextBox>())
            {
                BindingExpression be = txt.GetBindingExpression(TextBox.TextProperty);
                be.UpdateSource();
            }

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
