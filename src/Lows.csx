
public interface ICateogry<TObject, TMorphism> {
    IEnumerable<TObject> Objects { get; }
    TMorphism Compose(TMorphism m1, TMorphism m2);
    TMorphism Id(TObject @object);
}