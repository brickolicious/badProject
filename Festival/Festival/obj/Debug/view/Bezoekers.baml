   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5          BADProject.view.Bezoekers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1vm"clr-namespace:BADProject.viewmodel     5      $��1003.887��5      $��429.329��60     � 	Resources  5	      &   BADProject.viewmodel.EditOrderVM 
  editVM��%   &	          5
   
   6*   5      .��5      �   	gridStyle#��[ 6    � RowDefinitions 5   
   �� 5      �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $��3* �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��4.5* �6   �� 5      $
��0.5* �6   �� 5      �� 5      $
��0.5* �6   .+�5    
   �� $��Orders��6   $��1��6!   $
��Left=�63   $��Bottom=�6N   $��21.333(�6i   �� 5!   
   -   5         ��Name$ lstvwOrders��5!      $��1��6�   $��2��6�   $��5��6�   $��1��6�   ��6(   �� *
TicketList+ �� SelectedItem 6K   ��  �� Source# [   �� Path$ SelectedTicket� �� View 5"      �� 5#      .P�5$      �� $��PersonID��6%    �� Width$
 auto��67   	 �� DisplayMemberBinding	 6D   �� *TicketholderID+�� 5%      $
��Name��6%   $
 auto��63   	 6@   �� *Name+�� 5&      $��Email��6%   $
 auto��64   	 6A   �� *Email+�� 5'      $��Ticket��6%   $
 auto��65   	 6B   �� *TicketTypeProp.Name+�� 5(      $��Amount��6%   $
 auto��65   	 6B   �� *Amount+�� 5)      $��
Unit price��6%   $
 auto��69   	 6F   �� *TicketTypeProp.Price+5*      5,      �� 5-   
     buttonStyle#��[ 62   $
��Edit��6�   $��3��6�   $	��Top=�6�   $��4��6�   $��3��6�   ��6   �� *EditCommand+{�6W   �� *SelectedItems.Count+
 �� ElementName$
 lstvwOrders��6�   �� 5.   
   #��[ 6z   $��Delete��6�   $��3��6�   $	��Top=�6  $��6��6  $��	0,144,0,0q�6(  $��5��6;  ��6   �� *DeleteCommand+��63   �� $
 lstvwOrders��$ SelectedItem�{�6�   �� *SelectedItems.Count+$
 lstvwOrders��6;  �� 5/   
   #��[ 64   $��Search��6Y   $��3��6j   $	��Top=�6z   $��2��6�   $��2��6�   ��6   �� *SearchCommand+6�   �� 50   
   #��[ 6~   $��Export order��6�   $��3��6�   $��6��6  $��	0,0,0,144q�6  $��4��6-  ��6   �� *PrintOrderCommand+��67   �� $
 lstvwOrders��$ SelectedItem�{�6�   �� *SelectedItems.Count+$
 lstvwOrders��6-  51      54      