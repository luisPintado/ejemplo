   M S B A M L   `   `   `  ����E  AMUSIC.MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MUSIC.MVVM.ViewModelMUSIC.MVVM.ViewModel  5   	   #    MUSIC.MVVM.Views.ViewPlayList   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8	modelView"clr-namespace:MUSIC.MVVM.ViewModel     5   	     � Title$  Agregar PlayList��5   	   $	��172��6"   $	��300��6/    � 	Resources 5      ,   &MUSIC.MVVM.ViewModel.ViewModelListSong   ViewModelListSong��%   &	          5   
   6B   5      .��5	   
   � -   5         �Name$
 grid��5	       � DataContext 6   ��  �� Source# [  .+�5
      �� -   5         ��Name$ combo��5
      $
��Left=�6&   $��	26,45,0,0q�6A   $	��Top=�6T   $	��225��6l    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$
 Name��5      ��5      �� *CurrentListsSongs+ �� SelectedItem 5      �� *SelectListSong+	 �� SelectedValue	 5      �� *SelectListSong+�� 5      $��Lista a seleccionar:��6   $
��Left=�63   $��	25,22,0,0q�6N   $	��Top=�6a   $	��201��6y   �� 5      $
��Left=�6,   $��23��6G   $��
25,108,0,0q�6S   
 �� TextWrapping$

 Wrap=�6g   $	��Top=�6|   $	��120��6�   ��6   �� *Name+6�   �� 5      $!��Crear Nueva                ��6   $
��Left=�5      $��	25,82,0,0q�6-   $	��Top=�6@   �� 5      $��Agregar��6   $
��Left=�6(   $��195,108,0,0q�6C   $	��Top=�6X   $��75��6p   ��6|   �� *SubmitCommand+5      5      