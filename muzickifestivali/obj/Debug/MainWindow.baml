   M S B A M L   `   `   `  ����K  Gmuzickifestivali, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:muzickifestivalimuzickifestivali  5   	   !    muzickifestivali.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:muzickifestivali     5   	   -   5          � Title$  
MainWindow��5   	   $	��442��6   $	��821��6)   ��5	      �� 5
   
    �� ImageSource$ Images/pozadina3.png��6   -   5        pozadina�� �� Opacity$	 0.7Q�5
   J   6Z   .��5      � .+�5   
   � -   5         �Name$ 	loginGrid��5      $y�Visible=�6"   .+�5      �� $��Korisnicko ime: ��6   $
��Left=�60   $��	35,80,0,0q�6K   $	��Top=�6^   $	��176��6v   $��20(�6�   $��Normal"�6�   $��	Tw Cen MT)�6�   �� 5      -   5         ��Name$ korisnickoIme��5      $
��Left=�6-   $��
188,87,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $��Unesite ime��6p   $	��Top=�6�   $	��120��6�   6�   �� 5      $��Lozinka:��6   $
��Left=�6)   $��
35,130,0,0q�6D   $	��Top=�6X    J� RenderTransformOrigin$ 1.231,0.502&�6p   $��20(�6�   $��	Tw Cen MT)�6�   $	��119��6�   �� 5      -   5        $��prijava��5      $��Prijava��6$   $
��Left=�66   $��
94,194,0,0q�6Q   $	��Top=�6e   $	��130��6}   $��	Tw Cen MT)�6�   $��30��6�   G� 5      -   5         G�Name$ lozinka��5      $
��Left=�6+   $��188,137,0,0q�6F   $	��Top=�6[   $	��120��6s   6�   �� 5      -   5        $��izlaz��5      $��Izlaz��6"   $
��Left=�62   $��
93,247,0,0q�6M   $	��Top=�6a   $ -0.293,-0.369&�6y   $	��130��6�   $��	Tw Cen MT)�6�   $��30��6�   �� 5      -   5         ��Name$ tbUsernameError��5      $��10(�61   
���  ��$
��Left=�6P   $��188,105,0,0q�6k   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   $��Normal"�6�   �� 5      -	   5        $ tbPasswordError��5      $��10(�61   
���  ��$
��Left=�6P   $��188,155,0,0q�6k   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5      $��Prijava��6   $
��Left=�6&   $��	35,10,0,0q�6A   $	��Top=�6T   $
��Bold"�6l   $��36(�6~   $��	Tw Cen MT)�6�   5      � 5   
   -
   5        $ 
loggedGrid��5      $y�Hidden=�6#   .+�5      �� -   5        	 ��Name$	 lblUser��5      $�� ��6&   $��Center=�61   $
��Left=�6U   $��69��6p   $��24��6{   $	��Top=�6�   $
��Bold"�6�   ��6�   Z� �� 5      -   5        
 ��Name$
 btnDodaj��5      $��Dodaj��6'   $
��Left=�67   $��100,150,0,0q�6R   $	��150��6g   $��40��6s   $	��Top=�6   6�   �� 5      -   5        $
 
btnIzbrisi��5      $��Izbrisi��6)   $
��Left=�6;   $��100,200,0,0q�6V   $	��150��6k   $��40��6w   $	��Top=�6�   6�   �� 5      -   5        $
 btnIzlaz��5      $��Izlaz��6'   $
��Left=�67   $��100,250,0,0q�6R   $	��150��6g   $��40��6s   $	��Top=�6   6�   5       � 5"   
   -   5        $ tabela��5"      $y�Visible=�6   $��342,23,10,50q�64   .+�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridData��5#         SelectionMode$ Extended=�6-   $��18(�6G      AutoGenerateColumns .     CanUserReorderColumns .     CanUserAddRows .  $��	-21,0,0,0q�6�   ��6U   �� *	Kolekcija+   Columns 5$      4  .System.Windows.Controls.DataGridCheckBoxColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Select��6.   -   5        cbDelete��   
IsReadOnly .     Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5%   �   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *
IsSelected+6�   5  /System.Windows.Controls.DataGridHyperlinkColumn  5&      $ Tekst��6.    . $ * 6O   -   5        	hyperlink�� 5&   Y   �� *Naziv+   ElementStyle 5'      �� 5(      .�5)   "   -   5        5*      5,      4  .System.Windows.Controls.DataGridTemplateColumn  5-      -   5        	imageGrid��$ Slika��5-   @    . $ * 6a      CellTemplate 5.      �� 5/      .R�50   "   �� $��50��6A   $	��100��6M   ��6(   �� *Slika+6\   51      53      0  *System.Windows.Controls.DataGridTextColumn  54      $ Datum��6)    . $ * 6d      FontSize$ 15Q�6n    68   �� *Datum+6~   56      59      5;      5=      