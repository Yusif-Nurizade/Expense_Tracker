using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Tracker
{
    public class P5_Analysis_ViewModel : NotifyPropertyChanged
    {
        private Singleton AnalysisPageInstance = Singleton.Instance;

        public ObservableCollection<BudgetElement> BudgetExpense { get; set; }
        public ObservableCollection<BudgetElement> BudgetIncome { get; set; }
        
        public Financials ExpenseList
        {
            get
            {
                return AnalysisPageInstance.ExpenseList;
            }
            set
            {
                this.SetProperty(ref AnalysisPageInstance.ExpenseList, value);
            }
        }
        
        public Financials IncomeList
        {
            get
            {
                return AnalysisPageInstance.IncomeList;
            }
            set
            {
                this.SetProperty(ref AnalysisPageInstance.IncomeList, value);
            }
        }

        public P5_Analysis_ViewModel()
        {
            BudgetExpense = new ObservableCollection<BudgetElement>();
            BudgetIncome = new ObservableCollection<BudgetElement>();
         
            BudgetExpense.Add(new BudgetElement { Name = "Expense", Amount = AnalysisPageInstance.ExpenseList.EntryTotal });
            BudgetIncome.Add(new BudgetElement { Name = "Income", Amount = AnalysisPageInstance.IncomeList.EntryTotal });

            ExpenseList.PropertyChanged += List_PropertyChanged;
            IncomeList.PropertyChanged += List_PropertyChanged;

        }

        public void List_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
            BudgetExpense[0].Amount = AnalysisPageInstance.ExpenseList.EntryTotal;
            BudgetIncome[0].Amount = AnalysisPageInstance.IncomeList.EntryTotal;
        }
    }
}
