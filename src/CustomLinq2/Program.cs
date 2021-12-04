var none = Maybe<int>.None;
var sentence = Maybe<string>.Some("C# is super!");

void Print<T>(Maybe<T> message) => message.Iter(v => Console.WriteLine(v), () => Console.WriteLine("None"));
Print(sentence);


Maybe<bool> IsEven(Maybe<int> input) => input.Bind(v => Maybe<bool>.Some(v % 2 == 0));
Print(IsEven(none));

Maybe<int> p = Maybe<int>.Some(1);
Maybe<int> p2 = Maybe<int>.Some(2);
var result = p.Bind(pValue => p2.Map(p2Value => pValue + p2Value));
Print(result);

var result2 = 
    from q1 in Maybe<int>.Some(1)
    from q2 in Maybe<int>.Some(11)
    from q3 in Maybe<int>.Some(2)
    select q1 + q2 + q3;
Print(result2);

public abstract class Maybe<T>
{
    public abstract R Match<R>(Func<T, R> someFunc, Func<R> noneFunc);
    
    public abstract void Iter(Action<T> someAction, Action noneAction);

    public static Maybe<T> Some(T value) => new Choices.Some(value);

    public static Maybe<T> None { get; } = new Choices.None();

    public Maybe<R> Map<R>(Func<T, R> map) =>
        Match(
            v => Maybe<R>.Some(map(v)),
            () => Maybe<R>.None);
    
    public Maybe<R> Bind<R>(Func<T, Maybe<R>> map) =>
        Match(
            v => map(v).Match(
                r => Maybe<R>.Some(r),
                () => Maybe<R>.None),
            () => Maybe<R>.None);

    private class Choices
    {
        public class Some : Maybe<T>
        {
            private readonly T value;
            public Some(T value)
            {
                this.value = value;
            }
            
            public override R Match<R>(Func<T, R> someFunc, Func<R> noneFunc) =>
                someFunc(value);
            
            public override void Iter(Action<T> someAction, Action noneAction) =>
                someAction(value);
            
        }

        public class None : Maybe<T>
        {
            public override R Match<R>(Func<T, R> someFunc, Func<R> noneFunc) =>
                noneFunc();
            
            public override void Iter(Action<T> someAction, Action noneAction) =>
                noneAction();
        }
    }
}

public static partial class LinqExtensions
{
    public static Maybe<C> SelectMany<A, B, C>(this Maybe<A> ma, Func<A, Maybe<B>> f, Func<A, B, C> select) => 
        ma.Bind(a => f(a).Map(b => select(a, b)));
}