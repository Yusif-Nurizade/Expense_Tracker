using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Category : NotifyPropertyChanged
    {
        //Variables
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

        private double _Percent;
        public double Percent
        {
            get
            {
                return this._Percent;
            }
            set
            {
                this.SetProperty(ref this._Percent, value);
            }
        }

        private double _Total;
        public double Total
        {
            get
            {
                return this._Total;
            }
            set
            {
                this.SetProperty(ref this._Total, value);
            }
        }

        //Methods
            //Main Method
        public Category() 
        {
            Name    = "Category";
            Percent = 0.00;
            Total   = 0.00;
        }
    }
}
