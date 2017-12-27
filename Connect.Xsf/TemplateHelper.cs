using System;

namespace Connect.Koi
{
    public partial class TemplateHelper
    {

        public string Current => _current ?? Css.Unknown;
        private readonly string _current;

        public TemplateHelper(string selected)
        {
            _current = selected.ToLowerInvariant();
        }

        public bool Is(string compare) => string.Equals(Current, compare, StringComparison.InvariantCultureIgnoreCase);




    }
}
