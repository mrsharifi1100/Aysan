namespace Catalog.Domain.Common;

public class Entity
{
    public int? _requestHashCode;
    public long Id { get; protected set; }

    // Checks whether the entity has not been persisted yet (Id == 0).
    public bool IsTransient()
    {
        return this.Id == default(Int32);
    }


    // Compares entities by identity (Id), not by object reference or property values.
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Entity))
        {
            return false;
        }

        // Same object instance.
        if (Object.ReferenceEquals(this, obj))
        {
            return true;
        }

        // Entities must be of the same concrete type.
        if (this.GetType() != obj.GetType())
        {
            return false;
        }

        Entity item = (Entity)obj;

        // Transient entities have no identity, so they are not equal.
        if (item.IsTransient() || this.IsTransient())
        {
            return false;
        }
        else
            return item.Id == this.Id;
    }


    // Makes != follow the same identity-based equality logic as Equals.
    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }


    // Makes == compare entities using their Equals implementation.
    public static bool operator ==(Entity left, Entity right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }


    // Generates a stable hash based on Id for persisted entities.
    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestHashCode.HasValue)
                _requestHashCode = this.Id.GetHashCode() ^ 31;

            return _requestHashCode.Value;
        }
        else
            return base.GetHashCode();
    }
}