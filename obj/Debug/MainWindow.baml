   M S B A M L   `   `   `  ����J  FExpense_Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Expense_TrackerExpense_Tracker  5   	        Expense_Tracker.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:Expense_Tracker     5   	     � Title$  Expense Tracker��5   	   $	��500��6!   $
��auto��6.    � Icon$ yC:\Users\yusifn\Desktop\Misc_Work\Learning\Expense_Tracker\trunk\Post_XAML_Nutshell\Expense_Tracker\Images\DollarSign.ico��5   	    � DataContext 5	      *   $Expense_Tracker.MainWindow_ViewModel  5
   
   .��5      ]� .+�5   
   o� $	��Top=�6    o� 
IsMainMenu . .@�5      m� $
��File��6   .@�5      m� $
��Load��6    m� Command 6)   �� *LoadExpenseListCommand+m� 5      $
��Save��6    6)   �� *ExportAllCommand+5      m� 5      $��Navigate��6   .@�5      m� -   5        $��Expense Entries��5      6=   m� 5      -   5        $��Expense Categories��5      6=   m� 5      -   5        $��Income Entries��5      6=   m� 5      -   5        $��Income Categories��5      6=   m� 5      -   5        $��Analysis��5      6=   5      m� 5      $
��Help��6   5        � 5!   
   -   5          �Name$ 
_mainFrame��5!      $
��auto��6$   $
��Left=�61     � NavigationUIVisibility$ Hidden=�6G   5"      5#      