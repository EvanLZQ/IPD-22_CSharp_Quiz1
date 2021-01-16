using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string FILE_NAME = @"..\..\trips.txt";
        private static List<Trip> MyTripList = new List<Trip>();
        public MainWindow()
        {
            InitializeComponent();
            LoadFile();
        }

        private void LoadFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FILE_NAME))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        MyTripList.Add(new Trip(line));
                    }
                }
                InfoListView.ItemsSource = MyTripList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void InfoListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DeleteTripBtn.IsEnabled = true;
                UpdateTripBtn.IsEnabled = true;

                List<Trip> TempTripList = new List<Trip>();
                var MyListItems = InfoListView.SelectedItems;
                if (MyListItems.Count == 0) {}
                else
                {
                    foreach (var item in MyListItems)
                    {
                        TempTripList.Add((Trip)item);
                    }

                    Trip TempTrip = TempTripList[0];

                    DestinationTxt.Text = TempTrip.Destination;
                    NameTxt.Text = TempTrip.Name;
                    PassportTxt.Text = TempTrip.Passport;
                    DepartureDate.SelectedDate = DateTime.Parse(TempTrip.Departure);
                    ReturnDate.SelectedDate = DateTime.Parse(TempTrip.Return);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void AddTripBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DestinationTxt.Text.Length == 0 || NameTxt.Text.Length == 0 ||
                    PassportTxt.Text.Length == 0 || DepartureDate.Text.Length == 0 || ReturnDate.Text.Length == 0)
                {
                    MessageBox.Show("Have to fill every single field to add the trip.", "Missing Info Warning");
                    return;
                }

                Trip NewTrip = new Trip(DestinationTxt.Text, NameTxt.Text, PassportTxt.Text, DepartureDate.Text,
                    ReturnDate.Text);
                MyTripList.Add(NewTrip);
                ResetFields();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void DeleteTripBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (InfoListView.SelectedIndex == -1)
                {
                    MessageBox.Show("Must select a Trip", "Warning");
                    return;
                }
                
                var result = MessageBox.Show("Delete Item?", "Delete Warning", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    Trip DelTrip = (Trip)InfoListView.SelectedItem;
                    MyTripList.Remove(DelTrip);
                }
                ResetFields();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void ResetFields()
        {
            try
            {
                InfoListView.SelectedIndex = -1;
                DeleteTripBtn.IsEnabled = false;
                UpdateTripBtn.IsEnabled = false;
                DestinationTxt.Text = "";
                NameTxt.Text = "";
                PassportTxt.Text = "";
                DepartureDate.SelectedDate = null;
                ReturnDate.SelectedDate = null;
                InfoListView.Items.Refresh();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void UpdateTripBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (InfoListView.SelectedIndex == -1)
                {
                    MessageBox.Show("Must select a Trip", "Warning");
                    return;
                }

                Trip OldTrip = (Trip)InfoListView.SelectedItem;

                Trip NewTrip = new Trip(DestinationTxt.Text, NameTxt.Text, PassportTxt.Text, DepartureDate.Text,
                    ReturnDate.Text);

                foreach (Trip trip in MyTripList)
                {
                    if (trip.IsSameTrip(OldTrip))
                    {
                        trip.MakeCopyOf(NewTrip);
                        break;
                    }
                }
                ResetFields();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Trip> SaveTrips = new List<Trip>();
                var SelectList = InfoListView.SelectedItems;
                if (SelectList.Count == 0)
                {
                    MessageBox.Show("You must select at least 1 trip to save.", "Warning");
                    return;
                }

                foreach (var item in SelectList)
                {
                    SaveTrips.Add((Trip)item);
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Trip file (*.trips)|*.trips";
                if (saveFileDialog.ShowDialog() == true)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (Trip trip in SaveTrips)
                        {
                            sw.WriteLine(trip.ToDataString());
                        }
                    }
                }
                ResetFields();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private void InfoListView_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            HitTestResult r = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (r.VisualHit.GetType() != typeof(ListBoxItem))
            {
                InfoListView.UnselectAll();
                ResetFields();
            }
        }
    }
}
