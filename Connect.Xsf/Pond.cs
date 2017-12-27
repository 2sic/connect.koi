using Connect.Koi.Web;

namespace Connect.Koi
{
    public class Pond
    {
        public State State = new RequestState();

        public Part Part => _part ?? (_part = new Part(State.CssFramework));
        private Part _part;
    }
}
