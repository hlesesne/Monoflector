using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monoflector
{
    /// <summary>
    /// Compares <see cref="ILightAssembly"/> objects.
    /// </summary>
    public class LightAssemblyComparer : IComparer<ILightAssembly>, IEqualityComparer<ILightAssembly>
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        public static readonly LightAssemblyComparer Instance = new LightAssemblyComparer();

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        /// </returns>
        public int Compare(ILightAssembly x, ILightAssembly y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            var dif = StringComparer.Ordinal.Compare(x.Name, y.Name);
            if (dif == 0)
            {
                dif = x.Version.CompareTo(y.Version);
            }

            return dif;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(ILightAssembly x, ILightAssembly y)
        {
            return Compare(x, y) == 0;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The type of obj is a reference type and obj is null.</exception>
        public int GetHashCode(ILightAssembly obj)
        {
            if (obj == null)
                return 0;
            var hc = 0;
            if (obj.Name != null)
                hc = obj.Name.GetHashCode();
            if (obj.Version != null)
                hc ^= obj.Version.GetHashCode();
            return hc;
        }
    }
}
