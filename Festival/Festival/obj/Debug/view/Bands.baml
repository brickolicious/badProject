   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5          BADProject.view.Bands   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :viewModelns"clr-namespace:BADProject.viewmodel     5      $	��788��5   7   $	��473��6C     � 	Resources  5      %  BADProject.viewmodel.EditBandVM   editInst��%   &	          5   
   6!   5      .��5      �   	gridStyle#��[ 6   $��-114,-34,-88,0q�6.    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      $��4* �6   �� 5      �� 5      �� 5      $
��0.2* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��12* �6   �� 5      $
��0.1* �6   �� 5      $��5* �6   �� 5       $
��0.1* �6   .+�5"   
   �� $��Bands��6   $��1��6    $
��Left=�62   $��Bottom=�6M   $��21.333(�6h   �� 5#   
   -   5         ��Name$ 
lstvwBands��5#      $��1��6'   $��2��67   $��5��6D   $��1��6�   ��6U   �� *Bands+ �� SelectedItem 6s   ��  �� Source# [   �� Path$ SelectedBandNonStatic� �� View 5$      �� 5%      .P�5&      �� $
��Name��6%    �� Width$
 auto��63   	 �� DisplayMemberBinding	 6@   �� *Name+�� 5'      $��Description��6%   $ 430px��6:   	 6I   �� *Description+�� 5*      $��Genres��6%   $
 auto��65   	 6B   �� *GenresInText+5+      5-      �� 5/   
     buttonStyle#��[ 68   $��Add band��6]   $��3��6p   $��35��6�   $	��120��6�   $��2��6�   $��Center=�6�   $��Stretch=�6�   $��2��6�   $��
0,15,152,0q�6�   ��6   �� *AddBandShowCommand+6�   �� 50   
   #��[ 6�   $��	Edit band��6�   $��3��6�   $��36��6  $	��120��6  $��3��6  $��Center=�6,  $��Stretch=�6G  $��
1,14,151,0q�6e  $��3��6y  ��6   �� *EditBandCommand+��65   �� 
 �� ElementName$
 
lstvwBands��$ SelectedItem�{�6{   �� *SelectedItems.Count+$
 
lstvwBands��6y  �� 51   
   #��[ 6�   $��Delete band��6�   $��3��6�   $��35��6  $	��120��6  $��3��6#  $��Center=�60  $��Stretch=�6K  $��6��6i  $��
152,14,0,1q�6v  ��6   �� *DeleteBandCommand+��67   �� $
 
lstvwBands��$ SelectedItem�{�6}   �� *SelectedItems.Count+$
 
lstvwBands��6v  �� 54   
   $��2��6�   $��Stretch=�6�   $��10q�6�   $��4��6�   $��Stretch=�6�   $��3��6�   ��6   �� # [  $# SelectedBandNonStatic.Picture�  ImgConverter �� 	Converter# [ 6�   �� 55   
   $��0q�6S   $��1��6�   $��1��6�   $��30��6�   $��30��6�   $��Bottom=�6�   $��right=�6   $��4��6  $��0,0,50,0q�6*  {�6   �� *SelectedItems.Count+$
 
lstvwBands����6g   �� # [  $ FacebookCommand�.��56      � $��30��6   $��30��6   ��57      �� 58       �� ImageSource$$ ..\Content\Images\facelogo.png��6!   5:      5;      �� 5<   
   $��0q�6S   $��1��6�   $��1��6�   $��30��6�   $��30��6�   $��Bottom=�6�   $��right=�6   $��5��6  {�6   �� *SelectedItems.Count+$
 
lstvwBands����6g   �� # [  $ TwitterCommand�.��5=      � $��30��6   $��30��6   ��5>      �� 5?      $$ ..\Content\Images\twitlogo.jpg��6!   5A      5B      �� 5D   
   #��[ 6<   $��2��6a   $��3��6n   $��Delete genre��6~   $��35��6�   $	��120��6�   $��
152,15,0,0q�6�   ��6   �� *ShowRemoveGenreCommand+6�   5F      5G      