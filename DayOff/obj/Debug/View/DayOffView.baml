   M S B A M L   `   `   `  ����A  =DayOff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DayOff.ViewModelDayOff.ViewModel  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      N Jbutterfly.com.mongo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:butterfly.com.mongo;assembly=butterfly.com.mongobutterfly.com.mongo 5      +clr-namespace:DayOff.ModelDayOff.Model  5	          DayOff.View.DayOffView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4	viewModelclr-namespace:DayOff.ViewModel     5      6sys&clr-namespace:System;assembly=mscorlib     5      Pmongo>clr-namespace:butterfly.com.mongo;assembly=butterfly.com.mongo     5      ,modelclr-namespace:DayOff.Model     5	        � 	Resources  5
      &    DayOff.Model.VisibilityConverter  5   
      Key	converter  68   $   DayOff.Model.DateTimeConverter  5   
   dateTimeConverter  6>   �� 5   
   
filterText   �� 
TargetType" ��6#   .�5      ��  �� Property � �� �� Value$ 2q�6(   �� 5       � ��$ 12q�6'   �� 5       � ��$ Stretch=�62   �� 5       � ��$ Stretch=�64   �� 5       � ��
 �   �6,   �� 5       � ��$ 16(�6)   �� 5       � ��$	 200��6)   5      �� 5   
   itemStyleHead  " ��6&   .�5      ��  � ��$ 14(�6)   66   �� 5       � ��
 �  ��6+   �� 5       �@��Padding$ 5,1,1,5q�6(   5      �� 5   
   itemStyleHeadSec  " ��6)   .�5      ��  � ��$ 18(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 �   �6+   �� 5        �@��Padding$ 5,1,1,5q�6(   5!      �� 5"   
   itemStyleHeadState  " ��6+   .�5#      ��  � ��$ 18(�6)   �� 5$       � ��$
 Bold"�6+   �� 5%       � ��
 �   �6+   �� 5&       �@��Padding$ 5,1,1,5q�6(   5'      �� 5(   
   itemStyleHeadBox  " ��6)   .�5)      ��  � ��$ 14(�6)   66   �� 5*       � ��
 �  ��6+   �� 5+       � ��$ 5,1,1,5q�6(   5,      �� 5-   
   itemStyleEditHead  " ��6*   .�5.      ��  � ��$ 14(�6)   66   �� 5/       � ��
 �  ��6+   �� 50       � ��$ 5,1,1,5q�6(   51      �� 52   
   itemStyleRow  " ��6%   .�53      ��  � ��$ 10(�6)   66   �� 54       � ��
 �   �6+   �� 55       �@��Padding$ 5,1,1,5q�6(   56      �� 57   
   itemStyleRowEdit  " ��6)   .�58      ��  � ��$ 10(�6)   66   �� 59       � ��
 �   �6+   �� 5:       � ��$ 5,1,1,5q�6(   5;      S� 5<   
    S� 
MethodName$ 	GetValues��6    S� 
ObjectType  System.Enum"  5=      EntryTypeProvider   S� MethodParameters 5?      M� 5@       M� TypeName$ mongo:DayOffType��6   5B      �� 5C   
   readItem  .R�5D      �� $��border��6   
������  �� CornerRadius$ 5��6<   	 �� Padding$	 1q�6M   ._�5E      � 
 � RowDefinitions
 5F      �� 5G      .+�5J      � $��0��6    � ColumnDefinitions 5K      �� 5L      $	��120 �6/   �� 5M      $��50 �6/   �� 5N      $��80 �6/   �� 5O      $��* �6/   .+�5Q      ��  ��Name$
 date��5S      $��0��5R      $��Stretch=�5U      $��Center=�5V        itemStyleHead#��[ 5W      ��5T      �� *Date+ �� StringFormat$ {0:dd MMMM yyyy}��5W      �� 5Y      $ state��5Z      $��1��5[      $��Center=�5]      $��Center=�5^        itemStyleRow#��[ 5_      ��5\      �� *State+5_      �� 5`      $
 type��5a      $��2��5b      $��Center=�5d      $��Center=�5e      #��[ 5f      ��5c      �� *Type+5f      5n      5p      5q      5r      �� 5s   
   
