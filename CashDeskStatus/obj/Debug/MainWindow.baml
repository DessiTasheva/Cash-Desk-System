   M S B A M L   `   `   `  ����I  ECashDeskStatus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CashDeskStatusCashDeskStatus  5   	       CashDeskStatus.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CashDeskStatus     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  CashDeskStatus��5   	   $	��480��6    $	��800��6-      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � DataContext 5      "   CashDeskStatus.MainViewModel  5   
    � 	Resources 5      )   #CashDeskStatus.EnumToColorConverter  EnumToColorConverter(  "CashDeskStatus.OpenButtonConverter  OpenButtonConverter��%:   &	       &	        5   
   6%     5   
   6$   5      .��5      �� -   5        $��
MyListView��5      ��6"   �� *	CashDesks+��5   
   �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   $	��Top=�6Q   5      ��5!   
   �� 5"      .R�5#      �� 
�������$��1q�6-   ._�5$      � $��MainGrid��6   $	��420��6+   $	��230��68    � RowDefinitions 5%      �� 5&      $
��1.5* �6,   �� 5'      $��* �6,   �� 5(      $
��1.5* �6,   �� 5)      $
��4.5* �6,   �� 5*      $��* �6,   �� 5+      $
��0.5* �6,   .+�5.      � $��0��6   ���#08358f6,   �� 50      
�������$��1q�65   ._�51      �� $��0��6`   $��35(�6m   $��Center=�52   (   $��Center=�6C   $��Comic Sans MS)�6`   
���������51   (   ��  �� Path$ Id� �� StringFormat$ Cash Desk {0}��52   {   53      �� 55      $��1��6!   
�������$��1q�6B   ._�56      �� $��Comic Sans MS)�6q   $��20(�6�   $��Center=�6�   $��Center=�6�   ��6(   �� $ PeopleCount�$ Number of people: {0}��6�   57      �� 58      $��2��6!   
�������$��1q�6B   ._�59      � 	 � ColumnDefinitions	 5:   "   �� 5;   &   $��3* �67   �� 5<   &   $��* �67   .+�5?   "   A� $��1��6*   $��40��5@   O   $��40��6Z   ��5?   :   �� $ State�
 �� 	Converter#
 [ 5@   h   �� 5C   "   $��0��6(   $��State of Cash Desk:��68   $��Comic Sans MS)�6W   $
��Left=�5D   (   $��Center=�6D   $��17(�6_   6o   5E      5F      �� 5H      $��3��6!   
�������$��1q�6B   ._�5I      �� $��CashDeskPicture��6$   $��10q�6;   $��Resources/Cash_desk.jpg��6G   5J      � 5L      $��4��6   	 5M      �� 5N   "   $��* �63   �� 5O   "   $��* �63   .+�5Q      �� $��
OpenButton��6%   $��0��67   $
��Open��6G   $��Comic Sans MS)�6V   
�������{�5R   %   �� $ IsOpen�#
 [ ��5S   %   ��  �� ElementName$ 
MyListView��$% DataContext.OpenCashDeskCommand���5T   %   �� $ Id�5V      �� 5W      $��CloseButton��6%   $��1��68   $��Close��6I   $��Comic Sans MS)�6Y   
�������{�5X   %   �� $ IsOpen���5Y   %   �� $ 
MyListView��$&  DataContext.CloseCashDeskCommand���5Z   %   �� $ Id�5\      5^      5`      5c      5d      5f      5k      