   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	   $    BADProject.view.AddContactType   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6context"clr-namespace:BADProject.viewmodel     5   	     � Title$  AddContactType��5   	   $	��150��6    $	��300��6-    � DataContext 5      +  %BADProject.viewmodel.AddContactTypeVM  5	   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��2* �6   �� 5      $
��0.5* �6    � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $
��1.5* �6   �� 5      $
��0.3* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��1��6   $��Center=�6    $��Enter new category:��6=   �� 5   
   -   5         ��Name$ txtType��5      $��1��6�   $��1��6�   $��1��6�   ��6#   �� *	Name.Name+ �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5           buttonStyle#��[  5   4   $��1��6�   $��2��6�   $��2��6�   $��0,19,0,0q�6�   $��2��6�   ��6   �� *AddTypeCommand+��6Y   ��  �� ElementName$ txtType��	 �� Path$
	 Text�.��6�   Add category6  5      5       