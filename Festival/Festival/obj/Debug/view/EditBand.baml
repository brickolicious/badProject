   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	       BADProject.view.EditBand   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.24.16411, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7*cmd http://www.galasoft.ch/mvvmlight  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   0context"clr-namespace:BADProject.viewmodel  5   	     � Title$  EditBand��5   	   $	��420��6   $	��476��6'    � DataContext 5      %  BADProject.viewmodel.EditBandVM  5	   
   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��7* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.6* �6   �� 5      �� 5      $
��0.2* �6   .+�5   
   �� $��0��6   $��Center=�6   $��Edit details of band:��6:   $	��112��6Z   $��1��6f   $��0,0,16,0q�6v   �� 5    
   $��1��6   $��1��6    $��
Band name:��6-   �� 5!   
   $��1��6   $��2��6    $��Description:��6-   �� 5"   
   $��1��6   $��3��6    $��Twitter:��6-   �� 5#   
   $��1��6   $��4��6    $��	Facebook:��6-   �� 5$   
   $��1��6   $��6��6    $��Photo:��6-   �� 5&   
   -   5         ��Name$ lblID��5&      $��2��6�   ��6   �� *SelectedBand.ID+ �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5'   
   -   5        $ lblName��5'      $��2��6�   $��1��6�   ��6"   �� *SelectedBand.Name+ .  . $ PropertyChanged=�6�   �� 5(   
   -   5         ��Name$ txtDescription��5(      $��2��6�   $��2��6�   $��1��6�   ��6*   �� *SelectedBand.Description+ .  . $ PropertyChanged=�6�   �� 5)   
   -   5        $ 
txtTwitter��5)      $��2��6�   $��3��6�   $��2��6�   ��6&   �� *SelectedBand.Twitter+ .  . $ PropertyChanged=�6�   �� 5*   
   -   5        $ txtFacebook��5*      $��2��6�   $��4��6�   $��3��6�   ��6'   �� *SelectedBand.Facebook+ .  . $ PropertyChanged=�6�   �� 5+   
   $��7��6   $��4��6   	 J� 	AllowDrop	 . .  (System.Windows.Interactivity.Interaction
   Triggers
 5,      /  )System.Windows.Interactivity.EventTrigger  5-         	EventName$
 Drop��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5.      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6)   �� *PictureCommand+6L   5/      51      �� 52   
   -   5         ��Name$ sendBtn��52   C      buttonStyle#��[  6   $��6��66   $��2��6x   $��8��6�   $��0,0,0,-1q�6�   $��	Edit band��6�   $��1��6�   ��6T   �� *EditBandAction+6�   �� 53   
   $��1��6   $��5��6    $��Genres 1,2,3,...:��6-   �� 54   
   -   5        $ 	txtGenres��54      $��2��6�   $��5��6�   $��4��6�   ��6%   �� *SelectedBand.GenresInText+ .  . $ PropertyChanged=�6�   �� 55   
   #��[  6   $��2��6_   $��6��6o   $��5��6|   ��66   �� *ChoosePictureCommand+.��6�   	New image6�   �� 56   
   $��7��6   $��4��6   ._�57      �� -   5         ��Name$ imgBand��57      ��6'   �� *Pic+ .  . $ PropertyChanged=�58      59      5:      