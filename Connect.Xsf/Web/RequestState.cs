using System;
using System.Web;

namespace Connect.Koi.Web
{
    public class RequestState: State
    {
        public override string CssFramework
        {
            get => HttpContext.Current.Items.Contains(Keys.CssFramework)
                ? HttpContext.Current.Items[Keys.CssFramework].ToString() 
                : null;
            set
            {
                // prevent duplicate set, to catch common errors
                var previous = CssFramework;

                // trying to set to same value as before, so just skip
                if (previous == value)
                    return;

                // there was already a value, and it's different
                if(previous != null)
                    throw new Exception($"trying to set the css framework to '{value}', but it has already been set to '{previous}'");

                // all ok, just set
                HttpContext.Current.Items.Add(Keys.CssFramework, value);

            }
        }
    }
}
