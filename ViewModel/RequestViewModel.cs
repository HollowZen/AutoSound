using System.Collections.Generic;
using System.Windows.Input;
using AutoSound.Infrastructure.Command.Base;
using AutoSound.Model;
using AutoSound.Model.ModelDb;
using AutoSound.ViewModel.Base;

namespace AutoSound.ViewModel;

public class RequestViewModel:ViewModelBase
{
    private List<Stock> _stocks = new List<Stock>();

    public List<Stock> Stocks
    {
        get => _stocks;
        set => Set(ref _stocks, value);
    }

    private RelayCommand _setRequest;

    public ICommand SetRequest
    {
        get
        {
            if (_setRequest == null)
            {
                _setRequest = new RelayCommand(param =>
                {
                    DataWorker.SetRequest(Stocks);
                    Stocks.Clear();
                }, param => true);
            }
            return _setRequest;
        }
    }
}