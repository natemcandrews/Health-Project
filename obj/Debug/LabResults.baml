   M S B A M L   `   `   `  ����K  GCalendarSolution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CalendarSolutionCalendarSolution  5      !    CalendarSolution.LabResults   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X TXceed.Wpf.Toolkit, Version=4.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      *localclr-namespace:CalendarSolution  5        N� Title$  
LabResults��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��25 �6   �� 5      $
��Auto �6   �� 5      $��25 �6   �� 5      $
��Auto �6   �� 5      $��25 �6   �� 5      $
��Auto �6   �� 5      $��25 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   .+�5&   
   �� $
��CBC:��6   �� 5'   
   $	��100��6   $��1��6   ��6.   �� *CBC+ �� Mode$ TwoWay=��� 5(   
   $
��WBC:��6   $��3��6   �� 5)   
   $	��100��6   $��3��6   $��1��6+   ��6;   �� *WBC+$ TwoWay=��� 5*   
   $
��RBC:��6   $��5��6   �� 5+   
   $	��100��6   $��5��6   $��1��6+   ��6;   �� *RBC+$ TwoWay=��� 5,   
   $��Time of Test:��6   $��7��6(   "  Xceed.Wpf.Toolkit.TimePicker  5-   
   $��7��6@   $��1��6M   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 6   �� *	LabTime+$ TwoWay=�6M   �� 5/   
   $��PT/PTT:��6   $��2��6"   �� 50   
   $	��100��6   $��3��6   ��6.   �� *PTT+$ TwoWay=��� 51   
   $��Hemoglobin:��6   $��2��6&   $��3��66   �� 52   
   $	��100��6   $��3��6   $��3��6.   ��6;   �� *
Hemoglobin+$ TwoWay=��� 53   
   $��Hematocrit:��6   $��2��6&   $��5��66   �� 54   
   $	��100��6   $��3��6   $��5��6.   ��6;   �� *
Hematocrit+$ TwoWay=��� 55   
   $��Date of Test:��6   $��7��6(   $��2��65   (  "System.Windows.Controls.DatePicker  56   
   $��2��6   $��6��6%   $��2��6X   $��27��6l   $��78.5,0,0.5,0q�6x   $��2��6�   $��Bottom=�6�      Text 62   �� *	LabDate+$ TwoWay=�6�   �� 58   
   $��
Platelets:��6   $��5��6%   �� 59   
   $	��100��6   $��6��6   ��6.   �� *	Platelets+$ TwoWay=��� 5:   
   $
��A1C:��6   $��5��6   $��3��6/   �� 5;   
   $	��100��6   $��6��6   $��3��6.   ��6;   �� *A1C+$ TwoWay=��� 5<   
   $��Glucose:��6   $��5��6#   $��5��63   �� 5=   
   $	��100��6   $��6��6   $��5��6.   ��6;   �� *	Glucose+$ TwoWay=��� 5>   
   $��Doctor��6   $	��100��6!   $��5��6-   $��7��6=   �� 5?   
   $	��100��6   $��6��6   $��7��6.   ��6;   �� *Doc+$ TwoWay=�5A      5B      