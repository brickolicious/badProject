   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   C ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel 5   	   M IClassLibraryModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:ClassLibraryModels;assembly=ClassLibraryModelsClassLibraryModels 5   	      BADProject.view.AddLineUp   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   0context"clr-namespace:BADProject.viewmodel  5   	   Imodels<clr-namespace:ClassLibraryModels;assembly=ClassLibraryModels  5   	     � Title$  	AddLineUp��5   	   $	��300��6   $	��383��6(    � DataContext 5
      &  BADProject.viewmodel.AddLineUpVM  5   
    � 	Resources 5      " BADProject.viewmodel.BandsVM 
  bandVM��%   &	          5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      �� 5       �� 5!      $
��0.2* �6   .+�5$   
   �� $��Add a line-up element.��6   $��2��61   $��Center=�6F   $��1��6c   $��	57,0,53,0q�6s   �� 5%   
   $��Date:��6   $��1��6    $��1��6-   �� 5&   
   $��From:��6   $��2��6    $��1��6-   �� 5'   
   $��Until:��6   $��3��6!   $��1��6.   �� 5(   
   $��Stage:��6   $��4��6!   $��1��6.   �� 5)   
   $��Band:��6   $��5��6    $��1��6-   (  "System.Windows.Controls.DatePicker  5+   
   -   5          Name$ 
datePicker��5+      $��2��6)   $��1��69   $��1��6�      SelectedDate 6F   �� *LineUpToAdd.Date+ �� Mode$ TwoWay=� �� ValidatesOnExceptions . 	 �� ValidatesOnDataErrors	 . 
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   &   Xceed.Wpf.Toolkit.DateTimeUpDown  5,   
   -   5          Name$ 
fromPicker��5,      $��2��64   $��2��6D      Format$ Custom=�6Q      FormatString$ HH:mm��6a   $��2��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6v   �� *LineUpToAdd.From+ . 	 . $
 PropertyChanged=�6�     5-   
   -   5        $ untilPicker��5-      $��2��64   $��3��6D   $ Custom=�6Q   $ HH:mm��6a   $��3��6�    6w   �� *LineUpToAdd.Until+ . 	 . $
 PropertyChanged=�6�   �� 5.   
   -   5         ��Name$ cboStage��5.      $��2��6%   $��4��65    �� DisplayMemberPath$
 Name��6d   $��4��6  ��6B   �� *	StageList+ �� SelectedItem 6}   �� *LineUpToAdd.Stage+ . 	 . $
 PropertyChanged=�6  �� 5/   
   -   5        $ cboBand��5/      $��2��6$   $��5��64   $
 Name��6b   $��4��6�   ��6A   �� *
BandList+ 6{   �� *LineUpToAdd.Band+ . 	 . $
 PropertyChanged=�6�   �� 50   
   -   5         ��Name$ btnSend��50   6     buttonStyle#��[ 6   $��7��6g   $��2��6t   $��0,5,0,0q�6�   $��5��6�   $��1��6�   ��6G   �� *AddToLineup+.��6�   Add line-up6�   52      53      