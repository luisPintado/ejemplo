   M S B A M L   `   `   `  ����E  AMUSIC.MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MUSIC.MVVM.ViewModelMUSIC.MVVM.ViewModel  5   	   &     MUSIC.MVVM.Views.ViewMediaCenter   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <viewmodelsong"clr-namespace:MUSIC.MVVM.ViewModel     5   	     � Title$  Reproductor GBM��5   	   $	��350��6!   $	��525��6.    � 	Resources 5      (   "MUSIC.MVVM.ViewModel.ViewModelSong   ViewModelSong��%   &	          5   
   6>   5      .��5	      �  � DataContext 6   ��  �� Source# [  .+�5
   
   �� -   5         ��Name$
 grid��5
      $��
0,60,236,0q�6�   $	��259��6�   $	��Top=�6�    �� SelectedItem 6!   �� *CurrentSong+��6H   ��  �� Path$ CurrentSongs� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�	 �� View	 5      �� 5      .P�5      �� $��Cancion��6%   
 �� Width$
 60��6^    �� DisplayMemberBinding 66   �� *Source+6^   �� 5      $��Duracion��6%   $
 60��6a    67   �� *
Duration+6a   �� 5      $��Autor��6%   $
 60��6[    64   �� *Autor+6[   �� 5      $��Agregar Lista��6%   $	
 100��6<    �� CellTemplate 5      �� 5      .R�5   "   �� $��+��6)   $
��10px��65   $��Center=�6B   ��6_   �� *AddListCommand+ 6�   �� # [  6�   5      5      5       �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         ContainerStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value 5   "   �� 5    &   .R�5!   *   9�  9� 
IsExpanded . ��5"   .   �� 5#   2    �� Orientation$ 
Horizontal=�6=   .+�5$   6   �� $
��Bold"�6\   
���   �$��10(�6�   ��6@   �� $
 Name�6�   �� 5%   6   $��12(�6[   
���  ��$
��Bold"�6z   $��Italic$�6�   $��10,0,0,0q�6�   $��Bottom=�6�   ��6@   �� *	ItemCount+6�   �� 5&   6   $��
 Canciones��6@   $��12(�6R   
�������$��Italic$�6t   $��Bottom=�6�   5'   3   .��5)   .   �� 5*   +   5+   '   5-      5.      50      52      �� 53   
   $
��Left=�6m   $��23��6�   $��
183,14,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��103��6�    J� RenderTransformOrigin$ 1.817,-0.343&�6�    6   �� # [  ��6Q   �� *
TextSearch+6�   �� 54   
   $*��$Portada de Disco                    ��6   $
��Left=�55      $��
296,80,0,0q�60   $	��Top=�6D   $	��229��6\   $	��198��6i   ��56      � 57       6   �� # [  $ CurrentSong� � ColumnDefinitions 58      �� 59      6-   �� 5:      6-    � RowDefinitions 5<      �� 5=      6*   �� 5>      6*   �� 5?      6*   .+�5B      �� $��0��6   $��Album��6,   $��Center=�6<   $��Center=�6Z   $��50��6u   �� 5C      $��1��6   $��0��6,   $
��Left=�6Z   $��Center=�6v   $��90��6�   ��69   �� *
Album.Name+6�   �� 5D      $��0��6   $��1��6,   $
��Año��69   $��Center=�6G   $��Center=�6e   $��50��6�   �� 5E      $��1��6   $��1��6,   $
��Left=�6Z   $��Center=�6v   $��90��6�   ��69   �� *
Album.Year+6�   �� 5F      $��0��6   $��2��6,   $��Genero��69   $��Center=�6J   $��Center=�6h   $��50��6�   �� 5G      $��1��6   $��2��6,   $
��Left=�6g   $��Center=�6�   $��90��6�   ��69   �� *Album.Genre.Description+6�   5H      5J      �� 5K   
   $
��Left=�6�   $��	91,14,0,0q�6�   $	��Top=�6�   $��87��6�    6   �� # [   6Q   �� *SelectedEnumTypeSearch+��6�   �� *ListEnumTypeSearch+5L      �� 5M   
   $��Lista de Reproduccion:��6   $
��Left=�61   $��
328,10,0,0q�6L   $	��Top=�6`   $ 0.499,1.894&�6x   $	��133��6�   �� 5N   
   $
��Left=�5O      $��
312,41,0,0q�6.   $	��Top=�6B   $	��161��6Z    �� DisplayMemberPath$
 Name��5Q       �� SelectedValuePath$
 Name��5R      ��5P      �� $ CurrentListsSongs� 5S      �� $ SelectListSong��� 5U   
   $��
Buscar por��64   $
��Left=�6I   $��	10,17,0,0q�6d   $	��Top=�6w   $��76��6�   ��6   �� *SearchCommand+6�   5V      5W      