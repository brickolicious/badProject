   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	       BADProject.view.EditOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6context"clr-namespace:BADProject.viewmodel     5   	     � Title$  	EditOrder��5   	   $	��300��6   $	��446��6(    � DataContext 5      &   BADProject.viewmodel.EditOrderVM  5   
   6    .��5	      � -   5         � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $
��0.5* �6   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� -   5         ��Name$ sendBtn��5   6      buttonStyle#��[  6   $��2��6n   $��8��6�   $��
Edit order��6�   $��1��6�   $��3��6�   $��0,25,0,0q�6�   $��2��6�   ��6G   �� *EditActionCommand+6�   �� 5   
   -   5         ��Name$ cboTicketType��5      $��2��6*   $��4��6:    �� DisplayMemberPath$
 Name��6h   $��1��6�   ��6G   �� *
TypeList+ �� SelectedIndex 6�   �� *TicketTypePosition+6�   �� 5   
   -   5         ��Name$ 	txtAmount��5      $��2��6%   $��5��65   $��2��6�   ��6B   �� *SelectedTicketStatic.Amount+	 �� ValidatesOnExceptions	 . 
 �� ValidatesOnDataErrors
 .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5"   
   $��0��6   $��Center=�6   $��0,0,34,0q�6:   $��70��6L   $��Edit order:��6W   $��1��6m   �� 5#   
   $��1��6   $��1��6    $��	Person ID��6-   �� 5$   
   $��1��6   $��2��6    $��Name:��6-   �� 5%   
   $��1��6   $��3��6    $��E-mail:��6-   �� 5&   
   $��1��6   $��5��6    .��6-   	Amount:66   �� 5)   
   -   5         ��Name$ 
lblOrderID��5)      $��2��6U   $��Center=�6e   $	��112��6�   ��6$   ��  �� Path$ SelectedTicketStatic.ID�6�   �� 5*   
   -   5        $ lblPersonID��5*      $��2��6&   $��1��66   $��Center=�6{   $	��112��6�   ��6C   �� *%#SelectedTicketStatic.TicketholderID+6�   �� 5+   
   -   5        $ lblName��5+      $��2��6!   $��2��61   ��6>   �� *SelectedTicketStatic.Name+�� 5.   
   -   5        $ lblEmail��5.      $��2��6"   $��3��62   ��6?   �� *SelectedTicketStatic.Email+�� 50   
   $��1��6   $��4��6    $��Type:��6-   51      52      