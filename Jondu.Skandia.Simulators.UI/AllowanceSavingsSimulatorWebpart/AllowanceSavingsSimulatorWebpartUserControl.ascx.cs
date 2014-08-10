using Jondu.Skandia.Simulators.UI.Entities;
using Jondu.Skandia.Simulators.UI.MVP.AllowanceSavingsSimulator;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Jondu.Skandia.Simulators.UI.AllowanceSavingsSimulatorWebpart
{
    public partial class AllowanceSavingsSimulatorWebpartUserControl : BaseSimulatorUserControl, IAllowanceSavingsSimulatorView
    {
        private SPWeb _SPWeb;       

        private AllowanceSavingsSimulatorPresenter _AllowanceSavingsSimulatorPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && allowanceSavingsUserControlContainer.Visible)
            {
                _AllowanceSavingsSimulatorPresenter.ChangeDecimalSeparator();
                ddlSavings.DataSource = _AllowanceSavingsSimulatorPresenter.GetSavingsObjectives();
                ddlSavings.DataBind();
                if (ddlSavings.Items.Count == 0)
                {
                    allowanceSavingsUserControlContainer.Visible = false;
                    HandleWarning("No se han configurado ningun objetivo de ahorro para este subsitio. Por favor contacte al administrador.");
                }
            }
                
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _AllowanceSavingsSimulatorPresenter = new AllowanceSavingsSimulatorPresenter(this);
            _SPWeb = SPContext.Current.Web;
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
                    @"var allowanceSavingsViewModel_{0} = new AllowanceSavingsViewModel('{0}', '{1}', '{2}', '{3}', '{4}'); ko.applyBindings(allowanceSavingsViewModel_{0}, document.getElementById('{0}'));"
                    , allowanceSavingsUserControlContainer.ClientID, RESTServiceBaseUrl, CallJavascript.EscapeScript(), ChatJavascript.EscapeScript(), ScheduleJavascript.EscapeScript());
            ScriptManager.RegisterStartupScript(this, typeof(AllowanceSavingsSimulatorWebpartUserControl), "AllowanceSavingsViewModel", viewModelJavascript, true);
        }

        public IList<SavingsObjective> SavingsObjectives
        {
            get
            {
                return ViewState["SavingsObjective"] == null ? new List<SavingsObjective>()
                    : ViewState["SavingsObjective"] as List<SavingsObjective>;
            }
            set
            {
                ViewState["SavingsObjective"] = value;
            }
        }

        public SPWeb Web
        {
            get
            {
                return _SPWeb;
            }
            set
            {
                _SPWeb = value;
            }
        }
    }
}
