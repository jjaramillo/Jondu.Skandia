using System;
using System.Web.UI;

namespace Jondu.Skandia.Simulators.UI.AllowanceSavingsSimulatorWebpart
{
    public partial class AllowanceSavingsSimulatorWebpartUserControl : BaseSimulatorUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (CheckForRESTServiceBaseUrl())
            {
                allowanceSavingsUserControlContainer.Visible = true;
                _ScriptManagerProxy.Scripts.Add(new ScriptReference("/_layouts/15/INC/Jondu.Skandia.Simulators/js/knockout-3.1.0.js"));
                _ScriptManagerProxy.Scripts.Add(new ScriptReference("/_layouts/15/INC/Jondu.Skandia.Simulators/js/AllowanceSavingsViewModel.js"));
                RegisterViewModel();
            }
            else
            {
                HandleWarning("No se puede inicializar modelo-vista para este simulador. Debe configurar la url del API");
                allowanceSavingsUserControlContainer.Visible = false;
            }
        }

        private void RegisterViewModel()
        {
            string viewModelJavascript = string.Format(
                    @"var allowanceSavingsViewModel_{0} = new AllowanceSavingsViewModel('{0}', '{1}'); ko.applyBindings(allowanceSavingsViewModel_{0}, document.getElementById('{0}'));"
                    , allowanceSavingsUserControlContainer.ClientID, RESTServiceBaseUrl);
            ScriptManager.RegisterStartupScript(this, typeof(AllowanceSavingsSimulatorWebpartUserControl), "AllowanceSavingsViewModel", viewModelJavascript, true);
        }

        
    }
}
