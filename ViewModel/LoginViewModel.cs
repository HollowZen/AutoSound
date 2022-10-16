using System.Windows;
using System.Windows.Input;
using AutoSound.Infrastructure.Command.Base;
using AutoSound.Model;
using AutoSound.View.Pages.Employee;
using AutoSound.ViewModel.Base;

namespace AutoSound.ViewModel;

public class LoginViewModel:ViewModelBase
{
    private string _login;

    public string Login { get => _login; set => Set(ref _login, value); }

    private string _password;
    public string Password { get => _password; set => Set(ref _password, value); }

    private RelayCommand? _verification = null;

    public ICommand Verification
    {
        get
        {
            if (_verification == null)
            {
                _verification = new RelayCommand(
                    param =>
                    {
                        var temp = DataWorker.LoginVerification(Login, Password);
                        if (temp != 0)
                        {
                            MainViewModel.Root.IdUser = temp;
                            MainViewModel.Root.Navigations = new ProductViewModel();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль","Ошибка",MessageBoxButton.OK);
                            Login = "";
                            Password = "";
                        }
                        
                    }, param => true);
            }

            return _verification;
        }
    }
}