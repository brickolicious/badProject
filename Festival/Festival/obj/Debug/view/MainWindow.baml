   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	   1clr-namespace:BADProject.viewBADProject.view  5   	       BADProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1vm"clr-namespace:BADProject.viewmodel     5   	   +vclr-namespace:BADProject.view     5   	      windowStyle#��[  5   	     � Icon$!  ..\Content\Images\Icoon.png��5   	    � DataContext 5	      (  "BADProject.viewmodel.ApplicationVM  5
   
    � 	Resources 5       �� DataType#  BADProject.viewmodel.LineupVM   BADProject.view.Lineup"  BADProject.viewmodel.BandsVM   BADProject.view.Bands$  BADProject.viewmodel.ContactVM   BADProject.view.Contact'  !BADProject.viewmodel.ReserverenVM 	   BADProject.view.Reserveren&
   BADProject.viewmodel.BezoekersVM   BADProject.view.Bezoekers��%w  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      �� 5   
   " 
 6   .R�5        5      5      .��5      � $��0q�6    � RowDefinitions 5!   
   �� 5"      $	��29* �6   �� 5#      $
��223* �6   .+�5&   
   ��  
 header#��[ 65   ��6   �� *Pages+��5(      �� 5)      .R�5*      �  � Orientation$ 
Horizontal=�6    5+      ��5.      �� 5/      .R�50      � $ 
Horizontal=�6    .+�51      ��   
MenuButton#��[ 6!   ��6E   �� *Name+��6^   �� *DataContext.ChangePageCommand+ �� RelativeSource ��  �� AncestorType" ���6�   �� 52      53      55      �� 58   
   $��1��69   ��6   �� *CurrentPage+69   59      5:      