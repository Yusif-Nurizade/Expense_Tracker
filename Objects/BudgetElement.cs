using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class BudgetElement : NotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.SetProperty(ref this._Name, value);
            }
        }

        private double _Amount;
        public double Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                this.SetProperty(ref this._Amount, value);
            }
        }
    }
}

