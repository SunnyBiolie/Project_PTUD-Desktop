   M S B A M L   `   `   `  ����O  KProject_PTUD-Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Project_PTUD_DesktopProject_PTUD_Desktop  5   	   Y1clr-namespace:Project_PTUD_Desktop.MyUserControls#Project_PTUD_Desktop.MyUserControls  5	   	   %    Project_PTUD_Desktop.FilmWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Project_PTUD_Desktop     5   	   @uc1clr-namespace:Project_PTUD_Desktop.MyUserControls     5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��
filmWindow��5
   	     � Title$
  Phim��5   	   $	��550��6   $	��650��6#    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   &   System.Windows.Media.TextOptions   TextRenderingMode$
 Auto=�5   	   $��13(�5   	      TextFormattingMode$ Ideal=�5   	   $��Regular"�5   	      MaterialDesignPaper#���   5   	    
 FilmVM � DataContext# [ 5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5       6   0Project_PTUD_Desktop.MyUserControls.MyControlBar  
 � Tag 6   �� *Title+	 �� ElementName$	 
filmWindow��6N   5!      � 5"   
   $��1��6   .+�5#      ��  * &MaterialDesignNavigationRailTabControl#��[ 6   
 �� TabStripPlacement$	
 Top=�5$   !   $��Stretch=�5%   !   .@�5'      �� -   5         ��Name$ tabAdd��5'   1   $��80��6   $��50��6%   ��5(      �� 5)      $
��auto��6%   $
��auto��62   .+�5*      '  !MaterialDesignThemes.Wpf.PackIcon  $��24��66   $��24��6A   $��Center=�5+   6      Kind$ 
PlusCircle=�6S   �� 5,      $��Center=�6(   $��Thêm��6E   5-      .��5/      �  50      �� 51      $
��Auto �6,   6<   �� 52      6.   .+�54      � $��0��6    55      �� 56   "   $
��Auto �60   6@   �� 57   "   $
��Auto �60   6@   �� 58   "   62   .+�5:      � $��0��6#   $��10q�60   .+�5;   "   ��  �� Orientation$ 
Horizontal=�6-   $
��Auto��6F   $��	20 0 20 0q�6S   .+�5<   &   �� $��Center=�5=   )   $	��100��6D    �� 	MaxLength$ 5��6S   $��0 0 30 0q�6a   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã phim��5>   )    % !MaterialDesignFloatingHintTextBox#��[ 5?   )   ��5@   )   �� *
MaPhim_add+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� 5A   &   $��Center=�5B   )   $	��380��6D   $ 	Tên phim��5C   )    �� TextWrapping$
 Wrap=�6S   #��[ 5D   )   ��5E   )   �� *TenPhim_add+$ PropertyChanged=�$ OneWayToSource=�5F   #   5G      � 5H      $��1��6#   $��	10 0 10 0q�60   .+�5I   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��20 10 20 10q�6S   .+�5J   &   �� $	��200��5K   )   $��8q�65   $��0 0 30 0q�6A   $ Thể loại chính��5L   )    �� DisplayMemberPath$ 
TenTheLoai��5M   q    & "MaterialDesignFloatingHintComboBox#��[ 5N   )    �� SelectedItem 5J   /   �� *SelectedCategory_add+$ TwoWay=���5M   )   �� *ListTheLoai+  
CategoryVM �� Source# [ 5N   )   �� 5O   &   $��Center=�5P   )   $	��120��6D   $ Thời lượng��5Q   )   $
 Wrap=�6U   #��[ 5R   )   ��5S   )   �� *ThoiLuong_add+$ PropertyChanged=�$ OneWayToSource=�5T   #   5U      �� 5V      $��2��6)   $ 
Horizontal=�66   $��	30 0 30 0q�6O   $
��Auto��6b   $	��200��6p   .+�5W   "   �� $	��Top=�6+   $	��200��5Y   %   $��8q�61   $��	0 18 15 0q�6=   $ Thể loại phụ��5Z   %   $ 
TenTheLoai��5[   J   #��[ 5\   %    5X   +   �� *SelectedSubCategory_add+$ TwoWay=���5[   %   �� *ListTheLoai+5\   %   �� 5]   "   $��16q�6+   $/��)Danh sách thể loại phụ (nếu có)��67   $	��320��6`   $
��Auto��6l   .��5^   &   �  5_   *   �� 5`   .   6>   �� 5a   .   $
��Auto �6<   6L   .+�5c   *   �� $��0��64   $
��Wrap=�6A   $��40��6U   ��6d   �� *ChuoiTenTheLoaiPhu_add+�� 5d   *   $��1��65   $ 
Horizontal=�6B   $��Right=�6[   .+�5e   .   �� $��70��6\   $��30��6g   $��12(�6s   $��Light"�6�   $��0 0 10 0q�6�   ��65   �� *AddSubCategory_Add+.��6�   Thêm6�   �� 5f   .   $��70��6_   $��30��6j   $��12(�6v   $��Light"�6�   $��0 0 10 0q�6�   ��65   �� *RemoveSubCategory_Add+.��6�   Xóa6�   �� 5g   .   $��70��6a   $��30��6l   $��12(�6x   $��Light"�6�   ��65   �� *ClearAllSubCategory_Add+.��6�   Clear6�   5h   +   5i   '   5j   #   5k      5l      � 5m      $��1��6   $��	0 10 0 20q�6,   .+�5n      ��  �� 	IsDefault . $	��200��5o   %   $��Center=�61   $��Center=�6N   ��5n   %   �� *
AddCommand+.��5o   j   
Thêm phim6u   5p      5q      5r      �� 5t      -   5        $ tabEdit��5t   1   $��80��6   $��50��6%   ��5u      �� 5v      $
��auto��6%   $
��auto��62   .+�5w        $��24��66   $��24��6A   $��Center=�5x   6   $ 	TableEdit=�6S   �� 5y      $��Center=�6(   $��Sửa��6E   5z      .��5|      �  5}      �� 5~      $
��Auto �6,   6<   �� 5      $
��Auto �6,   6<   �� 5�      6.   .+�5�      � $��0��6    5�      �� 5�   "   $
��Auto �60   6@   �� 5�   "   $
��Auto �60   6@   �� 5�   "   62   .+�5�      � $��0��6#   $��10q�60   .+�5�   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	20 0 20 0q�6S   .+�5�   &   �� $��Center=�5�   )   $	��100��6D   $ 5��6S   $��0 0 30 0q�6a   $ Mã phim��5�   )   {�.  #��[ 5�   )   ��5�   )   �� *MaPhim_edit+$ PropertyChanged=�$ TwoWay=��� 5�   &   $��Center=�5�   )   $	��380��6D   $ 	Tên phim��5�   )   $
 Wrap=�6S   #��[ 5�   )   ��5�   )   �� *TenPhim_edit+$ PropertyChanged=�$ TwoWay=�5�   #   5�      � 5�      $��1��6#    � ColumnDefinitions 5�   "   �� 5�   &   $
��Auto �67   6F   �� 5�   &   69   .+�5�   "   � $��0��6'   $��	10 0 10 0q�67   .+�5�   &   �� $ Vertical=�61   $
��Auto��6H   $��20 10 20 10q�6U   .+�5�   *   �� $
��Left=�5�   3   $	��200��5�   -   $��8q�69   $��0 0 0 10q�6E   $ Thể loại chính��5�   -   $ 
TenTheLoai��5�   Q   #��[ 5�   -    5�   3   �� *SelectedCategory_edit+$ TwoWay=���5�   -   �� *ListTheLoai+5�   -   �� 5�   *   $
��Left=�5�   -   $	��120��6H   $ Thời lượng��5�   -   $
 Wrap=�6Y   #��[ 5�   -   ��5�   -   �� *ThoiLuong_edit+$ PropertyChanged=�$ TwoWay=��� 5�   *   $
��Left=�63   $	��200��5�   -   $��8q�69   $��	0 10 15 0q�6E   $ Thể loại phụ��5�   -   $ 
TenTheLoai��5�   R   #��[ 5�   -    5�   -   �� *SelectedSubCategory_edit+$ TwoWay=���5�   -   �� *ListTheLoai+5�   -   5�   '   5�   #   �� 5�   "   $��1��6-   $ 
Horizontal=�6=   $��0 0 30 0q�6V   $
��Auto��6h   .+�5�   &   �� $��8q�6/   $��5q�6:   $/��)Danh sách thể loại phụ (nếu có)��6F   $	��320��6o   $
��Auto��6{   .��5�   *   �  5�   .   �� 5�   2   6B   �� 5�   2   $
��Auto �6@   6P   .+�5�   .   �� $��0��6;   $
��Auto=�6H   .��5�   2   �� $
��Wrap=�6<   ��6P   �� *ChuoiTenTheLoaiPhu_edit+$ OneWay=�5�   /   �� 5�   .   $��1��69   $ 
Horizontal=�6F   $��Right=�6_   .+�5�   2   �� $��70��6a   $��30��6l   $��12(�6x   $��Light"�6�   $��0 0 10 0q�6�   ��69   �� *AddSubCategory_Edit+.��6�   Thêm6�   �� 5�   2   $��70��6d   $��30��6o   $��12(�6{   $��Light"�6�   $��0 0 10 0q�6�   ��69   �� *RemoveSubCategory_Edit+.��6�   Xóa6�   �� 5�   2   $��70��6f   $��30��6q   $��12(�6}   $��Light"�6�   ��69   �� *ClearAllSubCategory_Edit+.��6�   Clear6�   5�   /   5�   +   5�   '   5�   #   5�      5�      � 5�      $��1��6   $��0 5 0 5q�6,   .+�5�      ��  . $	��200��5�   %   $��Center=�61   $��Center=�6N   ��5�   %   �� *EditCommand+.��5�   j   Cập nhật6t   5�      �� 5�      $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5�      �� ��6'   �� *
ListPhim+ 6H   �� *SelectedItem+$ OneWayToSource=� �� View 5�   "   �� 5�   &   .P�5�   *   �� $��Mã Phim��69    �� DisplayMemberBinding 6J   �� *MaPhim+6t   �� 5�   *   $��	Tên Phim��69    6K   �� *	TenPhim+6v   �� 5�   *   $��Thời Lượng��69    6M   �� *	ThoiLuong+6z   5�   '   5�      5�      5�      5�      �� 5�      -   5        $ 	tabDelete��5�   1   $��80��6   $��50��6%   ��5�      �� 5�      $
��auto��6%   $
��auto��62   .+�5�        $��24��66   $��24��6A   $��Center=�5�   6   $ DeleteEmpty=�6S   �� 5�      $��Center=�6(   $
��Xóa��6E   5�      .��5�      �  5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      6.   .+�5�      � $��0��6    5�      �� 5�   "   $
��Auto �60   6@   �� 5�   "   $
��Auto �60   6@   �� 5�   "   62   .+�5�      � $��0��6#   $��10q�60   .+�5�   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	20 0 20 0q�6S   .+�5�   &   �� $��Center=�5�   )   $	��100��6D   $ 5��6S   $��0 0 30 0q�6a   $ Mã phim��5�   )   {�.  #��[ 5�   )   ��5�   )   �� *MaPhim_delete+$ PropertyChanged=��� 5�   &   $��Center=�5�   )   $	��380��6D   $ 	Tên phim��5�   )   {�.  $
 Wrap=�6e   #��[ 5�   )   ��5�   )   �� *TenPhim_delete+$ PropertyChanged=�5�   #   5�      � 5�      $��1��6#    5�   "   �� 5�   &   $
��Auto �67   6F   �� 5�   &   69   .+�5�   "   � $��0��6'   $��	10 0 10 0q�67   .+�5   &   �� $ Vertical=�61   $
��Auto��6H   $��20 10 20 10q�6U   .+�5  *   �� $
��Left=�5  -   $	��140��6H   {�.  $ Thể loại chính��5  -   $��0 0 0 10q�6]   #��[ 5  -   ��5  -   �� *TenTheLoaiChinh_delete+$ PropertyChanged=��� 5  *   $
��Left=�5  -   $	��140��6H   {�.  $ Thời lượng��5  -   $��0 10 0 0q�6Y   #��[ 5	  -   ��5
  -   �� *ThoiLuong_delete+$ PropertyChanged=�$ TwoWay=�5  '   5  #   � 5  "   $��1��6'   $��0 0 30 0q�67   $
��Auto��6I   .+�5  &   �� $��8q�6/   $��5q�6:   $/��)Danh sách thể loại phụ (nếu có)��6F   $	��340��6o   $
��Auto��6{   .��5  *   �  5  .   �� 5  2   6B   �� 5  2   $
��Auto �6@   6P   .+�5  .   �� $��0��6;   $
��Auto=�6H   .��5  2   �� $
��Wrap=�6<   ��6P   �� *ChuoiTenTheLoaiPhu_delete+$ OneWay=�5  /   5  +   5  '   5  #   5     5     � 5     $��1��6   $��0 5 0 5q�6,   .+�5     ��  . $	��200��5  %   $��Center=�61   $��Center=�6N   ��5  %   �� *DeleteCommand+.��5  j   	Xóa Phim6t   5     �� 5      $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5!     �� ��6'   �� *
ListPhim+ 6H   �� *SelectedItem+$ OneWayToSource=� 5"  "   �� 5#  &   .P�5$  *   �� $��Mã Phim��69    6J   �� *MaPhim+6t   �� 5%  *   $��	Tên Phim��69    6K   �� *	TenPhim+6v   �� 5&  *   $��Thời Lượng��69    6M   �� *	ThoiLuong+6z   5'  '   5)     5*     5+     5,     5-     5.     5/     50     