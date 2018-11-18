using Connect.Koi.Polymorphing.Configuration;

namespace Connect.Koi.Polymorphing.Scope
{
    /// <summary>
    /// A scope is a thing the polymorph is tied to. 
    /// This can be a theme, an app or another thing
    /// Scopes usually have a indetifier - which will be used in cookies etc.
    /// and also a configuration - usually from a json in a folder belonging to the scope
    /// </summary>
    public abstract class Scope
    {
        public string Identifier;
        public FullConfig Configuration;
    }
}
