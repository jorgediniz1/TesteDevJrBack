namespace TesteVagaJr.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; private set; }

    internal List<string> _errors;
    public IReadOnlyCollection<string> Errors => _errors;
    public abstract bool Validate();


    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}