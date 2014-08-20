using Jondu.Skandia.Simulators.UI.Constants;
using Jondu.Skandia.Simulators.UI.Entities;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Jondu.Skandia.Simulators.UI.MVP.AllowanceSavingsSimulator
{
    public class AllowanceSavingsSimulatorPresenter: BasePresenter<IAllowanceSavingsSimulatorView>
    {
        public AllowanceSavingsSimulatorPresenter(IAllowanceSavingsSimulatorView view) : base(view) { }

        public IList<SavingsObjective> GetSavingsObjectives()
        {
            List<SavingsObjective> savingsObjectives = new List<SavingsObjective>();
            SPList targetList = _View.Web.GetList(string.Format("{0}/Lists/Objectives", _View.Web.Url));
            SPListItemCollection listElements = targetList.Items;
            savingsObjectives = (from SPListItem listItem in listElements
                                 orderby listItem.Title 
                                 select new SavingsObjective 
                                     {
                                         ID = listItem.ID,
                                         Title = listItem.Title,
                                         SavingsRate = Convert.ToDouble(listItem[SiteColumns.JONDU_FIELDS_INTEREST_RATE])
                                     }
                                 ).ToList();
            return savingsObjectives;
        }

        public void ChangeDecimalSeparator()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            switch (_View.DecimalSeparator)
            { 
                case DecimalSeparators.Coma:
                    currentCulture.NumberFormat.NumberDecimalSeparator = ",";
                    break;
                case DecimalSeparators.Dot:
                    currentCulture.NumberFormat.NumberDecimalSeparator = ".";
                    break;

            }            
        }
    }
}
