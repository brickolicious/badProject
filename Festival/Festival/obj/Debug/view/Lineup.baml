   M S B A M L   `   `   `  ����  Festival    BADProject.view.Lineup   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $
��1024��5      $	��600��6,   .��5      �    	gridStyle#��[  6   $��
0,10px,0,0q�6.     � ColumnDefinitions  5   
   �� 5      $��3* �6   �� 5      $��6* �6   �� 5      $��3* �6   �� 5      $
��0.5* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $	��53* �6   �� 5      $	��47* �6   �� 5      $	��47* �6   �� 5      $	��23* �6   �� 5      $	��46* �6   �� 5      $	��45* �6   �� 5      $	��46* �6   �� 5      $
��105* �6   �� 5      $	��48* �6   �� 5      $	��45* �6   �� 5       $	��47* �6   �� 5!      $	��47* �6   .+�5$   
   �� $��Line-up��6   $��0��6"   $��Center=�64   $��Center=�6Q   $��22(�6l   $��1��6z   �� 5&   
   $��2��6   $��0��6!   $	��Top=�61   $��Center=�6I   $��20(�6f   ��6t   �� *SelectedDay+ �� StringFormat$ {0:dd/MM/yyyy}���� 5(   
   -   5         ��Name$ btnDate��5(      $��4��6"   $��1��62   $��Set start day��6?     buttonStyle#��[ 6W   $��3��6�   �� 5)   
   -   5        $ 	btnSubmit��5)      $��4��6H   $��1��6X   $��Set day��6e   #��[ 6w   $y�Hidden=�6�   ��6$   �� *SetStartCommand+6�   (  "System.Windows.Controls.DatePicker  5*   
   -   5          Name$ datePick��5*      $��4��6'   $��2��67   $y�Hidden=�6D   6Z   �� 5.   
   #��[ 65   $��	Add stage��6Z   $��5��6o   $��4��6|   $��0,10,0,7q�6�   $��5��6�   ��6   �� *AddStageCommand+6�   �� 5/   
   #��[ 66   $��
Remove day��6[   $��8��6r   $��4��6   $��0,10,0,9q�6�   $��7��6�   ��6   �� *DeleteDayCommand+6�   �� 50   
   #��[ 63   $��Add day��6X   $��4��6j   $��0,10,0,8q�6z   $��4��6�   $��6��6�   ��6   �� *AddDayCommand+6�   �� 52   
   #��[ 63   $��Add line-up��6X   $��4��6n   $��0,10,0,7q�6~   $��6��6�   $��4��6�   ��6   �� *ShowAddLineUp+6�   �� 55   
   $��2��6   $��Disabled=�6(   $
��Auto=�6O   $��Stretch=�6u   $��2��6�   $��1��6�   $��1��6�   $��0,9,0,10q�6�   $��1��6�   .��56      �� -   5         ��Name$ dagenStackPanel��56      $��0q�63    �� Orientation$ 
Horizontal=�6>   .+�57      �� ��6   �� *	DatesList+��58      �� 59      .R�5:      �  � Orientation$ 
Horizontal=�6(   5;      ��5>      �� 5@      .R�5B      ��   dagButtonStyle#��[ 6%   ��6N   �� *	DayOfWeek+
 � Tag 6l   �� *Date+��6�   �� *DataContext.ShowLineUpCommand+	 �� RelativeSource	 �� 
 �� AncestorType"
 ����6�   �� *Date+5E      5G      5K      5L      �� 5Q   
   
���   �$��2q�6%   $��4��69   $��3��6F   $��6��6Z   ._�5R      �� -   5         ��Name$ 
scrlViewer��5R      $
��Auto=�60   $
��Auto=�6S   .��5S      ��   	lstLineup#��[ 6g    
 stkPnl#��[ 6�   $��2��6�   ��6    �� *	StageList+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5U      5V      �� 5W   
   #��[ 68   $��Remove stage��6]   $��9��6v   $��4��6�   $��0,6,0,10q�6�   $��8��6�   ��6   �� *DeleteStageCommand+6�   5^      5_      