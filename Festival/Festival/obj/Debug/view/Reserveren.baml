   M S B A M L   `   `   `  ����  Festival     BADProject.view.Reserveren   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.24.16411, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7*cmd http://www.galasoft.ch/mvvmlight  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      $��1010.248��5      $��561.837��60   .��5      �    	gridStyle#��[  6   $��-6,0,0,0q�6.     � RowDefinitions  5   
   �� 5      $
��111* �6   �� 5      $	��27* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��87* �6   �� 5      $	��31* �6   �� 5      $	��31* �6   �� 5      $
��136* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��3* �6   �� 5      $
��0.3* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $
��0.3* �6   �� 5       $��3* �6   �� 5!      $
��0.3* �6   .+�5#   
   �� $��Tickets��6   $��1��6"   $
��Left=�62   $��Bottom=�6M   $��21.333(�6h   $��38��6z   $��74��6�   �� 5%        
labelStyle#��[ 6   $��Name and lastname:��68   $��Center=�6U   $��3��6p   $��2��6�   �� 5&      #��[ 6   $��E-mail:��68   $��Center=�6J   $��3��6e   $��3��6u   �� 5'      #��[ 6   $��Amount:��68   $��Center=�6J   $��3��6e   $��4��6u   �� 5(      #��[ 6   $��Type:��68   $��Center=�6H   $��3��6c   $��5��6s   �� 5,   
   -   5         ��Name$ txtName��5,      $��4��6�   $��2��6�    �� TextWrapping$
 Wrap=�6�   $��Center=�6�   $��1��6�   ��6$   �� *TicketOrder.Name+ �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5-   
   -   5        $ txtEmail��5-      $
 Wrap=�6�   $��4��6�   $��3��6�   $��Center=�6�   $��2��6�   ��6%   �� *TicketOrder.Email+ .  . $ PropertyChanged=�6�   �� 5.   
   -   5        $ 	txtAmount��5.      $
 Wrap=�6�   $��4��6�   $��4��6�   $��Center=�6�   $��3��6�   ��6&   �� *TicketOrder.Amount+ .  . $ PropertyChanged=�6�   �� 5/   
   -   5         ��Name$ cboType��5/       �� DisplayMemberPath$
 Name��6�   $��4��6�   $��5��6  $��Center=�6  $��4��6*  ��6$   �� *TicketTypeList+	 �� SelectedItem	 6K   �� *TicketOrder.TicketTypeProp+ .  . $ PropertyChanged=�67  �� 51   
   -   5        
 ��Name$
 btnSend��51        buttonStyle#��[ 6I   {�.  $��Order��6�   $��4��6�   $��7��6�   $��0,0,0,3q�6�   $��5��6�   ��6"   �� *PlaceOrderCommand+6�   �� 52   
   -   5         ��Name$ lstvwTickets��52      $��1��6)   $��2��69   $��5��6F   $��0,0,0,4q�6   $��6��6�   ��6X   �� *TicketTypeList+ �� View 53      �� 54      .P�55      �� $��ID��6%    �� Width$
 auto��61    �� DisplayMemberBinding 6>   �� *ID+�� 56      $
��Type��6%   $
 auto��63    6@   �� *Name+�� 57      $��Price��6%   $
 auto��64    6A   �� *Price+�� 58      $��	Available��6%   $
 auto��68    6E   �� *AvailableTickets+�� 59      $��Total��6%   $
 auto��64    6A   �� *TotalTickets+5:      5<      �� 5=   
   -   5        $ 
lstvwUsers��5=      $��6��6'   $��2��67   $��0,27,0,2q�6�   $��6��6�   $��10��6�   ��6E   �� *
FilterList+	 6h   �� *TicketOrder+ �� Mode$ Default=� 5>      �� 5?      .P�5@      �� $
��Name��6%   $
 auto��63    6@   �� *Name+�� 5A      $��Email��6%   $
 auto��64    6A   �� *Email+5B      5D      �� 5E   
   $��6��6   $��2��6"   $��0,0,0,6q�6p   $��9��6�   ��6/   �� *
SearchText+$ PropertyChanged=�.��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5F      /  )System.Windows.Interactivity.EventTrigger  5G         	EventName$ KeyUp��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5H      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6)   �� *SearchCommand+6K   5I      .��5J   &   5K      �� 5L   
   $��Order��6   $��3��6!   $
��Left=�61   $��Bottom=�6L   $��21.333(�6g   $��38��6y   $��89��6�   �� 5M   
   $��Search��6   $��6��6!   $
��Left=�61   $��Bottom=�6L   $��21.333(�6g   $��38��6y   $��89��6�   �� 5N   
   -   5        $
 btnAdd��5N      #��[ 6E   $��Add ticket type��6j   $��1��6�   $
��Auto��6�   $��0,1,88,2q�6�   $��7��6�   $��7��6�   ��6!   �� *AddTypeCommand+6�   �� 5O   
   -	   5        $
 	btnDelete��5O      #��[ 6�   $��Delete type��6�   $��1��6  $��28��6"  $��0,3,88,0q�6.  $��8��6@  $	��Top=�6M  $��8��6e  ��6$   �� *DeleteTypeCommand+��6K   ��  �� ElementName$ lstvwTickets�� �� Path$ SelectedItem�{�6�   �� *SelectedItems.Count+$ lstvwTickets��6e  5P      5S      