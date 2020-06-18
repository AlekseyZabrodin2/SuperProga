using NCalc;

namespace SuperProga.Domain.Core
{
  public class NCalculator : ICalculator
  {
    public string Evaluate(string expression)
    {
      var calcExpression = new Expression(expression);

      return calcExpression.Evaluate().ToString();
    }
  }
}
