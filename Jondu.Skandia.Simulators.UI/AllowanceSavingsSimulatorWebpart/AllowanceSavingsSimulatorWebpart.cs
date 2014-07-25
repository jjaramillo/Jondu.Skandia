using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace Jondu.Skandia.Simulators.UI.AllowanceSavingsSimulatorWebpart
{
    [ToolboxItemAttribute(false)]
    public class AllowanceSavingsSimulatorWebpart : WebPart, ISimulator
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/Jondu.Skandia.Simulators.UI/AllowanceSavingsSimulatorWebpart/AllowanceSavingsSimulatorWebpartUserControl.ascx";

        private string _RESTServiceBaseUrl;
        private bool _UseJquery;

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
        }

        #region [ISimulator Members]
        [WebBrowsable(true), WebDescription("Indica si se debe insertar el script de Jquery dentro del elemento web"), WebDisplayName("Usar Jquery")
        , Personalizable(PersonalizationScope.Shared), Category("Javascript")]
        public bool UseJquery
        {
            get { return _UseJquery; }
            set { _UseJquery = value; }
        }

        [WebBrowsable(true), WebDescription("Url base que se concatena con la ruta del api del simulador"), WebDisplayName("Url Base Servicio REST")
        , Personalizable(PersonalizationScope.Shared), Category("REST")]
        public string RESTServiceBaseUrl
        {
            get { return _RESTServiceBaseUrl; }
            set { _RESTServiceBaseUrl = value; }
        }
        #endregion
    }
}
