using Connect.Koi.Configuration.Json;
using Newtonsoft.Json;

namespace Connect.Testing.Koi.Polymorphism.LoadConfiguration
{
    public class LoadBase
    {
        protected Root Deserialize(string json)
        {
            json = json.Replace("'", "\"");
            return JsonConvert.DeserializeObject<Root>(json);
        }
    }
}
