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
    public class P2_Expense_Categories_ViewModel: NotifyPropertyChanged
    {
        private Singleton CategoryPageInstance = Singleton.Instance;

        //Local Variables
        public Category TempExpenseCategory
        {
            get
            {
                return CategoryPageInstance.TempExpenseCategory;
            }
            set
            {
                this.SetProperty(ref CategoryPageInstance.TempExpenseCategory, value);
            }
        }

        public Financials ExpenseList
        {
            get
            {
                return CategoryPageInstance.ExpenseList;
            }
            set
            {
                this.SetProperty(ref CategoryPageInstance.ExpenseList, value);
            }
        }

        public P2_Expense_Categories_ViewModel()
        {

        }

    }
}
