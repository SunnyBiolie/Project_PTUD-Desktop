   M S B A M L   `   `   `  ����O  KProject_PTUD-Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Project_PTUD_DesktopProject_PTUD_Desktop  5   	   Y1clr-namespace:Project_PTUD_Desktop.MyUserControls#Project_PTUD_Desktop.MyUserControls  5	   	   /    )Project_PTUD_Desktop.TheaterClusterWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Project_PTUD_Desktop     5   	   @uc1clr-namespace:Project_PTUD_Desktop.MyUserControls     5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��theaterClusterWindow��5
   	     � Title$*  $Chỉnh sửa danh sách cụm rạp��5   	   $	��450��6-   $	��550��6:    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     TheaterClusterVM � DataContext# [ 5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5       6   0Project_PTUD_Desktop.MyUserControls.MyControlBar  
 � Tag 6   �� *Title+	 �� ElementName$	 theaterClusterWindow��6X   5!      � 5"   
   $��1��6   .+�5#      ��  * &MaterialDesignNavigationRailTabControl#��[ 6   
 �� TabStripPlacement$	
 Top=�5$   !   $��Stretch=�5%   !   .@�5'      �� -   5         ��Name$ tabAdd��5'   1   $��80��6   $��50��6%   ��5(      �� 5)      $
��auto��6%   $
��auto��62   .+�5*      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��66   $��24��6A   $��Center=�5+   6      Kind$ 
PlusCircle=�6S   �� 5,      $��Center=�6(   $��Thêm��6E   5-      .��5/      �  50      �� 51      6.   �� 52      6.   .+�54      � $��0��6    55      �� 56   "   62   �� 57   "   62   .+�59      � $��0��6#   .+�5:   "   ��  �� Orientation$ 
Horizontal=�6-   $
��Auto��6F   $��	25 0 25 0q�6S   .+�5;   &   �� $��Center=�5<   )   $	��120��6D    �� 	MaxLength$ 5��6S   $��0 0 40 0q�6a   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Mã cụm��5=   )    % !MaterialDesignFloatingHintTextBox#��[ 5>   )   ��5?   )   �� *	MaCum_add+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� 5@   &   $��Center=�5A   )   $	��200��6D   $ 
Tên cụm��5B   )   #��[ 5C   )   ��5D   )   �� *
TenCum_add+$ PropertyChanged=�$ OneWayToSource=�5E   #   5F      � 5G      $��1��6#   $��	25 0 25 0q�60   .+�5H   "   �� $��Center=�5I   %   $	��400��6@   $ Địa chỉ��5J   %    �� TextWrapping$
 Wrap=�6N   #��[ 5K   %   ��5L   %   �� *
DiaChi_add+$ PropertyChanged=�$ OneWayToSource=�5M      5N      � 5O      $��1��6   .+�5P      ��  �� 	IsDefault . $	��200��5Q   %   $��Center=�61   $��Center=�6N   ��5P   %   �� *
AddCommand+.��5Q   j   Thêm cụm rạp6x   5R      5S      5T      �� 5V      -   5        $ tabEdit��5V   1   $��80��6   $��50��6%   ��5W      �� 5X      $
��auto��6%   $
��auto��62   .+�5Y        $��24��66   $��24��6A   $��Center=�5Z   6   $ 	TableEdit=�6S   �� 5[      $��Center=�6(   $��Sửa��6E   5\      .��5^      �  5_      �� 5`      $
��Auto �6,   6<   �� 5a      $
��Auto �6,   6<   �� 5b      6.   .+�5d      � $��0��6    5e      �� 5f   "   62   �� 5g   "   62   .+�5i      � $��0��6#   $��	0 10 0 10q�60   .+�5j   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	25 0 25 0q�6S   .+�5k   &   �� $��Center=�5l   )   $	��120��6D   $ 5��6S   $��0 0 40 0q�6a   $ 	Mã cụm��5m   )   {�.  #��[ 5n   )   ��5o   )   �� *
MaCum_edit+$ PropertyChanged=�$ TwoWay=��� 5p   &   $��Center=�5q   )   $	��200��6D   $ 
Tên cụm��5r   )   #��[ 5s   )   ��5t   )   �� *TenCum_edit+$ PropertyChanged=�$ TwoWay=�5u   #   5v      � 5w      $��1��6#   $��25 10 25 10q�60   .+�5x   "   �� $��Center=�5y   %   $	��400��6@   $ Địa chỉ��5z   %   $
 Wrap=�6N   #��[ 5{   %   ��5|   %   �� *DiaChi_edit+$ PropertyChanged=�$ TwoWay=�5}      5~      � 5      $��1��6   .+�5�      ��  . $	��160��5�   %   $��Center=�61   $��Center=�6N   ��5�   %   �� *EditCommand+.��5�   j   Cập nhật6t   5�      �� 5�      $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5�      �� ��6'   �� *
ListCumRap+ �� SelectedItem 6J   �� *SelectedItem+$ OneWayToSource=� �� View 5�   "   �� 5�   &   .P�5�   *   �� $��	Mã Rạp��69    �� DisplayMemberBinding 6I   �� *MaCum+6r   �� 5�   *   $��
Tên Rạp��69    6J   �� *TenCum+6t   �� 5�   *   $��Địa Chỉ��69    6J   �� *DiaChi+6t   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ 	tabDelete��5�   1   $��80��6   $��50��6%   ��5�      �� 5�      $
��auto��6%   $
��auto��62   .+�5�        $��24��66   $��24��6A   $��Center=�5�   6   $ DeleteEmpty=�6S   �� 5�      $��Center=�6(   $
��Xóa��6E   5�      .��5�      �  5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      6.   .+�5�      � $��0��6    5�      �� 5�   "   62   �� 5�   "   62   .+�5�      � $��0��6#   $��	0 10 0 10q�60   .+�5�   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	25 0 25 0q�6S   .+�5�   &   �� $��Center=�5�   )   $	��120��6D   $ 5��6S   $��0 0 40 0q�6a   $ 	Mã cụm��5�   )   {�.  #��[ 5�   )   ��5�   )   �� *MaCum_delete+$ PropertyChanged=�$ OneWay=��� 5�   &   $��Center=�5�   )   $	��200��6D   $ 
Tên cụm��5�   )   {�.  #��[ 5�   )   ��5�   )   �� *TenCum_delete+$ PropertyChanged=�$ OneWay=�5�   #   5�      � 5�      $��1��6#   $��25 10 25 10q�60   .+�5�   "   �� $��Center=�5�   %   $	��400��6@   $ Địa chỉ��5�   %   $
 Wrap=�6N   {�.  #��[ 5�   %   ��5�   %   �� *DiaChi_delete+$ PropertyChanged=�$ OneWay=�5�      5�      � 5�      $��1��6   .+�5�      ��  . $	��180��5�   %   $��Center=�61   $��Center=�6N   ��5�   %   �� *DeleteCommand+.��5�   j   Xoá cụm rạp6w   5�      �� 5�      $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5�      �� ��6'   �� *
ListCumRap+ 6J   �� *SelectedItem+$ OneWayToSource=� 5�   "   �� 5�   &   .P�5�   *   �� $��	Mã Rạp��69    6I   �� *MaCum+6r   �� 5�   *   $��
Tên Rạp��69    6J   �� *TenCum+6t   �� 5�   *   $��Địa Chỉ��69    6J   �� *DiaChi+6t   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      