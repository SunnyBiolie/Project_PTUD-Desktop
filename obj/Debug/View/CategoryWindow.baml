   M S B A M L   `   `   `  ����O  KProject_PTUD-Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Project_PTUD_DesktopProject_PTUD_Desktop  5   	   Y1clr-namespace:Project_PTUD_Desktop.MyUserControls#Project_PTUD_Desktop.MyUserControls  5	   	   )    #Project_PTUD_Desktop.CategoryWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Project_PTUD_Desktop     5   	   @uc1clr-namespace:Project_PTUD_Desktop.MyUserControls     5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��screeningsWindow��5
   	     � Title$-  'Chỉnh sửa danh sách suất chiếu��5   	   $	��450��60   $	��450��6=    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     
CategoryVM � DataContext# [ 5   	   .��5      �  � RowDefinitions 5   
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
��Auto��6F   $��	25 0 25 0q�6S   .+�57   &   �� $��Center=�58   )   $	��100��6D    �� 	MaxLength$ 5��6S   $��0 0 30 0q�6a   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã thể loại��59   )    % !MaterialDesignFloatingHintTextBox#��[ 5:   )   ��5;   )   �� *MaTheLoai_add+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWayToSource=��� 5<   &   $��Center=�5=   )   $	��150��6D   $��0 0 30 0q�6S   $ Tên thể loại��5>   )   #��[ 5?   )   ��5@   )   �� *TenTheLoai_add+$ PropertyChanged=�$ OneWayToSource=�5A   #   5B      5C      � 5D      $��1��6   .+�5E      ��  �� 	IsDefault . $	��200��5F   %   $��Center=�61   $��Center=�6N   ��5E   %   �� *
AddCommand+.��5F   j   Thêm thể loại6y   5G      5H      5I      �� 5K      -   5        $ tabEdit��5K   1   $��80��6   $��50��6%   ��5L      �� 5M      $
��auto��6%   $
��auto��62   .+�5N        $��24��66   $��24��6A   $��Center=�5O   6   $ 	TableEdit=�6S   �� 5P      $��Center=�6(   $��Sửa��6E   5Q      .��5S      �  5T      �� 5U      $
��Auto �6,   6<   �� 5V      $
��Auto �6,   6<   �� 5W      6.   .+�5Y      � $��0��6   .+�5Z      � $��	0 10 0 20q�6#   .+�5[   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	25 0 25 0q�6S   .+�5\   &   �� $��Center=�5]   )   $	��100��6D   $ 5��6S   $��0 0 30 0q�6a   $ Mã thể loại��5^   )   {�.  #��[ 5_   )   ��5`   )   �� *MaTheLoai_edit+$ PropertyChanged=�$ TwoWay=��� 5a   &   $��Center=�5b   )   $	��150��6D   $��0 0 30 0q�6S   $ Tên thể loại��5c   )   #��[ 5d   )   ��5e   )   �� *TenTheLoai_edit+$ PropertyChanged=�$ TwoWay=�5f   #   5g      5h      � 5i      $��1��6   .+�5j      ��  . $	��160��5k   %   $��Center=�61   $��Center=�6N   ��5j   %   �� *EditCommand+.��5k   j   Cập nhật6t   5l      �� 5m      $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5n      �� ��6'   �� *ListTheLoai+ �� SelectedItem 6K   �� *SelectedItem+$ OneWayToSource=� �� View 5o   "   �� 5p   &   .P�5q   *   �� $��Mã Thể Loại��69    �� DisplayMemberBinding 6N   �� *	MaTheLoai+6{   �� 5r   *   $��Tên Thể Loại��69    6O   �� *
TenTheLoai+6}   5s   '   5u      5v      5w      5x      �� 5z      -   5        $ 	tabDelete��5z   1   $��80��6   $��50��6%   ��5{      �� 5|      $
��auto��6%   $
��auto��62   .+�5}        $��24��66   $��24��6A   $��Center=�6M   $ DeleteEmpty=�6j   �� 5~      $��Center=�6(   $
��Xóa��6E   5      .��5�      �  5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      6.   .+�5�      � $��0��6   .+�5�      � $��	0 10 0 20q�6#   .+�5�   "   �� $ 
Horizontal=�6-   $
��Auto��6F   $��	25 0 25 0q�6S   .+�5�   &   �� $��Center=�5�   )   $	��100��6D   $ 5��6S   $��0 0 30 0q�6a   $ Mã thể loại��5�   )   {�.  #��[ 5�   )   ��5�   )   �� *MaTheLoai_delete+$ PropertyChanged=�$ TwoWay=��� 5�   &   $��Center=�5�   )   $	��150��6D   $��0 0 30 0q�6S   $ Tên thể loại��5�   )   {�.  #��[ 5�   )   ��5�   )   �� *TenTheLoai_delete+$ PropertyChanged=�$ TwoWay=�5�   #   5�      5�      � 5�      $��1��6   .+�5�      ��  . $	��180��5�   %   $��Center=�61   $��Center=�6N   ��5�   %   �� *DeleteCommand+.��5�   j   Xoá thể loại6x   5�      �� 5�      $��2��6'   $
��Auto=�64   $
��Auto=�6Y   .��5�      �� ��6'   �� *ListTheLoai+ 6K   �� *SelectedItem+$ OneWayToSource=� 5�   "   �� 5�   &   .P�5�   *   �� $��Mã Thể Loại��69    6N   �� *	MaTheLoai+6{   �� 5�   *   $��Tên Thể Loại��69    6O   �� *
TenTheLoai+6}   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      