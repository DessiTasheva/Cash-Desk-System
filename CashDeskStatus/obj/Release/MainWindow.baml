   M S B A M L   `   `   `  ���� I  ECashDeskStatus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CashDeskStatusCashDeskStatus      CashDeskStatus.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:CashDeskStatus     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  CashDeskStatus��$	��480��$	��800��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � DataContext &    CashDeskStatus.CashDeskViewModel   � 	Resources )   #CashDeskStatus.EnumToColorConverter  EnumToColorConverter(  "CashDeskStatus.OpenButtonConverter  OpenButtonConverter��%   &	       &	          .���� -   $��
MyListView������ *	CashDesks+���� .R���  �� Orientation$ 
Horizontal=�$
��Left=�$	��Top=����� .R��� 
�������$��1q�._�� $��MainGrid��$	��420��$	��230�� � RowDefinitions �� $
��1.5* ��� $��* ��� $
��1.5* ��� $
��4.5* ��� $��* ��� $
��0.5* �.+�� $��0�����#08358f�� 
�������$��1q�._��� $��0��$��35(�$��Center=�$��Center=�$��Comic Sans MS)�
�����������  �� Path$ Id� �� StringFormat$ Cash Desk {0}���� $��1��
�������$��1q�._��� $��Comic Sans MS)�$��20(�$��Center=�$��Center=����� $ PeopleCount�$ Number of people: {0}���� $��2��
�������$��1q�._�� 	 � ColumnDefinitions	 �� $��3* ��� $��* �.+�A� $��1��$��40��$��40������ $ State�
 �� 	Converter#
 [ �� $��0��$��State of Cash Desk:��$��Comic Sans MS)�$
��Left=�$��Center=�$��17(��� $��3��
�������$��1q�._��� $��CashDeskPicture��$��10q�$��Resources/Cash_desk.jpg��� $��4��	 �� $��* ��� $��* �.+��� $��
OpenButton��$��0��$
��Open��$��Comic Sans MS)�
�������{��� $ IsOpen�#
 [ ����  �� ElementName$ 
MyListView��$% DataContext.OpenCashDeskCommand����� $ Id��� $��CloseButton��$��1��$��Close��$��Comic Sans MS)�
�������{��� $ IsOpen����� $ 
MyListView��$&  DataContext.CloseCashDeskCommand����� $ Id