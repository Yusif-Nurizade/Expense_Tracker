using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Financials : NotifyPropertyChanged
    {
         //Variables
        private double _EntryTotal;
        public double EntryTotal
        {
            get
            {
                return _EntryTotal;
            }
            set
            {
                this.SetProperty(ref _EntryTotal, value);
            }
        }
        
        private Entry _SelectedEntry;
        public Entry SelectedEntry
        {
            get
            {
                return _SelectedEntry;
            }
            set
            {
                this.SetProperty(ref _SelectedEntry, value);
            }
        }

        private ObservableCollection<Category> _SingleMonthsCategories;
        public ObservableCollection<Category> SingleMonthsCategories
        {
            get
            {
                return _SingleMonthsCategories;
            }
            set
            {
                this.SetProperty(ref _SingleMonthsCategories, value);
            }
        }
      
        private ObservableCollection<Entry> _SingleMonthsEntries;
        public ObservableCollection<Entry> SingleMonthsEntries
        {
            get
            {
                return _SingleMonthsEntries;
            }
            set
            {
                this.SetProperty(ref _SingleMonthsEntries, value);
            }
        }

        public Financials()
        {
            this.SingleMonthsEntries = new ObservableCollection<Entry>();
            this.SingleMonthsCategories = new ObservableCollection<Category>();
        }

        public void SelectedEntry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            var blue = sender as Entry;
            if ((blue.Date != default(DateTime)) && (blue.Category != "Category") && (blue.Amount != 0) && (blue.Comment != "Comment"))
            {
                DotheMath();
                InitializeExpense();
            }
        }

        //Methods
        public void DotheMath() 
        {
            this.EntryTotal = this.SingleMonthsEntries.Sum(exp => exp.Amount);
            
            var finalQuery = this.SingleMonthsEntries
                .GroupBy(category => category.Category)
                .Select(grouping => new Category { Name = grouping.Key, Total = grouping.Sum(moneySpent => moneySpent.Amount), Percent = (grouping.Sum(moneySpent => moneySpent.Amount)) / EntryTotal * 100 });

            this.SingleMonthsCategories = new ObservableCollection<Category>(finalQuery);
        }

        public void DeleteEntry(Entry EntryToDelete)
        {
            if (EntryToDelete != null) 
            {
                SingleMonthsEntries.Remove(EntryToDelete);
                EntryToDelete = null;
                DotheMath();
            }

        }

        public void InitializeExpense()
        {     
            SingleMonthsEntries.Add(new Entry());
        }
    }
}
