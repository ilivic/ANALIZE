   M S B A M L   `   `   `  ����C  ?AdminApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AdminApp.PagesAppAdminApp.PagesApp  5          AdminApp.PagesApp.PageReg   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:AdminApp.PagesApp     5        N� Title$  PageReg��5	       � 	Resources 5
       �� 
TargetType �� Property �� Value��%\   '��       �� 5   
   " ��6   .�5      ��  �@��	MaxLength$ 49��6*   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��1��6   $��Center=�6%   .+�5      �� $��Имя��6   �� 5      -   5         ��Name$ TxtName��5      �� 5      $��Телефон��6   �� 5      -   5        $ TxtPhone��5      $��+7��6(    �� 	MaxLength$ 12��62   6A   �� 5      $��
почта��6   �� 5      -   5        $ TxtEmail��5      6(   �� 5      $��
Логин��6   �� 5      -   5        $ TxtLogin��5      �� 5      $��Пароль��6   �� 5      -   5        $ TxtPassword��5      �� 5        �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5!      �� -   5        $��выбрать фото��5!      $��Center=�60   6K   �� 5"      -   5        	 ��Name$	 ImgAdmin��5"      $	��150��6*   $	��150��66   5#      �� 5$      $��День рождения��6   (  "System.Windows.Controls.DatePicker  5%      -   5        
  Name$
 	DateBirth��5%   5      DisplayDateEnd$ 
05-30-2009X�6   65   �� 5&      $ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5'      �� -	   5        $��Регистрация��5'      
��� ���$��10q�6C   6P   �� 5(      -
   5        $��Авторизация��5(      
����·�$��10q�6D   6Q   5)      5*      5+      5,      