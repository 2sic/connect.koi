namespace Connect.Koi.Context
{
    internal class ToolsForCurrentState
    {
        public StateBase State = new HttpContextState();

        public Html.Css Css => _css ?? (_css = new Html.Css(State.CssFramework));
        private Html.Css _css;
    }
}
