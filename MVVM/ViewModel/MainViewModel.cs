using ChatApplication.Core;
using ChatApplication.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        // Commands
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set {
                _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new();
            Contacts = new();

            SendCommand = new RelayCommand(o => {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";

            });

            GenerateMockData();
        }

        private void GenerateMockData()
        {
            Messages.Add(new MessageModel
            {
                Username = "Yulia",
                UsernameColor = "#409aff",
                ImageSource = "/ChatApplication/Images/download.jpg",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for(int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Yulia",
                    UsernameColor = "#409aff",
                    ImageSource = "/ChatApplication/Images/download.jpg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for(int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Omri",
                    UsernameColor = "#409aff",
                    ImageSource = "/ChatApplication/Images/download1.jpg",
                    Time = DateTime.Now,
                    IsNativeOrigin = true
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "NewUser",
                UsernameColor = "#409aff",
                ImageSource = "",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true
            });

            int j = 1;
            Contacts.Add(new ContactModel
            {
                Username = $"Yulia {j}",
                ImageSource = "/ChatApplication/Images/download.jpg",
                Messages = Messages
            });
            j++;
            Contacts.Add(new ContactModel
            {
                Username = $"Omri {j}",
                ImageSource = "/ChatApplication/Images/download1.jpg",
                Messages = Messages
            });
            j++;
            Contacts.Add(new ContactModel
            {
                Username = $"NewUser {j}",
                ImageSource = "",
                Messages = Messages
            });
        }
    }
}
