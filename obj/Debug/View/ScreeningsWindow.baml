   M S B A M L   `   `   `  ����O  KProject_PTUD-Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Project_PTUD_DesktopProject_PTUD_Desktop  5   	   Y1clr-namespace:Project_PTUD_Desktop.MyUserControls#Project_PTUD_Desktop.MyUserControls  5	   	   +    %Project_PTUD_Desktop.ScreeningsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Project_PTUD_Desktop     5   	   @uc1clr-namespace:Project_PTUD_Desktop.MyUserControls     5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��screeningsWindow��5
   	     � Title$-  'Chỉnh sửa danh sách suất chiếu��5   	   $	��450��60   $	��500��6=    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     ScreeningsVM � DataContext# [ 5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5       6   0Project_PTUD_Desktop.MyUserControls.MyControlBar  
 � Tag 6   �� *Title+	 �� ElementName$	 screeningsWindow��6T   5!      � 5"   
   $��1��6   .+�5#      ��  * &MaterialDesignNavigationRailTabControl#��[ 6   
 �� TabStripPlacement$	
 Top=�5$   !   $��Stretch=�5%   !   .@�5'      �� -   5         ��Name$ tabAdd��5'   1   $��80��6   $��50��6%   ��5(      �� 5)      $
��auto��6%   $
��auto��62   .+�5*      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��66   $��24��6A   $��Center=�5+   6      Kind$ 
PlusCircle=�6S   �� 5,      $��Center=�6(   $��Thêm��6E   5-      .��5/      �  50      �� 51      6.   �� 52      6.   .+�54      � $��0��6   .+�55      � .+�56   "   ��  �� Orientation$ 
Horizontal=�6-   $
��Auto��6F   $��	25 0 25 0q�6S   .+�57   &   �� $��Center=�58   )   $	��100��6D    �� 	MaxLength$ 3��6S   $��0 0 30 0q�6a   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Mã suất��59   )    % !MaterialDesignFloatingHintTextBox#��[ 5:   )   ��5;   )   �� *
MaSuat_add+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� 5<   &   $	��120��6/   $��0 0 30 0q�6>   $ Giờ bắt đầu��5=   )    & "MaterialDesignFloatingHintComboBox#��[ 5?   )   ��5>   )   �� *	HoursList+ �� SelectedItem 5@   )   �� *SelectedHourForAdd+$ TwoWay=��� 5A   &   $	��120��6/   $��0 0 30 0q�6>   $ Phút bắt đầu��5B   )   #��[ 5D   )   ��5C   )   �� *MinutesList+ 5E   )   �� *SelectedMinuteForAdd+$ TwoWay=�5F   #   5G      5H      � 5I      $��1��6   .+�5J      ��  �� 	IsDefault . $	��200��5K   %   $��Center=�61   $��Center=�6N   ��5J   %   �� *
AddCommand+.��5K   j   Thêm suất chiếu6{   5L      5M      5N      �� 5P      -   5        $ 	tabDelete��5P   1   $��80��6   $��50��6%   ��5Q      �� 5R      $
��auto��6%   $
��auto��62   .+�5S        $��24��66   $��24��6A   $��Center=�6M   $ DeleteEmpty=�6j   �� 5T      $��Center=�6(   $
��Xóa��6E   5U      .��5W      �  5X      �� 5Y      $
��Auto �6,   6<   �� 5Z      $
��Auto �6,   6<   �� 5[      6.   .+�5]      � $��0��6   .+�5^      � $��	0 10 0 10q�6#   .+�5_   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	25 0 25 0q�6S   .+�5`   &   �� $��Center=�5a   )   $	��100��6D   $ 3��6S   $��0 0 30 0q�6a   $ 
Mã suất��5b   )   {�.  #��[ 5c   )   ��5d   )   �� *MaSuat_delete+$ PropertyChanged=�$ OneWay=��� 5e   &   $��Center=�5f   )   $	��120��6D   $��0 0 30 0q�6S   $ Giờ bắt đầu��5g   )   {�.  #��[ 5h   )   ��5i   )   �� *GioBatDau_delete+$ PropertyChanged=�$ OneWay=��� 5j   &   $��Center=�5k   )   $	��120��6D   $ Phút bắt đầu��5l   )    �� TextWrapping$
 Wrap=�6W   {�.  #��[ 5m   )   ��5n   )   �� *PhutBatDau_delete+$ PropertyChanged=�$ OneWay=�5o   #   5p      5q      � 5r      $��1��6   .+�5s      ��  . $	��180��5t   %   $��Center=�61   $��Center=�6N   ��5s   %   �� *DeleteCommand+.��5t   j   Xoá suất chiếu6z   5u      �� 5v      $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5w      �� ��6'   �� *ListSuatChieu+ 6M   �� *SelectedItem+$ OneWayToSource=� �� View 5x   "   �� 5y   &   .P�5z   *   �� $��
Mã Suất��69    �� DisplayMemberBinding 6J   �� *MaSuat+6t   �� 5{   *   $��Giờ Bắt Đầu��69    6N   �� *	GioBatDau+6{   �� 5|   *   $��Phút Bắt Đầu��69    6O   �� *
PhutBatDau+6}   5}   '   5      5�      5�      5�      5�      5�      5�      5�      