   M S B A M L   `   `   `  ����  PCSX2FFXAutoRender'    !PCSX2FFXAutoRender.MainWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$2  ,FFX Main Menu Auto Render Switcher for PCSX2��5   	   $	��295��6>   $	��600��6K    � 
ResizeMode$ NoResize=�5   	    � DataContext 5	   	   ��  �� RelativeSource �� *Self+.��5
      � ���	#FF2F2F2F � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   .+�5      �� $��Process Name��6   $
��Left=�6+   $	��Top=�6F   $��90��6^   
�������5      �� 5      -   5         ��Name$ processName��5      $
��Left=�6+   $��3q�6F    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�5      $	��120��6.   
�������
���   �6`   �� 5      $
��Left=�6\   $	��Top=�6w   $��90��6�   ��6   �� *53ViewModel.Model.ApplicationRunningValueDisplay.Text+��6�   �� *75ViewModel.Model.ApplicationRunningValueDisplay.Colour+5      � 5   
   $��1��6   .+�5      �� $��	PCSX2.exe��6   $
��Left=�6(   $	��Top=�6C   $��90��6[   
�������6f   �� 5      -   5        $ pcsx2Location��5      $
��Left=�6-   $��3q�6H   $
 Wrap=�6S   $��C:\pcsx2-qt.exe��5      $	��Top=�6-   $	��420��6E   
�������
���   �|�.  5    <   �� 5!      -   5        $	��...��5!      $��20��6#   $��20��6.   6:   5"      � 5$   
   $��2��6   .+�5%      �� $��FFX.iso��6   $
��Left=�6&   $	��Top=�6A   $��90��6Y   
�������6d   �� 5&      -   5        $ ffxLocation��5&      $
��Left=�6+   $��3q�6F   $
 Wrap=�6Q   $��
C:\FFX.iso��5'      $	��Top=�5(      $	��420��6.   
�������
���   �|�.  6`   �� 5)      -   5        $	��...��5)      $��20��6#   $��20��6.   6:   5*      �� 5,   
   $��3��6   $��2q�6   ���	#FFA4A4A4._�5-      �  � Orientation$ Vertical=�6   .+�5.      � .+�5/      �� $-��'Value at offset 0x20703FF3 (Main Menu):��6   $��5q�6N   $
��Left=�6Y   $	��Top=�50      $	��250��64   $��Oblique$�51      
�������60   �� 52      .+�53      � .+�54      �� $
��Left=�6d   $��30��55   !   $	��Top=�6.   $��5q�6F   ��54   $   �� *-+.ViewModel.Model.MainMenuValueDisplay.Value+��55   Q   �� *-+ViewModel.Model.MainMenuValueDisplay.Colour+�� 56      $
��Left=�6c   $	��150��57   $   $	��Top=�62   $��5q�6J   ��56   $   �� *+)ViewModel.Model.MainMenuValueDisplay.Text+��57   U   �� *-+ViewModel.Model.MainMenuValueDisplay.Colour+58      59      5:      � 5<      .+�5=      �� $2��,Value at offset 0x8D78D7 (Sphere Grid Menu):��6   $��5q�6S   $
��Left=�6^   $	��Top=�5>      $	��250��64   $��Oblique$�5?      
�������60   �� 5@      .+�5A      � .+�5B      �� $
��Left=�6j   $��30��5C   $   $	��Top=�61   $��5q�6I   ��5B   $   �� *31.ViewModel.Model.SphereGridMenuValueDisplay.Value+��5C   T   �� *31ViewModel.Model.SphereGridMenuValueDisplay.Colour+�� 5D      $
��Left=�6i   $	��200��5E   $   $	��Top=�62   $��5q�6J   ��5D   $   �� *1/ViewModel.Model.SphereGridMenuValueDisplay.Text+��5E   U   �� *31ViewModel.Model.SphereGridMenuValueDisplay.Colour+5F      5G      5H      � 5J      .+�5K      �� $.��(Value at offset 0x3757F3C (Render Mode):��6   $��5q�6O   $
��Left=�6Z   $	��Top=�5L      $	��250��5M      $��Oblique$�6(   
�������6<   �� 5N      .+�5O      � .+�5P      �� $
��Left=�6f   $��30��5Q   $   $	��Top=�61   $��5q�6I   ��5P   $   �� */-.ViewModel.Model.RenderModeValueDisplay.Value+��5Q   T   �� */-ViewModel.Model.RenderModeValueDisplay.Colour+�� 5R      $
��Left=�6e   $	��150��5S   $   $	��Top=�62   $��5q�6J   ��5R   $   �� *-+ViewModel.Model.RenderModeValueDisplay.Text+��5S   U   �� */-ViewModel.Model.RenderModeValueDisplay.Colour+5T      5U      5V      5X      5Y      � 5[   
   $��4��6   $��Center=�6!   .+�5\      �� -   5         ��Name$ 	longStart��5^      	 � ToolTip$�	 |Use  this if the emulator is not yet open, to start up the emulator. Ensure Hardware Render Mode is enabled before clicking.��5]      $��Start From Boot��5^   %   $��5q�6?   $
��Left=�6J   $	��Top=�6e   $	��150��6}   $��38��6�   $��16(�5_      $��8q�6   6,   �� 5`      -   5        $ 
quickStart��5b      $=	 7Ensure Hardware Render Mode is enabled before clicking.��5a      $��Quick Start��5b   %   $��5q�6<   $
��Left=�6G   $	��Top=�6b   $	��150��6z   $��38��6�   $��16(�5c      $��8q�6   6+   �� 5d      -   5        $*	 $Stop reading data from the emulator.��5e      $
��Stop��5f      $��5q�6    $
��Left=�6+   $	��Top=�6F   $��70��6^   $��38��6i   $��16(�5g      $��8q�6   6,   5h      5k      5l      