updateItem  .R�5t      �� $��border��6   
������ $ 5��6<   $	 1q�6M   ._�5u      � 
 5v      �� 5w      .+�5}      � $��1��6    5~      �� 5      $	��120 �6/   �� 5�      $��50 �6/   �� 5�      $��80 �6/   �� 5�      $��* �6/   .+�5�      (  "System.Windows.Controls.DatePicker  $��0��5�         SelectedDateFormat$ Short=�5�      $��Stretch=�5�      $��Center=�5�         SelectedDate 5�      �� *Date+5�      �� 5�       ��Name$ state��5�      $��1��5�      $��Center=�5�      $��Center=�5�      ��5�      �� *State+5�      �� 5�       ��Name$
 type��5�      $��2��5�      $��Center=�5�      $��Center=�5�      $��Stretch=�5�      ��5�      ��   EntryTypeProvider �� Source# [  �� SelectedItem 5�      �� *Type+5�      5�      5�      5�      5�      .   (DayOff.Model.DayItemDataTemplateSelector  5�   
   itemTemplateSelector    readItem   ViewDataTemplate# [ 5�        
updateItem   EditDataTemplate# [ 5�      6>   �� 5�   
   	listStyle  " ��6"   .�5�      ��  � ��
 �   �6<   �� 5�       � ��$ 0q�60   6<   �� 5�       � ��$ Stretch=�6;   6M   �� 5�       � ��$	 200��6*    �� 	Resources 5�       �� Color��%�   (��       5�   "   * SystemColors.HighlightBrushKey+)(�� +     5�   "   *SystemColors.ControlBrushKey+)�� 5�      $ AntiqueWhite��6T   6k   �� 5�      $ 	AliceBlue��6R   5�      5�      �� 5�   
   " ��6   .�5�      ��  � ��$ Stretch=�62   �� 5�       � ��$ Stretch=�64   �� 5�       � ��$ Stretch=�69   �� 5�       � ��$ Stretch=�6;   5�      �� 5�   
   " ��6   .�5�      ��  � ��$ Stretch=�62   �� 5�       � ��$ Stretch=�64   �� 5�       � ��$ Center=�69   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ 5q�6'   �� 5�       � ��$ 5q�6(   �� 5�       � �� 5�      �� 5�       �� 
TargetType" ��6&   .R�5�      �� $ 10��6!   ��5�      �� 5�   "   ColorProperty��# z��6I   ._�5�      �� #��z��5�   %   #��z��5�   %   #��z��5�   %   '  !System.Windows.VisualStateManager   VisualStateGroups 5�      %  System.Windows.VisualStateGroup  5�   "   CommonStates��   States. 5�   &      System.Windows.VisualState  	MouseOver��   
Storyboard. 5�   *   �� .��5�   .   ��  g� Duration$ 0:0:0.4D�5�   1    �� 
TargetName$ ColorProperty��5�   1    �� TargetProperty$ Color�5�   1   	 �� To$ 
LightCoralX�5�   1   5�   +   5�   '     5�   &   
Normal��. 5�   *   �� .��5�   .   �� $ 0:0:0.4D�5�   1   $ ColorProperty��5�   1   $ Color�5�   1   # z��6S   5�   +   5�   '   5�   #   5�      5�      5�      5�      .��5�      � -   5          �Name$  
LayoutRoot��5�      |�.  
 5�   
   �� 5�      $��20 �6   �� 5�      $��60 �6   �� 5�      $��* �6   �� 5�      $��40 �6   .+�5�   
   � $��1��6    5�      �� 5�      �� 5�      �� 5�      .+�5�      �� -   5        ! ��Name$! btnRead��5�      $��0��6&   $��Refresh��66   
����ح�6^   �� 5�      -   5        $! btnAdd��5�      $��1��6%   $	��Add��65   
����ح�6X   �� 5�      -   5        $! 	btnDelete��5�      $��2��6(   $��Delete��68   
����ح�6a   5�      �� 5�   
   -   5        " ��Name$" listBoxInfo��5�      $��2��5        	listStyle#��[ 5       itemTemplateSelector#��[ 5     $��1��5     ��5     �� *Days+5     � 5  
   $��3��6    5     �� 5	     �� 5
     .+�5     �� -   5        $ currentDate��5     $��0��5     $��Center=�5     $��Center=�5       itemStyleHeadSec#��[ 5     ��5     �� *
CurrentDay+$ {0:dd MMMM yyyy}��5     �� 5     -   5        $ currentState��5     $��1��5      	 itemStyleHeadState#��[	 5     $��Center=�5     $��Center=�5     ��5     �� *CurrentState+5     5     5     5     