using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace Expense_Tracker
{
    public class P1_Expense_Entries_ViewModel : NotifyPropertyChanged
    {         
        private Singleton MyInstance = Singleton.Instance;
        
        //Local Variables

        //Singleton Variables
        public Entry TempExpenseEntry
        {
            get
            {
                return MyInstance.TempExpenseEntry;
            }
            set
            {
                this.SetProperty(ref MyInstance.TempExpenseEntry, value);
                if (TempExpenseEntry != null)
                {
                    TempExpenseEntry.PropertyChanged -= MyInstance.ExpenseList.SelectedEntry_PropertyChanged;
                }

                this.SetProperty(ref MyInstance.TempExpenseEntry, value);

                if (TempExpenseEntry != null)
                {
                    TempExpenseEntry.PropertyChanged += MyInstance.ExpenseList.SelectedEntry_PropertyChanged;
                }
            }
        }

        public  Financials ExpenseList
        {
            get
            {
                return MyInstance.ExpenseList;
            }
            set
            {
                this.SetProperty(ref MyInstance.ExpenseList, value);
            }
        }


        private ObservableCollection<String> _possibleCategories;
        public ObservableCollection<String> possibleCategories
        {
            get
            {
                return possibleCategories;
            }
            set
            {
                this.SetProperty(ref _possibleCategories, value);
            }
        }

        //Methods
        public ICommand DeleteExpenseEntryCommand   { get; private set; }
                
        public P1_Expense_Entries_ViewModel()
        {
                //Initiate Commands
                this.DeleteExpenseEntryCommand  = new RelayCommand(obj => this.DeleteExpense());

                possibleCategories = new ObservableCollection<string>
                {   
                     "Food", "Transportation", "Hygiene" 
                };

                this.ExpenseList.InitializeExpense();

        }

        private void DeleteExpense()
        {
            this.ExpenseList.DeleteEntry(TempExpenseEntry);
        }

    }
}
