   M S B A M L   `   `   `  ����K  GCalendarSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CalendarSolutionCalendarSolution  5   	   &     CalendarSolution.PatientDataBase   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CalendarSolution     5   	     � Title$  Patient Data Base��5   	   $	��595��6#   $
��1000��60   .��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5!   
   �� -   5        $��patientLabel��5!      $��2q�6$   $��Center=�6/   .��6Q   _Patient Name:6a   �� 5$   
   -   5        $��Open Vital Form��5$      $��1��6+   $��2, 40, 0, 0q�68   6b   �� 5%   
   -   5        $��Open Medical History Form��5%      $��2��65   $��2,40,0,0q�6B   6g   �� 5&   
   -   5        $��Open Demographics Form��5&      $��3��62   $��2,40,0,0q�6?   6d   �� 5'   
   -   5        $��Open Immunizations Form��5'      $��4��63   $��2,40,0,0q�6@   6g   �� 5(   
   -   5        $��Open Urinalysis Form��5(      $��5��60   $��2,40,0,0q�6=   6h   �� 5)   
   -   5        $��Open Lab Form��5)      $��6��6)   $��2,40,0,0q�66   6Z   �� 5*   
   -   5        $��Open Progress Form��5*      $��7��6.   $��2,40,0,0q�6;   6`   �� 5,   
   -	   5        $��Upload New Image��5,      $��8��6,   $��	2,30,0,10q�69   6b   �� 5-   
   -
   5        $��Open Saved Image��5-      $��9��6,   $��2,0,0,0q�69   6^   �� 5.   
   $��8��6[   $��20��6h   $��162, 40,-135,1q�6t   ��6   �� *	cbItems+ �� SelectedItem 63   �� *SelectedcbItem+6t   �� 5/   
   $��100, 0, 0, 0q�6   $
��Auto��6&   $��Center=�6S   ��63   �� *PatientName+6S    � 51   
   -   5        $��frame1��51      $��0��6   $��1��6+   $	��800��6;   $	��450��6G   $��8��6T   $��2q�6e   
���   �$��5q�6�   $��Center=�6�   �� 53   
   -   5        $��graphCanvas��53      $��1��6$   $��8��64   $��60��6A   .+�54      �� -   5        $��Vitals Graph��54       �� Left$	 250��6,   
 �� Top$ 40��6>   $	��150��6N   6Z   �� 55      $��20��6^   $	 425��6j   $ 40��6|   $	��150��6�   ��6   �� *	vitalCB+ 67   �� *selectedVital+6�   �� 56      -   5        $��Show Patient Information��56      $	 650��68   $ 40��6J   $	��150��6Z   6f   57      5:      5>      