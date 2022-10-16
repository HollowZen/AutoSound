using System.Dynamic;
using AutoSound.ViewModel.Base;

namespace AutoSound.ViewModel;

public class MainViewModel:ViewModelBase
{
    private object _navigations;

    public object Navigations
    {
        get => _navigations;
        set => Set(ref _navigations, value);
    }

    private int _idUser;

    public int IdUser
    {
        get => _idUser;
        set => Set(ref _idUser, value);
    }

    public static MainViewModel Root;

    public MainViewModel()
    {
        Navigations = new LoginViewModel();
        Root = this;
    }

}