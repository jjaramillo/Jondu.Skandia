using Microsoft.SharePoint;

namespace Jondu.Skandia.Simulators.UI.MVP
{
    public interface IView
    {
        SPWeb Web { get; set; }
    }
}
