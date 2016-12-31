using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Entry: NotifyPropertyChanged
    {
        //Variables

        private DateTime _Date;
        public DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                this.SetProperty(ref this._Date, value);
            }
        }


        private string _Category;
        public string Category
        {
            get
            {
                return this._Category;
            }
            set
            {
                this.SetProperty(ref this._Category, value);
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


        private string _Comment;
        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                this.SetProperty(ref this._Comment, value);
            }
        }

        public Entry()
        {
            Date      =  DateTime.Today;
            Category  =  "Category";
            Amount    =  0000.00;
            Comment   =  "Comment";
        }
    }
}
