   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	   "    BADProject.view.RemoveGenres   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9
viewmodels"clr-namespace:BADProject.viewmodel     5   	     � Title$  RemoveGenres��5   	   $	��300��6   $	��300��6+    � DataContext 5	      (  "BADProject.viewmodel.RemoveGenreVM  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $��5* �6   �� 5      $
��0.1* �6   �� 5      $
��0.8* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��3* �6   �� 5      $
��0.3* �6   .+�5   
   �� -   5         ��Name$ genreLst��5      $��1��6$   $��1��64    �� DisplayMemberPath$
 Name��6d   ��6A   �� *
GenresList+6   �� 5   
   -   5        $��3��5   �   $��1��6�      buttonStyle#��[  6�   $��Remove genre��6  $��0,8,0,0q�6  ��6   �� *RemoveGenreActionCommand+��6>   ��  �� ElementName$ genreLst�� �� Path$ SelectedItem�{�6�   �� *SelectedItems.Count+$ genreLst��6,  5      5      