   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	   #    BADProject.view.AddTicketType   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6context"clr-namespace:BADProject.viewmodel     5   	     � Title$  AddTicketType��5   	   $	��200��6   $	��300��6,    � DataContext 5      *  $BADProject.viewmodel.AddTicketTypeVM  5   
   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $��0��6   $��Center=�6   $	��112��6:   $��Add ticket type��6F   $��1��6`   �� 5   
   $��1��6   $��1��6    $��Name:��6-   �� 5   
   $��1��6   $��2��6    $��Price:��6-   �� 5   
   $��1��6   $��3��6    $��Total:��6-   �� 5   
   $��0��6   $��5��6    $�� ��6-   $��2��68   �� 5!   
   -   5         ��Name$ 
lblOrderID��5!      $��2��6$   $��Center=�64   $��	79,0,49,0q�6Q   6g   �� 5"   
   -   5         ��Name$ txtName��5"      $��2��6�   $��1��6�   $��Stretch=�6�   $��1��6�   ��6$   �� *	Type.Name+ �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5#   
   -   5        $ txtPrice��5#      $��2��6�   $��2��6�   $��2��6�   ��6$   �� *
Type.Price+ .  . $ PropertyChanged=�6�   �� 5&   
   -   5        $ txtTotal��5&      $��2��6�   $��3��6�   $��3��6�   ��6$   �� *Type.TotalTickets+ .  . $ PropertyChanged=�6�   �� 5(   
   -   5        	 ��Name$	 sendBtn��5(   6      buttonStyle#��[  6   $��2��6j   $��5��6~   $��Add type��6�   $��1��6�   $��4��6�   ��6G   �� *AddTypeAction+6�   5)      5*      