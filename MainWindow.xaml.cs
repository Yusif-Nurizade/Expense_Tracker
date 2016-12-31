using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Expense_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private     P0_Title_Page               TitlePage;               
        private     P1_Expense_Entries          ExpenseListPage;
        private     P2_Expense_Categories       CategoryListPage;
        private     P3_Income_Entries           IncomeListPage;
        private     P4_Income_Categories        IncomeCategoryListPage;
        private     P5_Analysis                 AnalysisPage;

        public MainWindow()
        {
            InitializeComponent();
            this.TitlePage              = new P0_Title_Page();
            this.ExpenseListPage        = new P1_Expense_Entries();
            this.CategoryListPage       = new P2_Expense_Categories();
            this.IncomeListPage         = new P3_Income_Entries();
            this.IncomeCategoryListPage = new P4_Income_Categories();
            this.AnalysisPage           = new P5_Analysis();
            this._mainFrame.Navigate(TitlePage);
        }


        private void GoTo_Page_1(object sender, RoutedEventArgs e)
        {
            this._mainFrame.Navigate(ExpenseListPage);
        }

        private void GoTo_Page_2(object sender, RoutedEventArgs e)
        {
            this._mainFrame.Navigate(CategoryListPage);
        }

        private void GoTo_Page_3(object sender, RoutedEventArgs e)
        {
            this._mainFrame.Navigate(IncomeListPage);
        }

        private void GoTo_Page_4(object sender, RoutedEventArgs e)
        {
            this._mainFrame.Navigate(IncomeCategoryListPage);
        }

        private void GoTo_Page_5(object sender, RoutedEventArgs e)
        {
            this._mainFrame.Navigate(AnalysisPage);
        }
    }
}
