   M S B A M L   `   `   `  ����O  KProject_PTUD-Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Project_PTUD_DesktopProject_PTUD_Desktop  5   	   Y1clr-namespace:Project_PTUD_Desktop.MyUserControls#Project_PTUD_Desktop.MyUserControls  5	   	   *    $Project_PTUD_Desktop.ShowTimesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Project_PTUD_Desktop     5   	   @uc1clr-namespace:Project_PTUD_Desktop.MyUserControls     5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��showTimesWindow��5
   	     � Title$  Lịch Chiếu��5   	   $	��550��6   $	��650��6)    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     ShowTimesVM � DataContext# [ 5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *ShowTimesWindowClosed+6P   5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��Auto �6   6,   �� 5#      6   .+�5%   
   � $��0��6   .+�5&      6   0Project_PTUD_Desktop.MyUserControls.MyControlBar  
 � Tag 6   �� *Title+ �� ElementName$ showTimesWindow��6S   5'      � 5(   
   $��1��6   .+�5)      ��  * &MaterialDesignNavigationRailTabControl#��[ 6    �� TabStripPlacement$	 Top=�5*   !   $��Stretch=�5+   !   .@�5-      �� -   5         ��Name$ tabAdd��5-   1   $��80��6   $��50��6%   ��5.      �� 5/      $
��auto��6%   $
��auto��62   .+�50      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��66   $��24��6A   $��Center=�51   6      Kind$ 
PlusCircle=�6S   �� 52      $��Center=�6(   $��Thêm��6E   53      .��55      �  56      �� 57      6.   �� 58      6.   .+�5:      � $��0��6    5;      �� 5<   "   62   �� 5=   "   62   .+�5?      � $��0��6#   .+�5@   "   ��  �� Orientation$ 
Horizontal=�6-   $
��Auto��6F   $��	35 0 35 0q�6S   .+�5A   &   �� $��Center=�5B   )   $	��120��6D    �� 	MaxLength$ 5��6P   $��0 0 40 0q�6^   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã phim��5C   )   {�.   % !MaterialDesignFloatingHintTextBox#��[ 5D   )   ��5E   )   �� *MaPhimForShowTimes+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=�(	  "System.Windows.Controls.DatePicker	  5F   &   $	��180��5G   1   $��10q�6=   {�.  $��0 0 40 0q�6\   $ Ngày Chiếu��5H   1    $  MaterialDesignOutlinedDatePicker#��[ 5I   1    	  SelectedDate 5F   1   �� *NgayChieuForShowTimes+$ OneWay=�5I   1   �� 5J   &   $��Center=�5K   )   $	��120��6D   $��0 0 40 0q�6P   $ Thời lượng��5L   )   {�.  #��[ 5M   )   ��5N   )   �� *ThoiLuongForShowTimes+$ PropertyChanged=�$ OneWay=�5O   #   5P      � 5Q      $��1��6#   $��	35 0 25 0q�60    � ColumnDefinitions 5R   "   �� 5S   &   $
��Auto �67   6F   �� 5T   &   69   .+�5V   "   �� $��0��6-   .+�5W   &   �� $ 
Horizontal=�61   .+�5X   *   �� $	��100��63   $��
0 10 10 15q�6?   $ 	Mã cụm��5Y   /    �� DisplayMemberPath$ MaCum��5[   /    & "MaterialDesignFloatingHintComboBox#��[ 5]   /   ��5Z   /   �� *ListCRForFilterRap+ �� SelectedItem 5\   /   �� *SelectedCRForFilterRap+$ OneWayToSource=�5^   +   �� 5_   *   $	��100��63   $��	0 10 5 15q�6?   $ 	Mã rạp��5`   /   $ MaRap��5b   /   #��[ 5d   /   {�5`   W   �� *IsSelectedCRForFilterRap+��5a   /   �� *	ListRap+ 5c   /   �� *SelectedRap_add+$ OneWayToSource=�5e   +   5f   '   �� 5g   &   $	��120��6/   $��0 0 5 0q�6;   $
��Left=�6L   $ Suất chiếu��5h   )   #��[ 5k   )   ��5i   )   �� *ListSuatChieu+  ScreeningsVM �� Source# [  5j   )   �� *SelectedScreenings_add+$ OneWayToSource=���5l   *   �� 5m   .   .R�5n   2   �� $ 
Horizontal=�6=   .+�5o   6   �� ��6@   �� *MaSuat+6Z   �� 5p   6   $	�� - ��6@   6M   �� 5q   6   ��6@   �� *	GioBatDau+6]   �� 5r   6   $��:��6@   6K   �� 5s   6   ��6@   �� *
PhutBatDau+6^   5t   3   5u   /   5w   '   5x   #   �� 5y   "   $��1��6+   $��8q�6;   $��5q�6F   $��Danh sách suất chiếu��6R   $	��320��6p   $
��Auto��6|   .��5z   &   �  5{   *   �� 5|   .   6>   �� 5}   .   $
��Auto �6<   6L   .+�5   *   �� $��0��67   $
��Auto=�6D   .��5�   .   �� $
��Wrap=�68   ��6L   �� *ListDisplaySuatChieu_add+$ OneWay=�5�   +   �� 5�   *   $��1��65   $ 
Horizontal=�6B   $��Right=�6[   .+�5�   .   �� $��70��6[   $��30��6f   $��12(�6r   $��Light"�6�   $��0 0 10 0q�6�   $��Thêm��6�   ��65   �� *AddScreenings_add+6�   �� 5�   .   $��70��6^   $��30��6i   $��12(�6u   $��Light"�6�   $��0 0 10 0q�6�   ��65   �� *RemoveScreenings_add+.��6�   Xóa6�   �� 5�   .   $��70��6]   $��30��6h   $��12(�6t   $��Light"�6�   ��65   �� *ClearScreenings_add+.��6�   Clear6�   5�   +   5�   '   5�   #   5�      5�      � 5�      $��1��6   .+�5�      ��  �� 	IsDefault . $	��200��5�   %   $��Center=�61   $��Center=�6N   ��5�   %   �� *
AddCommand+.��5�   j   Thêm lịch chiếu6{   5�      5�      5�      �� 5�      -   5        $ tabEdit��5�   1   $��80��6   $��50��6%   ��5�      �� 5�      $
��auto��6%   $
��auto��62   .+�5�        $��24��66   $��24��6A   $��Center=�5�   6   $ 	TableEdit=�6S   �� 5�      $��Center=�6(   $��Sửa��6E   5�      .��5�      �  5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      6.   .+�5�      � $��0��6    5�      �� 5�   "   $
��Auto �60   6@   �� 5�   "   $
��Auto �60   6@   �� 5�   "   62   .+�5�      � $��0��6#   $��10q�60   .+�5�   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	20 0 20 0q�6S   .+�5�   &   �� $��Center=�5�   )   $	��120��6D   $ 5��6P   $��0 0 40 0q�6^   $ Mã phim��5�   )   {�.  #��[ 5�   )   ��5�   )   �� *MaPhimForShowTimes+$ PropertyChanged=�$ OneWay=�	  5�   &   $	��180��5�   1   $��10q�6=   {�.  $��0 0 40 0q�6\   $ Ngày Chiếu��5�   1   #��[ 5�   1    5�   1   �� *NgayChieuForShowTimes+$ OneWay=�5�   1   �� 5�   &   $��Center=�5�   )   $	��120��6D   $��0 0 40 0q�6P   $ Thời lượng��5�   )   {�.  #��[ 5�   )   ��5�   )   �� *ThoiLuongForShowTimes+$ PropertyChanged=�$ OneWay=�5�   #   5�      � 5�      $��1��6#    5�   "   �� 5�   &   $
��Auto �67   6F   �� 5�   &   69   .+�5�   "   � $��0��6'   $��	10 0 10 0q�67   .+�5�   &   �� $ Vertical=�61   $
��Auto��6H   $��20 10 20 10q�6U   .+�5�   *   �� $��Center=�5�   -   $	��120��6H   $��0 0 5 10q�6T   $ 	Mã rạp��5�   -   {�.  #��[ 5�   -   ��5�   -   �� *
MaRap_edit+$ PropertyChanged=�$ OneWay=��� 5�   *   $	��120��63   $��0 0 5 0q�6?   $ Suất chiếu��5�   1   #��[ 5�   1   ��5�   1   �� *ListSuatChieu+# [  5�   1   �� *SelectedScreenings_edit+$ TwoWay=���5�   .   �� 5�   2   .R�5�   6   �� $ 
Horizontal=�6A   .+�5�   :   �� ��6D   �� *MaSuat+6^   �� 5�   :   $	�� - ��6D   6Q   �� 5�   :   ��6D   �� *	GioBatDau+6a   �� 5�   :   $��:��6D   6O   �� 5�   :   ��6D   �� *
PhutBatDau+6b   5�   7   5�   3   5�   +   5�   '   5�   #   �� 5�   "   $��1��6-   $ 
Horizontal=�6=   $��	30 0 30 0q�6V   $
��Auto��6i   .+�5�   &   �� $��8q�6/   $��5q�6:   $��Danh sách giờ chiếu��6F   $	��350��6c   $
��Auto��6o   .��5�   *   �  5�   .   �� 5�   2   6B   �� 5�   2   $
��Auto �6@   6P   .+�5�   .   �� $��0��6;   $
��Auto=�6H   .��5�   2   �� $
��Wrap=�6<   ��6P   �� *ListDisplaySuatChieu_edit+$ OneWay=�5�   /   �� 5�   .   $��1��69   $ 
Horizontal=�6F   $��Right=�6_   .+�5�   2   �� $��70��6`   $��30��6k   $��12(�6w   $��Light"�6�   $��0 0 10 0q�6�   ��69   �� *AddScreenings_edit+.��6�   Thêm6�   �� 5�   2   $��70��6c   $��30��6n   $��12(�6z   $��Light"�6�   $��0 0 10 0q�6�   ��69   �� *RemoveScreenings_edit+.��6�   Xóa6�   �� 5�   2   $��70��6b   $��30��6m   $��12(�6y   $��Light"�6�   ��69   �� *ClearScreenings_edit+.��6�   Clear6�   5�   /   5�   +   5�   '   5�   #   5�      5�      � 5�      $��1��6   $��0 5 0 5q�6,   .+�5�      ��  . $	��200��5�   %   $��Center=�61   $��Center=�6N   ��5�   %   �� *EditCommand+.��5�   j   Cập nhật6t   5�      �� 5�      $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5�      �� ��6'   �� *ListShowTimesDTO+ 6P   �� *SelectedItem+$ OneWayToSource=� �� View 5�   "   �� 5�   &   .P�5�   *   �� $��	Mã Rạp��69    �� DisplayMemberBinding 6I   �� *MaRap+6r   �� 5�   *   $��Chuỗi Mã Suất��69    6P   �� *ChuoiMaSuat+6   �� 5�   *   $��Giờ Chiếu��69    6L   �� *DisplayChuoiMaSuat+6�   5�   '   5�      5�      5�      5�      �� 5     -   5        $ 	tabDelete��5  1   $��80��6   $��50��6%   ��5     �� 5     $
��auto��6%   $
��auto��62   .+�5       $��24��66   $��24��6A   $��Center=�5  6   $ BinEmpty=�6S   �� 5     $��Center=�6(   $
��Xóa��6E   5     .��5	     �  5
     �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   �� 5     6.   .+�5     � $��0��6    5     �� 5  "   $
��Auto �60   6@   �� 5  "   $
��Auto �60   6@   �� 5  "   62   .+�5     � $��0��6#   $��10q�60   .+�5  "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	20 0 20 0q�6S   .+�5  &   �� $��Center=�5  )   $	��120��6D   $ 5��6P   $��0 0 40 0q�6^   $ Mã phim��5  )   {�.  #��[ 5  )   ��5  )   �� *MaPhimForShowTimes+$ PropertyChanged=�$ OneWay=�	  5  &   $	��180��5  1   $��10q�6=   {�.  $��0 0 40 0q�6\   $ Ngày Chiếu��5  1   #��[ 5  1    5  1   �� *NgayChieuForShowTimes+$ OneWay=�5  1   �� 5   &   $��Center=�5!  -   $	��120��6H   $��0 0 5 10q�6T   $ 	Mã rạp��5"  -   {�.  #��[ 5#  -   ��5$  -   �� *MaRap_delete+$ PropertyChanged=�$ OneWay=�5%  #   5&     � 5'     $��1��6#    5(  "   �� 5)  &   $
��Auto �67   6F   �� 5*  &   69   .+�5,  "   � $��0��6'   5.  #   � 5/  "   $��1��6'   $��	30 0 30 0q�67   $
��Auto��6J   .+�50  &   �� $��10q�6/   $��5q�6;   $��Danh sách giờ chiếu��6G   $	��350��6d   $
��Auto��6p   .��51  *   �  52  .   �� 53  2   6B   �� 54  2   $
��Auto �6@   6P   .+�56  .   �� $��0��6;   $
��Auto=�6H   .��57  2   �� $��60��6<   $
��Wrap=�6K   ��6_   �� *ListDisplaySuatChieu_delete+$ OneWay=�58  /   59  +   5:  '   5;  #   5<     5=     � 5>     $��1��6   $��0 5 0 5q�6,   .+�5?     ��  . $	��200��5@  %   $��Center=�61   $��Center=�6N   ��5?  %   �� *DeleteCommand+.��5@  j   Xóa lịch chiếu6z   5C     �� 5D     $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5E     �� ��6'   �� *ListShowTimesDTO+ 6P   �� *SelectedItem+$ OneWayToSource=� 5F  "   �� 5G  &   .P�5H  *   �� $��	Mã Rạp��69    6I   �� *MaRap+6r   �� 5I  *   $��Chuỗi Mã Suất��69    6P   �� *ChuoiMaSuat+6   �� 5J  *   $��Giờ Chiếu��69    6L   �� *DisplayChuoiMaSuat+6�   5K  '   5M     5N     5O     5P     5Q     5R     5S     5T     