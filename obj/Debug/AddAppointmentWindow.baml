   M S B A M L   `   `   `  ����K  GCalendarSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CalendarSolutionCalendarSolution  5   	   +    %CalendarSolution.AddAppointmentWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CalendarSolution     5   	     � Title$  AddAppointmentWindow��5   	   $	��150��6&   $	��325��63   .��5	      � $��3,5,0,0q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6    $��Subject��6-   �� 5   
   $��0��6   $��1��6    $��
Start Time��6-   �� 5   
   $��0��6   $��2��6    $��End Time��6-   �� 5   
   $��1��6   $��0��6"   $
��Left=�6�   $	��Top=�6�   $	��185��6  ��6/   ��  �� Path$ Subject� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=� �� NotifyOnValidationError .  �� ValidatesOnDataErrors .  �� ValidatesOnExceptions . 6  �� 5   
   $��1��6   $��1��6"   $
��Left=�6�   $	��Top=�6�   $	��185��6  ��6/   �� $ 	StartTime�$ TwoWay=�$ 	LostFocus=� .  .  . 6  �� 5   
   $��1��6   $��2��6"   $
��Left=�6�   $	��Top=�6�   $	��185��6  ��6/   �� $ EndTime�$ TwoWay=�$ 	LostFocus=� .  .  . 6  �� 5   
   -   5        $	��Add��5      $��0��6   $��2��6/   $��3��6C   6P   5      5      