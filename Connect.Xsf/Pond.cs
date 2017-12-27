using Connect.Koi.Web;

namespace Connect.Koi
{
    public class Pond
    {
        public State State = new HttpContextState();

        public Part Part => _part ?? (_part = new Part(State.CssFramework));
        private Part _part;
    }
}
