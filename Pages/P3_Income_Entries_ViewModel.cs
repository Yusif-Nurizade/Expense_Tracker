using System;
using System.Windows.Input;
using System.Collections.Generic;
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
    public class P3_Income_Entries_ViewModel : NotifyPropertyChanged
    {
        private Singleton IncomeEntriesPageInstance = Singleton.Instance;

        //Local Variables

        //Singleton Variables
        public Entry TempIncomeEntry
        {
            get
            {
                return IncomeEntriesPageInstance.TempIncomeEntry;
            }
            set
            {
                this.SetProperty(ref IncomeEntriesPageInstance.TempIncomeEntry, value);
                if (TempIncomeEntry != null)
                {
                    TempIncomeEntry.PropertyChanged -= IncomeEntriesPageInstance.IncomeList.SelectedEntry_PropertyChanged;
                }

                this.SetProperty(ref IncomeEntriesPageInstance.TempIncomeEntry, value);

                if (TempIncomeEntry != null)
                {
                    TempIncomeEntry.PropertyChanged += IncomeEntriesPageInstance.IncomeList.SelectedEntry_PropertyChanged;
                }
            }
        }

        public Financials IncomeList
        {
            get
            {
                return IncomeEntriesPageInstance.IncomeList;
            }
            set
            {
                this.SetProperty(ref IncomeEntriesPageInstance.IncomeList, value);
            }
        }

        //Methods
        public ICommand DeleteExpenseEntryCommand { get; private set; }

        public P3_Income_Entries_ViewModel()
        {
            //Initiate Commands
            this.DeleteExpenseEntryCommand = new RelayCommand(obj => this.DeleteExpense());

            //Initiate Categories

            this.IncomeList.InitializeExpense();

        }

        private void DeleteExpense()
        {
            this.IncomeList.DeleteEntry(TempIncomeEntry);
        }

    }
}
