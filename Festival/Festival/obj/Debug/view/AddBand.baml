   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	       BADProject.view.AddBand   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.24.16411, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7*cmd http://www.galasoft.ch/mvvmlight  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   0context"clr-namespace:BADProject.viewmodel  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6F     � Title$  AddBand��5   	   $	��420��6   $��466.5��6&    � DataContext 5
      $  BADProject.viewmodel.AddBandVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��7* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.5* �6   �� 5      �� 5       $
��0.2* �6   .+�5#   
   �� $��0��6   $��Center=�6   $��Add a band to the list.��6:   $��1��6\   $	��122��6l   $��2��6x   $��	0,0,205,0q�6�   �� 5$   
   $��1��6   $��1��6    $��
Band name:��6-   $��0.308,0,0.192,0q�6B   �� 5%   
   $��1��6   $��2��6    $��Description:��6-   $��0.308,0,0.192,0q�6D   �� 5&   
   $��1��6   $��3��6    $��Twitter:��6-   $��0.308,0,0.192,0q�6@   �� 5'   
   $��1��6   $��4��6    $��	Facebook:��6-   $��0.308,0,0.192,0q�6A   �� 5(   
   $��1��6   $��6��6    $��Photo:��6-   $��0.308,0,0.192,0q�6>   �� 5*   
   -   5         ��Name$ txtName��5*      $��2��6�   $��1��6�   $��1��6�   ��6#   �� *BandToAdd.Name+ �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5+   
   -   5        $ txtDescription��5+      $��2��6�   $��2��6�   $��2��6�   ��6*   �� *BandToAdd.Description+ .  . $ PropertyChanged=�6�   �� 5,   
   -   5        $ 
txtTwitter��5,      $��2��6�   $��3��6�   $��3��6�   ��6&   �� *BandToAdd.Twitter+ .  . $ PropertyChanged=�6�   �� 5-   
   -   5        $ txtFacebook��5-      $��2��6�   $��4��6�   $��4��6�   ��6'   �� *BandToAdd.Facebook+ .  . $ PropertyChanged=�6�   �� 5.   
      buttonStyle#��[  6   $��2��66   $��6��6o   $��	0,0,0,179q�6|   $��5��6�   $��2��6�   ��6F   �� *ChoosePictureCommand+.��6�   Choose image6�   �� 5/   
   $��7��6   $��4��6   ._�50      �� -   5         ��Name$ imgBand��50      $��0,0,0,10q�6F   ��6&   �� *Photo.Source+6F   51      �� 54   
   -   5        	 ��Name$	 sendBtn��54   6   #��[  6   $��2��6g   $��7��6{   $��	0,179,0,0q�6�   $��	Voeg toe.��6�   $��1��6�   $��6��6�   $��2��6�   ��6G   �� *
AddToBands+6�   �� 55   
   $��1��6   $��5��6    $��Genres 1,2,3,...:��6-   $��0.308,0,0.192,0q�6I   �� 56   
   -   5        $ 	txtGenres��56      $��2��6�   $��5��6�   ��6%   �� *BandToAdd.GenresInText+ .  . $ PropertyChanged=�6�   57      58      