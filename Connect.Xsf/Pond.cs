using Connect.Koi.Web;

namespace Connect.Koi
{
    public class Pond
    {
        public State State = new HttpContextState();

        public TemplateHelper TemplateHelper => _templateHelper ?? (_templateHelper = new TemplateHelper(State.CssFramework));
        private TemplateHelper _templateHelper;
    }
}
