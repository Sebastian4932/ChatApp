using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static ChatApp.src.ChatMessageModel;

namespace ChatApp.src
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Message> Messages => ChatService.Instance.Messages;
        List<User> users { get; } = new List<User>()
        {
                new User(){Name="A", Id=1},
                new User(){Name="B", Id=2},
                new User(){Name="C", Id=3},

        };
        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(); }
        }
        private User _userA;
        public User UserA
        {
            get => _userA;
            set { _userA = value; }
        }
        private User _userB;
        public User UserB
        {
            get => _userB;
            set { _userB = value; }
        }
        private User _userC;
        public User UserC
        {
            get => _userC;
            set { _userC = value; }
        }


        public ViewModel()
        {           
            SelectedUser = users[0];                                 
            UserA = users[0]; 
            UserB = users[1];
            UserC = users[2];
            
                       
        }


        public async Task SendMessageAsync(string content)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                await ChatService.Instance.SendMessageAsync(SelectedUser.Name, content);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    }
