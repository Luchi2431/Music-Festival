   M S B A M L   `   `   `  ����K  Gmuzickifestivali, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:muzickifestivalimuzickifestivali  5   	       muzickifestivali.Prikaz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:muzickifestivali     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Prikaz��5
   	   $	��450��6   $	��800��6%   ��5      �� 5   
    �� ImageSource$ Images/pozadina.jpg��6   -   5        PozadinaDodavanje�� �� Opacity$	 0.5Q�5   R   6b   .��5      � .+�5   
   �� 
�������$��Godina osnivanja:��6#   $
��Left=�6?   $��	54,43,0,0q�6Z   $	��Top=�6m   $	��145��6�   �� 5   
   -   5         ��Name$ tbPrikazGodina��5      $
��Left=�6*   $��
183,47,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $��TextBox��6m   $	��Top=�6|   $	��120��6�   �� 5   
   
�������$��Naziv festivala:��6#   $
��Left=�6>   $��	54,96,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5        $ tbPrikazNaziva��5      $
��Left=�6*   $��183,100,0,0q�6E   $
 Wrap=�6Z   $��TextBox��6n   $	��Top=�6}   $	��120��6�   �� 5   
   
�������$��Datum dodavanja:��6"   $
��Left=�6=   $��
54,142,0,0q�6X   $	��Top=�6l   �� 5   
   -   5        $ tbPrikazDatuma��5      $
��Left=�6*   $��183,146,0,0q�6E   $
 Wrap=�6Z   $��TextBox��6n   $	��Top=�6}   $	��120��6�   �� 5   
   
�������$��Opis dogadjaja:��6#   $
��Left=�6=   $��
54,191,0,0q�6X   $	��Top=�6l   �� 5   
   -   5         ��Name$ 	rtbPrikaz��5      $��54,217,497,0q�6)    J� RenderTransformOrigin$ 0.468,0.519&�6?   $	��186��6c   $	��Top=�6p   5      �� 5   
   -   5         ��Name$ PrikazSlika��5      $
��Left=�6%   $	��199��6@   $��
373,88,0,0q�6M   $	��Top=�6a   $	��297��6y   �� 5   
   -   5        	 ��Name$	 btnIzlaz��5      $��Izlaz��6#   $
��Left=�63   $��455,335,0,0q�6N   $	��Top=�6c   $��28��6{   $	��120��6�   6�   5      5      