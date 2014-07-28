using Microsoft.SharePoint.WebControls;
using System;
using System.Web.UI;

namespace Jondu.Skandia.Simulators.UI
{
    public class BaseSimulatorUserControl : UserControl, ISimulator
    {
        public bool UseJquery
        {
            get
            {
                return ViewState["UseJquery"] == null ? false : Convert.ToBoolean(ViewState["UseJquery"]);
            }
            set
            {
                ViewState["UseJquery"] = value;
            }
        }

        public string RESTServiceBaseUrl
        {
            get
            {
                return ViewState["RESTServiceBaseUrl"] == null ? string.Empty : ViewState["RESTServiceBaseUrl"].ToString();
            }
            set
            {
                ViewState["RESTServiceBaseUrl"] = value;
            }
        }

        private SPPageStatusSetter _SPPageStatusSetter;

        protected ScriptManagerProxy _ScriptManagerProxy;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _SPPageStatusSetter = new SPPageStatusSetter();
            _ScriptManagerProxy = new ScriptManagerProxy();
            if (UseJquery)
                _ScriptManagerProxy.Scripts.Add(new ScriptReference("/_layouts/15/INC/Jondu.Skandia.Simulators/js/jquery-1.11.1.min.js"));

            Controls.Add(_SPPageStatusSetter);
            Controls.Add(_ScriptManagerProxy);
        }

        protected void HandleServerError(Exception ex)
        {
            _SPPageStatusSetter.AddStatus("Error no controlado",
                string.Format("<p>{0}.</p><p>Stacktrace: {1}.</p>", ex.Message.Replace("\n", "<br/>"), ex.StackTrace.Replace("\n", "<br/>")), SPPageStatusColor.Red);
        }

        protected void HandleWarning(string warningMessage)
        {
            _SPPageStatusSetter.AddStatus("Advertencia", warningMessage, SPPageStatusColor.Yellow);
        }

        protected bool CheckForRESTServiceBaseUrl()
        {
            return !string.IsNullOrEmpty(RESTServiceBaseUrl);
        }

    }
}
