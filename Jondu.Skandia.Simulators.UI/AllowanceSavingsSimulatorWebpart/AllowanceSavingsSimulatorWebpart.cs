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


        private bool _UseJquery;
        private DecimalSeparators _DecimalSeparator;
        private string _CallJavascript;
        private string _RESTServiceBaseUrl;
        private string _ScheduleJavascript;
        private string _ChatJavascript;

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            BaseSimulatorUserControl baseCtrl = control as BaseSimulatorUserControl;
            baseCtrl.UseJquery = UseJquery;
            baseCtrl.RESTServiceBaseUrl = RESTServiceBaseUrl;
            baseCtrl.DecimalSeparator = DecimalSeparator;
            baseCtrl.ChatJavascript = ChatJavascript;
            baseCtrl.ScheduleJavascript = ScheduleJavascript;
            baseCtrl.CallJavascript = CallJavascript;
            Controls.Add(control);
        }

        #region [ISimulator Members]

        [WebBrowsable(true), WebDescription("Javacript que se utilizara al presionar en el boton de realizar llamada"), WebDisplayName("Script para realizar llamada")
        , Personalizable(PersonalizationScope.Shared), Category("Javascript")]
        public string CallJavascript
        {
            get
            {
                return _CallJavascript;
            }
            set
            {
                _CallJavascript = value;
            }
        }

        [WebBrowsable(true), WebDescription("Javascript que se utilizara al presionar el boton para agendar la llamada"), WebDisplayName("Script para agendar llamada")
        , Personalizable(PersonalizationScope.Shared), Category("Javascript")]
        public string ScheduleJavascript
        {
            get
            {
                return _ScheduleJavascript;
            }
            set
            {
                _ScheduleJavascript = value;
            }
        }

        [WebBrowsable(true), WebDescription("Javascript que se utilizara al presionar el boton de chat"), WebDisplayName("Script para Chat")
        , Personalizable(PersonalizationScope.Shared), Category("Javascript")]
        public string ChatJavascript
        {
            get
            {
                return _ChatJavascript;
            }
            set
            {
                _ChatJavascript = value;
            }
        }

        [WebBrowsable(true), WebDescription("Indica si debe incluir el script de Jquery en la pagina (requerido para los llamados asincronos)"), WebDisplayName("Usar Jquery")
        , Personalizable(PersonalizationScope.Shared), Category("Javascript")]
        public bool UseJquery
        {
            get { return _UseJquery; }
            set { _UseJquery = value; }
        }

        [WebBrowsable(true), WebDescription("Indica el separador de cifras decimales que se usara para enviar datos numericos"), WebDisplayName("Separador Decimal")
        , Personalizable(PersonalizationScope.Shared), Category("Javascript")]
        public DecimalSeparators DecimalSeparator
        {
            get { return _DecimalSeparator; }
            set { _DecimalSeparator = value; }
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
