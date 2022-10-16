using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoSound.ViewModel.Base
{
    public class ViewModelBase: INotifyPropertyChanged,IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;
        protected virtual bool Dispose(bool disposing)
        {
            if (!disposing || _Disposed)
            {
                return true;
            }

            _Disposed = true;
            return _Disposed;
        }
    }
}
