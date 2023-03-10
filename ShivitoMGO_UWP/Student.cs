using DataModels;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;

namespace ShivitoMGO_UWP
{
    internal class Student
    {
        public string Name { get; set; }
        public int PlayersCount { get; set; }
        public int MaxPlayers { get; set; }
        public bool Locked { get; set; }
        public ObservableCollection<string> PlayerNames { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Visible;
    }
}