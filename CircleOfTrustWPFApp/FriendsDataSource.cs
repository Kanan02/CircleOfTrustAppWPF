using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace CircleOfTrustWPFApp
{
    class FriendsDataSource:INotifyPropertyChanged
    {
        public ICollection<Friend> friends = new ObservableCollection<Friend>();
        public IEnumerable<Friend> Friends
        {
            get => friends;
            set
            {
                if (!friends.Equals(value))
                {
                    friends = value as ObservableCollection<Friend>;
                    OnChanged(new PropertyChangedEventArgs(nameof(Friends)));
                }
            }

        }
        JsonFileService fileService=new JsonFileService();

        public event PropertyChangedEventHandler PropertyChanged;

        DelegateCommand addCommand;
        public DelegateCommand AddCommand { get => addCommand; set => addCommand = value; }

        DelegateCommand deleteCommand;
        public DelegateCommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }

        DelegateCommand saveCommand;
        public DelegateCommand SaveCommand { get => saveCommand; set => saveCommand = value; }

        DelegateCommand loadCommand;
        public DelegateCommand LoadCommand { get => loadCommand; set => loadCommand = value; }
        public FriendsDataSource()
        {
            addCommand = new DelegateCommand(obj => {
                Friend friend = new Friend();
                friend.Name = Friend.Name;
                friends.Add(friend);
                
                });
            deleteCommand = new DelegateCommand(obj => {
                Friend fr = obj as Friend;
                friends.Remove(selectedFriend);
                selectedFriend = new Friend();
               
            });
            saveCommand = new DelegateCommand(obj =>
              {
                  fileService.Save("friends.json", friends as ObservableCollection<Friend>);
                  MessageBox.Show("Your friendList now saved in friends.json file!","Saved!",MessageBoxButton.OK,MessageBoxImage.Information);
              });
            loadCommand = new DelegateCommand(obj =>
            {
                Friends = fileService.Open("friends.json");

            });
        }
        private Friend friend=new Friend();
        public Friend Friend { get=>friend;
            set
            {
                if (!friend.Equals(value))
                {
                    friend = value;
                    OnChanged(new PropertyChangedEventArgs(nameof(Friend)));
                }
            }

        }
        private Friend selectedFriend = new Friend();
        public Friend SelectedFriend
        {
            get => selectedFriend;
            set
            {
                if (!selectedFriend.Equals(value))
                {
                    selectedFriend = value;
                    OnChanged(new PropertyChangedEventArgs(nameof(SelectedFriend)));
                }
            }

        }


        public void OnChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
