using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using AutoSound.Infrastructure.Command.Base;
using AutoSound.Model;
using AutoSound.Model.ModelDb;
using AutoSound.ViewModel.Base;

namespace AutoSound.ViewModel;

public class StockViewModel:ViewModelBase
{
    public StockViewModel()
    {
        _stocks = new List<Stock>(DataWorker.GetStock());
    }
    private List<Stock> _stocks;
    public List<Stock> Stocks
    {
        get => _stocks;
        set => Set(ref _stocks, value);
    }

    private RelayCommand _editCommand;

    public ICommand EditCommand
    {
        get
        {
            if (_editCommand == null)
            {
                _editCommand = new RelayCommand(param =>
                {
                    DataWorker.EditStock(Stocks);
                }, param => true);
            }

            return _editCommand;
        }
    }

    private RelayCommand _refresh;

    public ICommand Refresh
    {
        get
        {
            if (_refresh == null)
            {
                _refresh = new RelayCommand(param =>
                {
                    _stocks = new List<Stock>(DataWorker.GetStock());
                }, param => true);
            }

            return _editCommand;
        }
    }
}