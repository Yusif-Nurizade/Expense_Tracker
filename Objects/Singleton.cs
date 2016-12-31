using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Singleton : NotifyPropertyChanged
    {
        private static Singleton instance;
        private Singleton() { }

        //These objects need to be instantiated here otherwise, they will be reloaded (everything erased) every time a page is opened. 
        public  Financials  ExpenseList         = new Financials();
        public  Financials  IncomeList          = new Financials();
        public  Entry       TempExpenseEntry    = new Entry();
        public  Entry       TempIncomeEntry     = new Entry();
        public  Category    TempExpenseCategory = new Category();
        public  Category    TempIncomeCategory  = new Category();

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

    }
}
