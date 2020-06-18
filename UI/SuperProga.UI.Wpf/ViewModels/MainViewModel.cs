using SuperProga.Domain.Core;
using SuperProga.UI.Wpf.Commands;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace SuperProga.UI.Wpf.ViewModels
{
  public class MainViewModel : INotifyPropertyChanged
  {
    private string result;

    StringBuilder _expressionBuilder;

    ICalculator _calculatorEngine;

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
    public ICommand EvaluateCommand { get; }

    public MainViewModel()
    {
      EnterSignCommand = new SuperCommand(EnterSign);
      EvaluateCommand = new SuperCommand(Evaluate, canPush);

      _expressionBuilder = new StringBuilder();
      _calculatorEngine = new NCalculator();

    }

    private bool canPush()
    {
      return !string.IsNullOrEmpty(Result);
    }

    private void Evaluate(object obj)
    {
      Result = _calculatorEngine.Evaluate(Result);
      _expressionBuilder = new StringBuilder(Result);
    }

    private void EnterSign(object symbol)
    {
      if (symbol is string stringSymbol)
      {
        _expressionBuilder.Append(stringSymbol);
        Result = _expressionBuilder.ToString();
      }

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
