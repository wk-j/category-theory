using System.Linq.Expressions;
using System.Reflection;
using System.Linq;

public interface ICateogry<TObject, TMorphism> {
    IEnumerable<TObject> Objects { get; }
    TMorphism Compose(TMorphism m1, TMorphism m2);
    TMorphism Id(TObject @object);
}

public class Int32Category : ICateogry<int, BinaryExpression> {
    public IEnumerable<int> Objects {
        get { for (int i32 = int.MinValue; i32 <= int.MaxValue; i32 ++) yield return i32; }
    }

    public BinaryExpression Compose(BinaryExpression m2, BinaryExpression m1)  =>
        Expression.LessThanOrEqual(m2.Left, m1.Right);

    public BinaryExpression Id(int @object) =>
        Expression.LessThanOrEqual(Expression.Constant(@object), Expression.Constant(@object));
}

public static partial class Functions
{
    public static Func<TSource, TResult> o<TSource, TMiddle, TResult>(
        this Func<TMiddle, TResult> function2, Func<TSource, TMiddle> function1) =>
            value => function2(function1(value));

    public static TSource Id<TSource>(T value) => value;
}

   public Delegate Id(Type @object) => // Functions.Id<TSource>
        typeof(Functions).GetTypeInfo().GetMethod(nameof(Functions.Id)).MakeGenericMethod(@object)
            .CreateDelegate(typeof(Func<,>).MakeGenericType(@object, @object));

    private static IEnumerable<Assembly> SelfAndReferences( Assembly self, HashSet<Assembly> selfAndReferences = null) {
        selfAndReferences = selfAndReferences ?? new HashSet<Assembly>();
        if (selfAndReferences.Add(self))
        {
            self.GetReferencedAssemblies().ForEach(reference => 
                SelfAndReferences(Assembly.Load(reference), selfAndReferences));
            return selfAndReferences;
        }
        return Enumerable.Empty<Assembly>(); // Circular or duplicate reference.
    }
}