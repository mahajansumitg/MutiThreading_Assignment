   M S B A M L   `   `   `  ����T  PMultiThreading_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:MultiThreading_Assignment.ViewModel#MultiThreading_Assignment.ViewModel  5      +    %MultiThreading_Assignment.View.UIView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:MultiThreading_Assignment.ViewModel     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  UIView��5      $��20q�6    N� 
Background �	#FFB8B8B8 N� 
Foreground
 �   � � 	Resources 5      5   /MultiThreading_Assignment.ViewModel.UIViewModel   UIVM��%   &	          5   
   6   5      .��5      � -   5        $��	inputGrid��5       � DataContext 6   ��  �� Source# [   � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��No. of custommers  :��6   $��0��6/   $��0��6?   $��Center=�6L   $��Center=�6i   
���   �6�   �� 5   
   $��No. of Threads  :��6   $��0��6,   $��1��6<   $��Center=�6I   $��Center=�6f   
���   �6�   �� 5!   
    % !MaterialDesignFloatingHintTextBox#��[ 5"      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ No. of Customers��6M   $��Center=�5#      $��1��66   $��0��6F   $	��100��6S   $��Center=�6_   $��Center=�6|   
���������5!      �� *NoOfCustommers+	 �� Mode$	 TwoWay=�5#   �   �� 5$   
   #��[ 5%      $ No. of Threads��6M   $��Center=�5&      $��1��66   $��1��6F   $	��100��6S   $��Center=�6_   $��Center=�6|   
���������5$      �� *NoOfThreads+$	 TwoWay=�5&   �   �� 5(   
   $��Start��6    $  MaterialDesignRaisedAccentButton#��[ 5)      +  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth3=�6K   +  %MaterialDesignThemes.Wpf.RippleAssist   Feedback �	#DD000000$��0��5*      $��2��6!   $	��100��6.   $��Center=�6:   $��Center=�6W   ��5(   %   �� *	StartOP+5*   W   �� 5+   
   $��	Reset All��6   #��[ 5,      $
 Depth3=�6K    �	#DD000000$��1��5-      $��2��6!   $	��100��6.   $��Center=�6:   $��Center=�6W   ��5+   %   �� *
ResetAll+5-   W   �� 5.   
   $
��Exit��6   #��[ 5/      $
 Depth3=�6K    �	#DD000000$��0��50      $��2��6!   $��4��65   $	��100��6B   $��Center=�6N   $��Center=�6k   ��5.   %   �� *	ExitApp+50   k   52      54      