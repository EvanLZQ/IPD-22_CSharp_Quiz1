   M S B A M L   `   `   `  ����?  ;Quiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QuizQuiz  5   	       Quiz.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Quiz     5   	     � Title$  Travel��5   	   $	��450��6   $
��1000��6%    � WindowStartupLocation$ CenterScreen=�62   .��5	      � .+�5
   
   �� -   5        $��Save Selected��5
      $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $	��240��6o   6{   �� 5   
   -   5        $��InfoListView��5      $
��Left=�6'   $	��356��6B   $��	10,54,0,0q�6O   $	��Top=�6b   $	��473��6z    �� View 5      �� 5      .P�5      �� $��Destination��6%    �� Width$ 92��6:    �� DisplayMemberBinding 6E   �� *Destination+�� 5      $
��Name��6%   $ 92��63    6>   �� *Name+�� 5      $��Passport��6%   $ 92��67    6B   �� *
Passport+�� 5      $��	Departure��6%   $ 92��68    6C   �� *	Departure+�� 5      $��Return��6%   $ 92��65    6@   �� *Return+5      5      �� 5   
   $��Destination��6   $
��Left=�6&   $��
501,55,0,0q�6A   $	��Top=�6U   �� 5   
   $
��Name��6   $
��Left=�6   $��501,110,0,0q�6:   $	��Top=�6O   �� 5   
   $��Passport��6   $
��Left=�6#   $��501,165,0,0q�6>   $	��Top=�6S   �� 5   
   $��	Departure��6   $
��Left=�6$   $��501,220,0,0q�6?   $	��Top=�6T   �� 5   
   $��Return��6   $
��Left=�6!   $��501,275,0,0q�6<   $	��Top=�6Q   �� 5   
   -   5        $��DestinationTxt��5      $
��Left=�6(   $��23��6C   $��
622,55,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��335��6�   �� 5   
   -   5        $��NameTxt��5      $
��Left=�6!   $��23��6<   $��622,110,0,0q�6H   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��335��6�   �� 5   
   -   5        $��PassportTxt��5      $
��Left=�6%   $��23��6@   $��622,165,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��335��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��DepartureDate��5      $
��Left=�6*   $��622,220,0,0q�6E   $	��Top=�6Z   $	��335��6r     5   
   -   5        $��
ReturnDate��5      $
��Left=�6'   $��622,275,0,0q�6B   $	��Top=�6W   $	��335��6o   �� 5    
   -   5        $��
AddTripBtn��5       $��Add Trip��6#   $
��Left=�66   $��501,357,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5!   
   -	   5        $��DeleteTripBtn��5!      $��Delete Trip��6&   $
��Left=�6<   $��706,357,0,0q�6W   $	��Top=�6l   $��75��6�   {�.  6�   �� 5"   
   -
   5        $��UpdateTripBtn��5"      $��Update Trip��6&   $
��Left=�6<   $��882,357,0,0q�6W   $	��Top=�6l   $��75��6�   {�.  6�   5%      5&      