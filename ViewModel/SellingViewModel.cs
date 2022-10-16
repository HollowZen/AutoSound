using AutoSound.Infrastructure.Command.Base;
using AutoSound.Model.ModelDb;
using AutoSound.ViewModel.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AutoSound.Model;

namespace AutoSound.ViewModel;

public class SellingViewModel:ViewModelBase
{

    public SellingViewModel()
    {
        Stocks = DataWorker.GetStock();
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
            if (_relayCommand == null)
            {
                _relayCommand = new RelayCommand(p =>
                {
                    DataWorker.Selling(Stocks);
                    Stocks = DataWorker.GetStock();
                }, p => true);
            }

            return _relayCommand;
        }
    }

}