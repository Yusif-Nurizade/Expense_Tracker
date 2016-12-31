using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Expense_Tracker
{
    public class P4_Income_Categories_ViewModel: NotifyPropertyChanged
    {
        private Singleton IncomeCategoriesPageInstance = Singleton.Instance;

        //Local Variables

        //Singleton Variables
        public Category TempIncomeCategory
        {
            get
            {
                return IncomeCategoriesPageInstance.TempIncomeCategory;
            }
            set
            {
                this.SetProperty(ref IncomeCategoriesPageInstance.TempIncomeCategory, value);
            }
        }

        public Financials IncomeList
        {
            get
            {
                return IncomeCategoriesPageInstance.IncomeList;
            }
            set
            {
                this.SetProperty(ref IncomeCategoriesPageInstance.IncomeList, value);
            }
        }

        public P4_Income_Categories_ViewModel()
        {

        }

    }
}
