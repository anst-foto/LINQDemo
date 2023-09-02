namespace LINQDemo;

/*
public class Person : IEquatable<Person>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public IEnumerable<string> Phones { get; init; }

    public bool Equals(Person? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return FirstName == other.FirstName && LastName == other.LastName && Phones.Equals(other.Phones);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Person)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, Phones);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {Phones}";
    }
}
*/

public record Person(string FirstName, string LastName, IEnumerable<string> Phones);