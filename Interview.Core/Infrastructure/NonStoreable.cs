using System;

namespace Interview.Core.Infrastructure
{
    public class NonStoreable
    {
        public IComparable Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj != null) && obj is NonStoreable)
            {
                NonStoreable nonStoreable = (NonStoreable)obj;
                return nonStoreable.Id == Id;
            }
            else if ((obj != null) && obj is int)
            {
                int id = (int)obj;
                return id == (int)Id;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
