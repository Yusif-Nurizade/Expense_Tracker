   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5      J FExpense_Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Expense_TrackerExpense_Tracker 5      *   $Expense_Tracker.P4_Income_Categories   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5      /localclr-namespace:Expense_Tracker     5        N� Title$  P4_Income_Categories��5      $
��auto��6!   $
��auto��6/    N� ShowsNavigationUI .   � DataContext 5      4  .Expense_Tracker.P4_Income_Categories_ViewModel  5	   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   .+�5      � $��0��6    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   �� 5      $
��auto �6$   .+�5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  ��5      ��  �� Path$' !IncomeList.SingleMonthsCategories� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�	 �� SelectedItem	 5      �� $ TempIncomeCategory�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *Name+  5      $ Amount��61   $ * 6E    6S   �� *Total+ �� StringFormat$ {0:n2}��  5      $ Percent��61   $ * 6E    6S   �� *	Percent+$ {0:n2}��5      5       >   8System.Windows.Controls.DataVisualization.Charting.Chart  5!   
   -   5        $��CatChart��5!   %   $��1��6   $
��auto��65   $
��auto��6B   
�������
���   �   Title$ Income Category Chart��6v      LegendTitle$ 
Categories��6�      Series. 5"      B   <System.Windows.Controls.DataVisualization.Charting.PieSeries  ?	   9System.Windows.Controls.DataVisualization.Charting.Series 	  Title$ 
Categories��5#      H
   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries 
  IndependentValuePath$
 Name��5%       
  DependentValuePath$ Percent��5&       
  ItemsSource 5$      �� $' !IncomeList.SingleMonthsCategories�5'      5(      5)      5*      