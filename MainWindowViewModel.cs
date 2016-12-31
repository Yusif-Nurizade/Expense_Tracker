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
    public class MainWindow_ViewModel: NotifyPropertyChanged
    {
        
        private Singleton MainWindowInstance = Singleton.Instance;

        public Financials ExpenseList
        {
            get
            {
                return MainWindowInstance.ExpenseList;
            }
            set
            {
                this.SetProperty(ref MainWindowInstance.ExpenseList, value);
            }
        }

        public Financials IncomeList
        {
            get
            {
                return MainWindowInstance.IncomeList;
            }
            set
            {
                this.SetProperty(ref MainWindowInstance.IncomeList, value);
            }
        }
        
        public ICommand ExportAllCommand { get; private set; }
        public ICommand LoadExpenseListCommand { get; private set; }

        public MainWindow_ViewModel() 
        {
            this.ExportAllCommand       = new RelayCommand(obj => this.ExportAll());
            this.LoadExpenseListCommand = new RelayCommand(obj => this.LoadExpenseList());
        }

        private void ExportAll() 
        {
            var excelApp                    =   new Microsoft.Office.Interop.Excel.Application();
            var excelWorkbook               =   excelApp.Workbooks.Add();
            var categoryWorksheet           =   excelWorkbook.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            categoryWorksheet.Name          =   "Categories";   
            var expenseEntryWorksheet       =   excelWorkbook.Sheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, System.Reflection.Missing.Value);
            expenseEntryWorksheet.Name      =   "Expenses";
            var incomeEntryWorksheet        =   excelWorkbook.Sheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, System.Reflection.Missing.Value);
            incomeEntryWorksheet.Name       =   "Incomes"; 
            var graphicWorksheet            =   excelWorkbook.Sheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, 1, System.Reflection.Missing.Value);
            graphicWorksheet.Name           =   "Graphics"; 

            //Category Sheet
            categoryWorksheet.Cells[1, "A"] = "Expenses";
            categoryWorksheet.Cells[2, "A"] = "Name";
            categoryWorksheet.Cells[2, "B"] = "Amount";
            categoryWorksheet.Cells[2, "C"] = "Percent";

            var catRow = 2;
            foreach (Category item in MainWindowInstance.ExpenseList.SingleMonthsCategories)
            {
                catRow++;
                categoryWorksheet.Cells[catRow, "A"] = item.Name;
                categoryWorksheet.Cells[catRow, "B"] = item.Total.ToString();
                categoryWorksheet.Cells[catRow, "C"] = item.Percent.ToString();
            }

            catRow = catRow + 2;
            categoryWorksheet.Cells[catRow, "A"] = "Incomes";

            foreach (Category item in MainWindowInstance.IncomeList.SingleMonthsCategories)
            {
                catRow++;
                categoryWorksheet.Cells[catRow, "A"] = item.Name;
                categoryWorksheet.Cells[catRow, "B"] = item.Total.ToString();
                categoryWorksheet.Cells[catRow, "C"] = item.Percent.ToString();
            }

            categoryWorksheet.Columns[1].AutoFit();
            categoryWorksheet.Columns[2].AutoFit();
            categoryWorksheet.Columns[3].AutoFit();


            //Expense Entries Sheet
            expenseEntryWorksheet.Cells[1, "A"] = "Date";
            expenseEntryWorksheet.Cells[1, "B"] = "Category";
            expenseEntryWorksheet.Cells[1, "C"] = "Amount";
            expenseEntryWorksheet.Cells[1, "D"] = "Comment";

            var expRow = 1;
            foreach (Entry item in ExpenseList.SingleMonthsEntries)
            {
                if ((item.Amount != 0) && (item.Category != "Category") && (item.Comment != "Comment"))
                {
                    expRow++;
                    expenseEntryWorksheet.Cells[expRow, "A"] = item.Date.ToShortDateString();
                    expenseEntryWorksheet.Cells[expRow, "B"] = item.Category.ToString();
                    expenseEntryWorksheet.Cells[expRow, "C"] = item.Amount.ToString();
                    expenseEntryWorksheet.Cells[expRow, "D"] = item.Comment.ToString();
                }
            }

            expenseEntryWorksheet.Columns[1].AutoFit();
            expenseEntryWorksheet.Columns[2].AutoFit();
            expenseEntryWorksheet.Columns[3].AutoFit();
            expenseEntryWorksheet.Columns[4].AutoFit();

            //Income Entries Sheet
            incomeEntryWorksheet.Cells[1, "A"] = "Incomes";
            incomeEntryWorksheet.Cells[2, "A"] = "Date";
            incomeEntryWorksheet.Cells[2, "B"] = "Category";
            incomeEntryWorksheet.Cells[2, "C"] = "Amount";
            incomeEntryWorksheet.Cells[2, "D"] = "Comment";

            var incRow = 2;
            foreach (Entry item in IncomeList.SingleMonthsEntries)
            {
                if ((item.Amount != 0) && (item.Category != "Category") && (item.Comment != "Comment"))
                {
                    incRow++;
                    incomeEntryWorksheet.Cells[incRow, "A"] = item.Date.ToShortDateString();
                    incomeEntryWorksheet.Cells[incRow, "B"] = item.Category.ToString();
                    incomeEntryWorksheet.Cells[incRow, "C"] = item.Amount.ToString();
                    incomeEntryWorksheet.Cells[incRow, "D"] = item.Comment.ToString();
                }
            }

            incomeEntryWorksheet.Columns[1].AutoFit();
            incomeEntryWorksheet.Columns[2].AutoFit();
            incomeEntryWorksheet.Columns[3].AutoFit();
            incomeEntryWorksheet.Columns[4].AutoFit();

            //Save Dialog
            SaveFileDialog excelSaveDialog = new SaveFileDialog();
            excelSaveDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
            excelSaveDialog.FilterIndex = 1;
            var dialogResult = excelSaveDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                var saveFilePath = excelSaveDialog.FileName;
                excelWorkbook.SaveAs(saveFilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);//, System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, false, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                excelWorkbook.Close();
            }
        }

        private void LoadExpenseList() 
        {
            var excelApp            = new Microsoft.Office.Interop.Excel.Application();
            OpenFileDialog dialog   = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                ExpenseList.SingleMonthsEntries.Clear();
                IncomeList.SingleMonthsEntries.Clear();
                                
                var excelWorkbook = excelApp.Workbooks.Open(dialog.FileName);
                //var excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Sheets[1];

                //Populate Incomes
                var incomeWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Worksheets.get_Item(2);
                var incomeRange = incomeWorksheet.UsedRange;

                var incNumberOfRows = incomeRange.Rows.Count;

                for (int i = 3; i < incNumberOfRows; i++)
                {
                    Entry forTempEntry = new Entry();

                    var incDateCell         = incomeWorksheet.Cells[i, 1].Value();
                    var incCategoryCell     = incomeWorksheet.Cells[i, 2].Value();
                    var incAmountCell       = incomeWorksheet.Cells[i, 3].Value();
                    var incCommentCell      = incomeWorksheet.Cells[i, 4].Value();

                    forTempEntry.Date       = incDateCell;
                    forTempEntry.Category   = incCategoryCell;
                    forTempEntry.Amount     = incAmountCell;
                    forTempEntry.Comment    = incCommentCell;

                    MainWindowInstance.IncomeList.SingleMonthsEntries.Add(forTempEntry);
                }
                this.IncomeList.DotheMath();
                this.IncomeList.InitializeExpense();

                //Populate Expenses
                var expenseWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Worksheets.get_Item(3) ;
                var expenseRange = expenseWorksheet.UsedRange;

                var expNumberOfRows = expenseRange.Rows.Count;

                for (int i = 3; i < expNumberOfRows; i++)
                {
                    Entry forTempEntry = new Entry();

                    var expDateCell         = expenseWorksheet.Cells[i, 1].Value();
                    var expCategoryCell     = expenseWorksheet.Cells[i, 2].Value();
                    var expAmountCell       = expenseWorksheet.Cells[i, 3].Value();
                    var expCommentCell      = expenseWorksheet.Cells[i, 4].Value();

                    forTempEntry.Date       = expDateCell;
                    forTempEntry.Category   = expCategoryCell;
                    forTempEntry.Amount     = expAmountCell;
                    forTempEntry.Comment    = expCommentCell;

                    MainWindowInstance.ExpenseList.SingleMonthsEntries.Add(forTempEntry);
                }
                this.ExpenseList.DotheMath();
                this.ExpenseList.InitializeExpense();
                
                excelWorkbook.Close();
            }
        }

    }
}