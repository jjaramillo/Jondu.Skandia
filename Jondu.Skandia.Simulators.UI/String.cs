
namespace Jondu.Skandia.Simulators.UI
{
    public static class String
    {
        public static string EscapeScript(this string script)
        {
            return script.Replace("'", "\\'").Replace("\"", "\\\"");
        }
    }
}
