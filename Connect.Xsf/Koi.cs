using System;
using System.Linq;

namespace Connect.Koi
{
    public class Koi
    {
        public const string Initial = "def";
        public const string All = "all";

        public string Default = Initial;

        public string Current => _current ?? Default;
        private readonly string _current;

        public Koi(string selected)
        {
            _current = selected.ToLowerInvariant();
        }

        public bool Is(string compare) => string.Equals(Current, compare, StringComparison.InvariantCultureIgnoreCase);

        public string Pick(string[,] list) => Find(list, Current) ?? Find(list, Default);
        public string Pick(string[][] list) => Find(list, Current) ?? Find(list, Default);
        public string Pick(string list) => Pick(list.Split(',').Select(i => i.Split(':')).ToArray());

        private static string Find(string[,] list, string key)
        {
            for (var i = 0; i < list.Length; i++)
                if (string.Equals(list[i, 0], key, StringComparison.InvariantCultureIgnoreCase))
                    return list[i, 1];
            return null;
        }
        private static string Find(string[][] list, string key)
        {
            foreach (string[] itm in list)
                if (string.Equals(itm[0], key, StringComparison.InvariantCultureIgnoreCase))
                    return itm[1];
            return null;
        }

        private const string Classwrapper= "class=\"{0}\"";
        public string Class(string[,] list) => Classify(() => Pick(list));
        public string Class(string[][] list) => Classify(() => Pick(list));
        public string Class(string list) => Classify(() => Pick(list));

        private string Classify(Func<string> pick) => string.Format(Classwrapper, pick());
    }
}
