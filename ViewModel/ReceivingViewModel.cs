using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AutoSound.Infrastructure.Command.Base;
using AutoSound.Model;
using AutoSound.Model.ModelDb;
using AutoSound.ViewModel.Base;

namespace AutoSound.ViewModel;

public class ReceivingViewModel:ViewModelBase
{
    public ReceivingViewModel()
    {
        Stocks = DataWorker.GetReceiving();
    }

    private List<Stock> _stocks = new List<Stock>();
    public List<Stock> Stocks
    {
        get => _stocks;
        set => Set(ref _stocks, value);
    }

    RelayCommand _relayCommand;

    public ICommand Command
    {
        get
        {
            if (_relayCommand==null)
            {
                _relayCommand = new RelayCommand(p =>
                {
                    DataWorker.SetReceiving(Stocks);
                    Stocks = DataWorker.GetReceiving();
                }, p => true);
            }

            return _relayCommand;
        }
    }
}