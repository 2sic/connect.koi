using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Connect.Koi.Internals
{
    internal static class AsEnumerableExtensionMethods
    {
        ///// <summary>
        ///// Returns the input typed as a generic IEnumerable of the groups
        ///// </summary>
        ///// <returns></returns>
        //public static IEnumerable<Group> AsEnumerable(this GroupCollection gc) 
        //    => gc.Cast<Group>();

        /// <summary>
        /// Returns the input typed as a generic IEnumerable of the matches
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Match> AsEnumerable(this MatchCollection mc) 
            => mc.Cast<Match>();
    }
}
