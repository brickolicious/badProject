   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5          BADProject.view.Contact   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1vm"clr-namespace:BADProject.viewmodel     5      $��1010.248��5      $��580.919��60     � 	Resources  5	      (  "BADProject.viewmodel.EditContactVM 
  editVM��%   &	          5
   
   6,   5      .��5      �   	gridStyle#��[ 6    � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $
��0.4* �6   �� 5      $��3* �6   �� 5      $��2* �6   �� 5      $
��0.2* �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.8* �6   �� 5      $
��0.3* �6   �� 5      $
��0.8* �6   �� 5      $��3* �6   �� 5      $
��0.5* �6   .+�5!   
   �� $��Category��6   $��1��6#   $��1��64   $
��Left=�6A   $��Bottom=�6\   $��21.333(�6w   �� 5#   
   -   5         ��Name$ 
lstBxTypes��5#       �� DisplayMemberPath$
 Name��6|     listBoxStyle#��[ 6�   $��1��6�   $��2��6�   $��0,0,0,37q�6�   $��1��6�   ��6&   �� *ContactTypeLijst+ �� SelectedItem 6O   �� *SelectedContactType+6�   �� 5%   
   -   5         ��Name$ lstvwContacten��5%   �   $��3��6�   $��2��6�   $��2��6�   $��2��6�   ��6   �� *SelectedContactTypeLijst+ 6D   ��  �� Source# [   �� Path$ SelectedContact�	 �� View	 5'      �� 5(      .P�5)      �� $��ID��6%   
 �� Width$

 auto��61    �� DisplayMemberBinding 6>   �� *ID+�� 5*      $
��Name��6%   $

 auto��63    6@   �� *Name+�� 5+      $��Company��6%   $

 auto��66    6C   �� *	Company+�� 5,      $
��City��6%   $

 auto��63    6@   �� *City+�� 5-      $��E-mail��6%   $

 auto��65    6B   �� *Email+�� 5.      $��Phone��6%   $

 auto��64    6A   �� *Phone+�� 5/      $��	Cellphone��6%   $

 auto��68    6E   �� *	CellPhone+50      52      �� 54   
   $��3��6   $��1��6"   $��	0,22,0,23q�62   .+�55      �� $��0,0,0,10q�6     buttonStyle#��[ 6Q   $��Add category��6v   $��28��6�   $��Bottom=�6�   $��4��6�   ��6'   �� *AddContactTypeCommand+6�   �� 56      $��0,0,0,10q�6   #��[ 6T   $��5��6�   $��Delete category��6  $��28��6(  $��Bottom=�64  ��6'   �� *DeleteContactTypeCommand+��6y   ��  �� ElementName$ 
lstBxTypes��$ SelectedItem�{�6�   �� *SelectedItems.Count+$ 
lstBxTypes��64  57      �� 59   
   $��3��6   $��3��6%   $��Center=�62   $��	0,22,0,61q�6M   .+�5:      �� $��0,0,0,10q�6   #��[ 6I   $��Add contact��6n   $��28��6�   $��Bottom=�6�   $��6��6�   ��6'   �� *AddContactCom+6�   �� 5;      $��0,0,0,10q�6   #��[ 6O   $��Edit contact��6�   $��28��6�   $	��Top=�6�   $��7��6�   ��6(   �� *EditContactCommand+{�6t   �� *SelectedItems.Count+$ lstvwContacten��6�   �� 5=      $��0,0,0,10q�6   #��[ 6P   $��Remove contact��6�   $��28��6�   $��Bottom=�6�   $��8��6E  ��6'   �� *DeleteContactCommand+��6u   �� $ lstvwContacten��$ SelectedItem�{�6�   �� *SelectedItems.Count+$ lstvwContacten��6E  5>      �� 5?   
   $��Contacts��6   $��3��6#   $��1��64   $
��Left=�6A   $��Bottom=�6\   $��21.333(�6w   �� 5C   
   $��4��6   $��1��6!   #��[ 6W   $��Search by name��6|   $��28��6�   $��Center=�6�   $��Right=�6�   $	��0,6q�6�   $	��115��6�   $��3��6�   ��6.   �� *SearchContactCommand+6�   5F      5H      