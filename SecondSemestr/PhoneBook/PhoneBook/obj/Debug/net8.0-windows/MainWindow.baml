   M S B A M L   `   `   `  ����D  @PhoneBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PhoneBook	PhoneBook  5   	       PhoneBook.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PhoneBook     5   	     � Title$  	PhoneBook��5   	   $	��450��6   $	��800��6(   $	��300��64   $	��510��6D   ��5	      �� 5
   
    �� ImageSource$ Resources/back.jpg��6   68   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ richTextBox��5      $��0��6+   $��0��6;   $��5q�6H    � 	Resources 5       �� 
TargetType �� Property �� Value��%X   'J�       �� 5      " J�6   .�5      ��  �@��Margin$ 0q�6/   5      5       5!      �� 5$   
   $��1��6   $��0��6%   $��5q�62   	 �� Orientation$	 Vertical=�6=   $��Right=�6T   .+�5%      �� -   5        $��Очистить��5%      $��95��6(   $��5q�63   6>   �� 5&      -   5        $��Сохранить��5&      $��95��6)   $��5q�64   6?   �� 5'      -   5        $��Удалить��5'      $��95��6'   $��5q�62   6=   �� 5(      -   5        $ ��Редактировать��5(      $��95��6-   $��5q�68   6C   5)      �� 5,   
   $��0��6   $��1��6%   $	 
Horizontal=�62   $
��Left=�6K   $��5q�6f   .+�5-      �� $	 Vertical=�6   $��5q�60   .+�5.      �� $��ФИО��6   
�������6&   �� 5/      -   5        
 ��Name$
 textBox1��5/      $	��120��6,   50      �� 51      $	 Vertical=�6   $��5q�60   .+�52      �� $!��Номер телефона��6   
�������61   �� 53      -   5        $
 textBox2��53      $	��120��6,   54      �� 55      $	 Vertical=�6   $��5q�60   .+�56      �� -   5        $��Добавить��56      $��95��6,   $��5q�67   6B   �� 57      -	   5        $��
Найти��57      $��95��6)   $��5q�64   6?   58      59      5:      5;      