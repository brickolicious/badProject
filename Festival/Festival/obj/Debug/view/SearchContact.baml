   M S B A M L   `   `   `  ����C  ?Festival, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BADProject.viewmodelBADProject.viewmodel  5   	   #    BADProject.view.SearchContact   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.24.16411, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7*cmd http://www.galasoft.ch/mvvmlight  5   	   0context"clr-namespace:BADProject.viewmodel  5   	     � Title$  SearchContact��5   	   $	��300��6   $	��450��6,    � DataContext 5	      *  $BADProject.viewmodel.SearchContactVM  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      �� 5      $
��0.5* �6   �� 5      �� 5       $
��0.3* �6   .+�5#   
   �� $��1��6   $��1��6    $��Search by name:��6-   �� 5$   
   $��3��6   $��4��6!   $��5��62   ��6F   �� *
SearchList+ �� View 5%      �� 5&      .P�5'      �� $
��Name��6%    �� Width$
 auto��63    �� DisplayMemberBinding 6@   �� *Name+�� 5(      $��Company��6%   $
 auto��66    6C   �� *	Company+�� 5*      $
��City��6%   $
 auto��63    6@   �� *City+�� 5+      $��E-mail��6%   $
 auto��65    6B   �� *Email+�� 5,      $��Phone��6%   $
 auto��64    6A   �� *Phone+�� 5-      $��	Cellphone��6%   $
 auto��68    6E   �� *	CellPhone+5.      50      �� 52   
   $��3��6   $��1��6"   $��2��6j   $��0,0,42,0q�6~   ��6/   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   .  (System.Windows.Interactivity.Interaction   Triggers 53      /  )System.Windows.Interactivity.EventTrigger  54      	   	EventName$	 KeyUp��6!   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 55      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6)   �� *SearchContactActionCommand+6X   56      .��57   &   58      5:      5;      