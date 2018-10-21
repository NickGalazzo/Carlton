using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Carlton.Domain.DDD
{
    public abstract class ValueObjectBase
    {
        public static bool operator ==(ValueObjectBase left, ValueObjectBase right)
        {
            if ((left is null) ^ (right is null))
            {
                return false;
            }
            return (left is null) || left.Equals(right);
        }

        public static bool operator !=(ValueObjectBase left, ValueObjectBase right)
        {
            return (!(left == right));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObjectBase)obj;
            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if ((thisValues.Current is null) ^ (otherValues.Current is null))
                {
                    return false;
                }

                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
             .Select(o => o != null ? o.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }

        protected abstract IEnumerable<object> GetAtomicValues();
    }
}

