using System.Linq.Expressions;

var lessThanOrEqual = Expression.LessThanOrEqual(
    Expression.Constant(42),
    Expression.Constant(45)
);

Console.WriteLine(lessThanOrEqual.ToString());
Console.WriteLine(Expression.Lambda<Func<bool>>(lessThanOrEqual).Compile()());
