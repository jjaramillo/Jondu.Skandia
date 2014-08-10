
namespace Jondu.Skandia.Simulators.UI.Entities
{
    public class SavingsObjective
    {
        private int _ID;
        private string _Title;
        private double _SavingsRate;

        public int ID 
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Title 
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public double SavingsRate 
        {
            get { return _SavingsRate; }
            set { _SavingsRate = value; }
        }
    }
}
