   M S B A M L   `   `   `  ����E  AConference, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Conference.PagesConference.Pages  5      #    Conference.Pages.ListViewPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:Conference.Pages     5        N� Title$]  WОрганизация конференций - Просмотр мероприятий��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   6*   �� 5      $��* �6   6)   �� 5      $��70 �6   6*   .+�5   
   �� -   5         ��Name$ DirectionComboBox��5      $
��Left=�5      $��	197,0,0,0q�5       �� DisplayMemberPath$ 
Direction1��5      5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
DatePicker��5      $	��262��5      $��40��6!   $��Center=�5      $��Center=�5      $
��Left=�5      $��	538,0,0,0q�5      5      �� 5   
   -   5         ��Name$ EventListView��5      $��1��5       $��Center=�5!      $��Center=�5"      ��5#      �� 5$      .R�5%      �  � ColumnDefinitions 5&      �� 5'      $	��250 �6/   6=   �� 5(      $��* �6/   6;   .+�5*      �� $	��200��6?   $	��200��6K   $��0��6X   ��6    �� *ImageSource+6X   �� 5+      $��1��6%   $��Center=�5,   %   $��Center=�5-   %   .+�5.      �� ��6(   �� *Title+ �� StringFormat$2 ,Название мероприятия: {0}��5/   N   �� 50      ��6(   �� *SelectedItem.Direction1+	 �� ElementName$	 DirectionComboBox��$8 2Направление мероприятия: {0}���� 52      ��6(   �� *Date+$ Дата: {0:yyyy-MM-dd}��53   I   54      55      56      58      �� 59   
   -   5        
 ��Name$
 LoginButton��59      $��Авторизация��5:      $��Center=�5;      $��Center=�5<      $��2��5=      $��5q�5>      5?   -   5@      5A      