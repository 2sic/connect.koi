using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect.Koi
{
    /// <summary>
    /// Inherit from this class to add a css framework resolver
    /// </summary>
    public abstract class FrameworkResolver
    {
        public abstract string GetCSSFramework();
    }
}
