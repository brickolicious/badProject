   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	       BADProject.view.AddStage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6context"clr-namespace:BADProject.viewmodel     5   	     � Title$  AddStage��5   	   $	��120��6   $	��200��6'    � DataContext 5      %  BADProject.viewmodel.AddStageVM  5   
   6   .��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $��2* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��1��6   $��2��6    .��64   Enter the stagename:6J   �� 5   
   -   5        $��txtStage��5      $��1��6�   $��1��6�   $��1��6�   ��6"   �� *StageToCreate.Name+ �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ btnAddStage��5   6      buttonStyle#��[  6   $��2��6k   $��1��6�   $��2��6�   ��6K   �� *CreateStage+.��6�   
Add stage.6�   5      5      