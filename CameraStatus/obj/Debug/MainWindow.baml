   M S B A M L   `   `   `  ����G  CCameraStatus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CameraStatusCameraStatus  5   	       CameraStatus.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CameraStatus     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  CameraStatus��5   	   $	��450��6   $	��600��6+      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � DataContext 5          CameraStatus.MainViewModel  5   
    � 	Resources 5      +   %CameraStatus.SubstractButtonConverter  SubstractButtonConverter��%   &	         5   
   6L   5      .��5      �� .+�5   
   �� -   5        $��
MyListView��5      ���#d4dee4��6&   �� *	Cameras+��5   
   �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   $	��Top=�6Q   5      ��5!   
   �� 5"      .R�5$      � $��MainGrid��6   $	��300��6'   $	��150��64    � RowDefinitions 5%      �� 5&      $��* �6(   �� 5'      $��4* �6(   �� 5(      $��4* �6(   .+�5+      � $��0��6   ���#08358f6(   � 5,      $��1��6   
�������6(   � 5-      $��2��6   
�������6(   �� 5/      $��0��6    $��Center=�6a   $��Center=�50       $��30(�6;   $��Comic Sans MS)�6I   
���������5/   -   ��  �� Path$ Id� �� StringFormat$ 
Camera {0}��50   d   �� 52      $��Btn_Add��6   $��1��6,   
������ $��50��6R     MaterialDesignRaisedButton#���  56      +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth4=�57      ��53   !   �� 
 �� ElementName$
 
MyListView��$" DataContext.AddPeopleCommand���54   !   �� $ Id�{�55   !   �� *isCashDeskOpen+.��59      �� $��	ButtonAdd��6    $(��"Resources/add-circle-green-512.png��61   5:      �� 5<      $��Btn_Substract��6   $��2��62   
������ $��50��6X   #���  5?      $	 Depth4=�5@      ��5=   !   �� $
 
MyListView��$% DataContext.RemovePeopleCommand���5>   !   �� $ Id�{�5A      �� $ IsRemoveButtonDisabled�.��5C      �� $��ButtonSubstract��6    $+��%Resources/subtract-circle-red-512.png��67   5D      5H      5I      5K      �� 5L   
   -   5        $��Btn_RedirectToReports��5L      $��30��6.   $	��200��6:   #���  5M      $	 Depth4=�5N      $��Show Report��5O      5P      5Q      5S      