   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	        BADProject.view.AddContact   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6context"clr-namespace:BADProject.viewmodel     5   	     � Title$  Add Contact��5   	   $	��275��6   $��407.5��6*    � 	Resources 5         
stackStyle �� 
TargetType��%+   &	        �� 5   
   " ��6#   5
      5       � DataContext 5      '  !BADProject.viewmodel.AddContactVM  5   
   6!   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5       $
��0.5* �6   �� 5!      �� 5"      $
��0.3* �6   .+�5%   
   �� $��0��6   $��Center=�6   $��1��6:   $��0,0,6,0q�6J   .��6[   Create contact:6l   �� 5&   
   $��1��6   $��1��6    $��Name:��6-   �� 5'   
   $��1��6   $��2��6    $��Company:��6-   �� 5(   
   $��1��6   $��3��6    $��	Function:��6-   �� 5)   
   $��1��6   $��4��6    $��City:��6-   �� 5*   
   $��1��6   $��5��6    .��6-   	E-mail:66   �� 5+   
   $��1��6   $��6��6    $��Phone:��6-   �� 5,   
   $��1��6   $��7��6    $��
Cellphone:��6-   �� 5.   
   -   5         ��Name$ txtName��5.      $��2��6�   $��1��6�   $��1��6�   ��6#   �� *ContactToAdd.Name+ �� ValidatesOnExceptions .  �� ValidatesOnDataErrors . 	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5/   
   -   5        $ 
txtCompany��5/      $��2��6�   $��2��6�   $��2��6�   ��6&   �� *ContactToAdd.Company+ .  . $	 PropertyChanged=�6�   �� 50   
   -   5        
 ��Name$
 
cboJobRole��50      $��2��6�   $��3��6�    �� DisplayMemberPath$
 Name��6�   $��3��6   �� SelectedItem 6'   �� *ContactToAdd.JobRole+ .  . $	 PropertyChanged=���6�   �� *
TypeList+6  �� 51   
   -   5        $ txtPlace��51      $��2��6�   $��4��6�   $��4��6�   ��6$   �� *ContactToAdd.City+ .  . $	 PropertyChanged=�6�   �� 52   
   -   5        $ txtEmail��52      $��2��6�   $��5��6�   $��5��6�   ��6$   �� *ContactToAdd.Email+ .  . $	 PropertyChanged=�6�   �� 53   
   -   5        $ txtPhone��53      $��2��6�   $��6��6�   $��6��6�   ��6$   �� *ContactToAdd.Phone+ .  . $	 PropertyChanged=�6�   �� 54   
   -   5        $ txtGSM��54      $��2��6�   $��7��6�   $��7��6�   ��6"   �� *ContactToAdd.CellPhone+ .  . $	 PropertyChanged=�6�   �� 56   
   -   5         ��Name$ sendBtn��56        buttonStyle#��[ 6"   $��2��6m   $��9��6�   $��1��6�   $��Add contact��6�   $��8��6�   ��6G   �� *AddContactAction+6�   57      58      