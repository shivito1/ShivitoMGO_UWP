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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShivitoMGO_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Student> listOfStudents = new List<Student>();
        private List<Student> checklistupdate= new List<Student>();
        static Timer TTimer;
        public MainPage()
        {
            this.InitializeComponent();



            /*            listOfStudents.Add(new Student { Name = "John", Age = 20 });
                        listOfStudents.Add(new Student { Name = "Bob", Age = 21 });
                        listOfStudents.Add(new Student { Name = "Steve", Age = 19 });
                        listOfStudents.Add(new Student { Name = "Marko", Age = 18 });
                        listOfStudents.Add(new Student { Name = "Igor", Age = 20 });
                        listOfStudents.Add(new Student { Name = "Ivan", Age = 20 });
                        listOfStudents.Add(new Student { Name = "Nina", Age = 21 });
                        listOfStudents.Add(new Student { Name = "Paul", Age = 20 });
                        listOfStudents.Add(new Student { Name = "Ana", Age = 23 });
                        listOfStudents.Add(new Student { Name = "Ivana", Age = 20 });*/
            Form1_Load();
            mylist.ItemsSource = listOfStudents;
            mylist.ItemClick += Mylist_ItemClick;
            TTimer = new Timer(
                new TimerCallback(TickTimer),
                null,
                5000,
                5000);


        }

        public void TickTimer(object state)
        {
            bool list_needs_updated = Check_mgo_values();
            if (!list_needs_updated) {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
() =>
{
    mylist.ItemsSource = null;
    mylist.Items.Clear();
    System.Diagnostics.Debug.WriteLine("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
    Form1_Load();
    mylist.ItemsSource = listOfStudents;
});
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            Thread.Sleep(10000);
        }

        public void StopTimer()
        {
            TTimer.Change(
    Timeout.Infinite,
    Timeout.Infinite);
        }

        private void Mylist_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            var clickedItem = e.ClickedItem;
            if (clickedItem != null) { System.Diagnostics.Debug.WriteLine(clickedItem.ToString()); }
            mylist.ItemsSource = null;
            mylist.Items.Clear();
            Form1_Load();
            mylist.ItemsSource = listOfStudents;
        }

        public Boolean Check_mgo_values()
        {
            checklistupdate.Clear();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync("https://mgo2pc.com/api/v1/games").Result;
                var root = JsonConvert.DeserializeObject<Root>(response);
                foreach (var lobby in root.data.lobbies)
                {
                    checklistupdate.Add(new Student { Name = lobby.name, Num_Of_Players = lobby.players.Count, Max_Players = lobby.maxPlayers });
                    foreach (var player in lobby.players)
                    {
                        // players info


                    }
                }
            }
            //Student last = listOfStudents.Last();
            List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            list1.Clear();
            list2.Clear();
            foreach (Student i in checklistupdate)
            {                
                list1.Add(i.Name);
            }
            foreach (Student i in listOfStudents)
            {
                list2.Add(i.Name);
            }
            bool isEqual = list1.OrderBy(x => x).SequenceEqual(list2.OrderBy(x => x));
            System.Diagnostics.Debug.WriteLine(isEqual);
            if(isEqual)
            {
                return true;
            }

            return false;
        }

        public class Student
        {
            public string Name { get; set; }
            public int Num_Of_Players { get; set; }
            public int Max_Players { get; set; }
        }

        private void Form1_Load()
        {
            listOfStudents.Clear();
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync("https://mgo2pc.com/api/v1/games").Result;
                var root = JsonConvert.DeserializeObject<Root>(response);
                foreach (var lobby in root.data.lobbies)
                {
                    System.Diagnostics.Debug.WriteLine(lobby.name);
                    listOfStudents.Add(new Student { Name = lobby.name, Num_Of_Players = lobby.players.Count, Max_Players = lobby.maxPlayers});
                    foreach (var player in lobby.players)
                    {
                        System.Diagnostics.Debug.WriteLine(player.name);
                        

                    }
                }
            }
        }
    }
}
