   M S B A M L   `   `   `  ����J  FExpense_Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Expense_TrackerExpense_Tracker  5      '    !Expense_Tracker.P3_Income_Entries   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      /localclr-namespace:Expense_Tracker     5        N� Title$  P3_Income_Entries��5      $
��auto��6   $
��auto��6,    N� ShowsNavigationUI .   � DataContext 5      1   +Expense_Tracker.P3_Income_Entries_ViewModel  5	   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��Visible=�6   ��. .��5      &   System.Windows.Controls.DataGrid  $��0��5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5      $��Stretch=�5      $��Stretch=�5      $	��600��5      ��5      ��  �� Path$$ IncomeList.SingleMonthsEntries�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=� �� SelectedItem 5      �� $ TempIncomeEntry� J� InputBindings 5      �� 5       
 �� Key$ Delete��6!    �� Command 6.   �� $ DeleteExpenseEntryCommand�   Columns 5"      4  .System.Windows.Controls.DataGridTemplateColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��61      Width$	 100 6@      SortMemberPath$
 Date��6L      CellTemplate 5$      �� 5%      .R�5&   "   (  "System.Windows.Controls.DatePicker     SelectedDate 6-   �� *Date+ �� StringFormat$ yy/MM/dd��5(      5*      0  *System.Windows.Controls.DataGridTextColumn  5+      $ Category��6-      MinWidth$	 200Q�6?   $
 auto 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6a   �� *
Category+  5,      $ Amount��6-   $	 100 6?    6M   �� *Amount+$ {0:n2}��  5-      $ Comment��6-   $
 300* 6?    6M   �� *	Comment+5/      50      �� 51   
   $��2��6   ��6    �� *IncomeList.EntryTotal+52      53      