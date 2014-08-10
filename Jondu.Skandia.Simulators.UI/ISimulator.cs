
namespace Jondu.Skandia.Simulators.UI
{
    public interface ISimulator
    {
        bool UseJquery { get; set; }
        DecimalSeparators DecimalSeparator { get; set; }
        string RESTServiceBaseUrl { get; set; }
        string CallJavascript { get; set; }
        string ScheduleJavascript { get; set; }
        string ChatJavascript { get; set; }
    }
}
