using DataModels;
using System;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Collections;
using Windows.Devices.Printers;
using Windows.UI.Core;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using System.Reflection;
using Windows.UI.Xaml.Media;
using Windows.UI.ViewManagement;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShivitoMGO_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Student> listOfStudents = new List<Student>();
        private List<Student> checklistupdate = new List<Student>();
        static Timer TTimer;

        public MainPage()
        {
            this.InitializeComponent();

/*            try { Form1Load(); }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                listOfStudents.Add(new Student { Name = "No Internet", PlayersCount = 0, MaxPlayers = 0 });
            }*/
            mylist.ItemsSource = listOfStudents;
            mylist.ItemClick += MylistItemClick;
            TTimer = new Timer(
    TickTimerAsync,
    null,
    50,
    50);


        }

        public async void TickTimerAsync(object state)
        {
            bool list_needs_updated = true;
            try
            {
                list_needs_updated = await CheckMgoValuesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            if (!list_needs_updated)
            {
                _ = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
() =>
{
    mylist.ItemsSource = null;
    mylist.Items.Clear();
    System.Diagnostics.Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
    try { System.Diagnostics.Debug.WriteLine("skiping this "); }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine(ex.Message);
        listOfStudents.Add(new Student { Name = "No Internet", PlayersCount = 0, MaxPlayers = 0 });
    }
    mylist.ItemsSource = listOfStudents;
});
            }
            Thread.Sleep(50);
        }

        public void StopTimer()
        {
            TTimer.Change(
    Timeout.Infinite,
    Timeout.Infinite);
        }

        private void ToggleVisibilityButton_Click(object sender, RoutedEventArgs e)
{
            var button = (Button)sender;
            var gridView = (GridView)button.FindName("gridPanel");

            if (gridView.Visibility == Visibility.Visible)
    {
        gridView.Visibility = Visibility.Collapsed;
    }
    else
    {
        gridView.Visibility = Visibility.Visible;
    }
}

        private void MylistItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = e.ClickedItem;
            if (clickedItem != null) { System.Diagnostics.Debug.WriteLine(clickedItem.ToString()); }
            mylist.ItemsSource = null;
            mylist.Items.Clear();
            
            mylist.ItemsSource = listOfStudents;
        }

        public async Task<bool> CheckMgoValuesAsync()
        {
            checklistupdate.Clear();
            listOfStudents.Clear();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetStringAsync("https://mgo2pc.com/api/v1/games?extra=true");
                    var root = JsonConvert.DeserializeObject<Root>(response);
                    foreach (var lobby in root.data.lobbies)
                    {
                        ObservableCollection<string> names = new ObservableCollection<string>();
                        names.Clear();
                        foreach (var player in lobby.players)
                        {
                            names.Add(player.name);
                        }
                        checklistupdate.Add(new Student { Name = lobby.name, PlayersCount = lobby.players.Count, MaxPlayers = lobby.maxPlayers, Locked = lobby.locked, PlayerNames = names, Visibility = Visibility.Collapsed });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                checklistupdate.Add(new Student { Name = "No Internet", PlayersCount = 0, MaxPlayers = 0 });
            }
            //Student last = listOfStudents.Last();
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            list1.Clear();
            list2.Clear();
            foreach (Student i in checklistupdate)
            {
                list1.Add(i.Name);
                list1.Add(i.PlayersCount.ToString());
            }
            foreach (Student i in listOfStudents)
            {
                list2.Add(i.Name);
                list2.Add(i.PlayersCount.ToString());
            }
            bool isEqual = list1.OrderBy(x => x).SequenceEqual(list2.OrderBy(x => x));
            System.Diagnostics.Debug.WriteLine(isEqual);
            if (isEqual)
            {
                return true;
            }
            listOfStudents = checklistupdate;
            return false;
        }
    }
}