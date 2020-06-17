using SuperProga.UI.Wpf.Commands;
using System;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Input;

namespace SuperProga.UI.Wpf.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string result;

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ICommand EnterSignCommand { get; }

        public MainViewModel()
        {
            EnterSignCommand = new SuperCommand(EnterSign);
        }

        StringBuilder sb = new StringBuilder("");

        private void EnterSign(object obj)
        {
            Result = sb.Append(obj.ToString()).ToString();

        }

       
          



       
            
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
