   M S B A M L   `   `   `  ����K  GFootballTeamsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FootballTeamsAppFootballTeamsApp  5   	   !    FootballTeamsApp.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FootballTeamsApp     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��600��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $ ��Назва команди:��6   $��0��6)   $��0��66   $��5q�6F   �� 5   
   -   5         ��Name$ TeamNameTextBox��5      $��0��6+   $��1��68   $��5q�6H   �� 5   
   $ ��Загальний бал:��6   $��1��6)   $��0��66   $��5q�6F   �� 5    
   -   5        $ TotalScoreTextBox��5       $��1��6-   $��1��6:   $��5q�6J   �� 5"   
   $��Забиті голи:��6   $��2��6'   $��0��64   $��5q�6D   �� 5#   
   -   5        $ GoalsScoredTextBox��5#      $��2��6.   $��1��6;   $��5q�6K   �� 5%   
   $"��Пропущені голи:��6   $��3��6*   $��0��67   $��5q�6G   �� 5&   
   -   5        $ GoalsConcededTextBox��5&      $��3��60   $��1��6=   $��5q�6M   �� 5(   
   -   5        $!��Додати команду��5(      $��4��6*   $��0��67   $��2��6G   $��5q�6[   6f   �� 5*   
   $ ��Список команд:��6   $��0��6)   $��2��66   $��5q�6F   �� 5+   
   -   5         ��Name$ TeamsListBox��5+      $��1��6(   $��2��65   $��4��6E   $��2��6V   $��5q�6j   6u   �� 5-   
   $1��+Інформація про команду:��6   $��5��62   $��0��6?   $��4��6O   $��5q�6c   �� 5.   
   -   5         ��Name$ TeamInfoTextBlock��5.      $��6��6/   $��0��6<   $��4��6L   $��5q�6`   $
��Wrap=�6k   �� 50   
   $*��$Результати відбору:��6   $��7��6.   $��0��6;   $��4��6K   $��5q�6_   �� 51   
   -   5        $ SelectionResultsTextBlock��51      $��8��67   $��0��6D   $��4��6T   $��5q�6h   $
��Wrap=�6s   �� 53   
   -	   5        $ AverageScoreTextBlock��53      $��9��63   $��0��6@   $��4��6P   $��5q�6d   �� 54   
   -
   5        $! SelectedTeamsCountTextBlock��54      $��10��69   $��0��6G   $��4��6W   $��5q�6k   55      56      