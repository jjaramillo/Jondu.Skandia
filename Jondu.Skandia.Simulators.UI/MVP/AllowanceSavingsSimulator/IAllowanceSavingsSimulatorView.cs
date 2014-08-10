using Jondu.Skandia.Simulators.UI.Entities;
using System.Collections.Generic;

namespace Jondu.Skandia.Simulators.UI.MVP.AllowanceSavingsSimulator
{
    public interface IAllowanceSavingsSimulatorView : IView
    {
        DecimalSeparators DecimalSeparator { get; set; }
        IList<SavingsObjective> SavingsObjectives { get; set; }
    }
}
