
public interface IMonoid<T> {
    T Multiply(T value, T value2);
    T Unit();
}

public class Int32SumMonoid : IMonoid<int> {
    public int Multiply(int v1, int v2) => v1 + v2;
    public int Unit() => 0;
}

public class Int32ProducMonoid : IMonoid<int> {
    public int Multiply(int v1, int v2) => v1 * v2;
    public int Unit() => 1;
}

public class  ConcatMonoid : IMonoid<string> {
    public string Multiply(string v1, string v2) => string.Concat(v1, v2);
    public string Unit() => string.Empty;
}

var data = new List<string> { "a", "b", "c", "d", "e", "f"};
var concat = new ConcatMonoid();
data.Aggregate((x, ac) => concat.Multiply(x, ac));

