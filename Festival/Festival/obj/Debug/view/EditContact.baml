   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	   1clr-namespace:BADProject.viewBADProject.view  5   	   !    BADProject.view.EditContact   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6context"clr-namespace:BADProject.viewmodel     5   	   0viewnsclr-namespace:BADProject.view     5   	     � Title$  EditContact��5   	   $	��300��6   $	��477��6*    � DataContext 5      (  "BADProject.viewmodel.EditContactVM  5	   
    � 	Resources 5         BADProject.view.Contact   test��%   &	          5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5       $
��0.3* �6   �� 5!      $
��0.5* �6   �� 5"      �� 5#      $
��0.3* �6   .+�5&   
   �� $��0��6   $��Center=�6   $	��112��6:   $��1��6F   .��6W   Edit contact:6f   �� 5'   
   $��1��6   $��1��6    .��6-   Name:64   �� 5(   
   $��1��6   $��2��6    .��6-   
Company:67   �� 5)   
   $��1��6   $��3��6    .��6-   	Function:68   �� 5*   
   $��1��6   $��4��6    .��6-   City:64   �� 5+   
   $��1��6   $��5��6    .��6-   	E-mail:66   �� 5,   
   $��1��6   $��6��6    .��6-   Phone:65   �� 5-   
   $��1��6   $��7��6    .��6-   	Cellphone68   �� 50   
   -   5         ��Name$ lblID��50      $��2��6L   $��Center=�6\   $	��112��6y   ��6   �� *SelectedContactStatic.ID+6y   �� 51   
   -   5         ��Name$ txtName��51      $��2��6$   $��1��64   $��1��6�   ��6A   �� *SelectedContactStatic.Name+ �� ValidatesOnExceptions .  �� ValidatesOnDataErrors . 	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 52   
   -   5        $ 
txtCompany��52      $��2��6&   $��2��66   $��2��6�   ��6C   �� *SelectedContactStatic.Company+ .  . $	 PropertyChanged=�6�   �� 55   
   -   5        
 ��Name$
 
cboJobRole��55      $��2��6'   $��3��67    �� DisplayMemberPath$
 Name��6e   $��3��6  ��6D   �� *
TypeList+ �� SelectedItem 6~   �� *SelectedContactStatic.JobRole+ .  . $	 PropertyChanged=�6  �� 56   
   -   5        $ txtPlace��56      $��2��6$   $��4��64   $��4��6�   ��6A   �� *SelectedContactStatic.City+ .  . $	 PropertyChanged=�6�   �� 57   
   -   5        $ txtEmail��57      $��2��6$   $��5��64   $��5��6�   ��6A   �� *SelectedContactStatic.Email+ .  . $	 PropertyChanged=�6�   �� 58   
   -   5        $ txtPhone��58      $��2��6$   $��6��64   $��6��6�   ��6A   �� *SelectedContactStatic.Phone+ .  . $	 PropertyChanged=�6�   �� 59   
   -   5        $ txtCellPhone��59      $��2��6(   $��7��68   $��7��6�   ��6E   �� *!SelectedContactStatic.CellPhone+ .  . $	 PropertyChanged=�6�   �� 5;   
   -	   5         ��Name$ sendBtn��5;   6     buttonStyle#��[ 6   $��2��6n   $��9��6�   $��Edit Contact��6�   $��1��6�   $��8��6�   ��6G   �� *EditContactAction+6�   5<      5=      