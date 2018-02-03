using System;
using System.ComponentModel;
using NWG.Model;
using Xamarin.Forms;

namespace NWG.ViewModel
{
    public class NewActivityViewModel : BaseViewModel
    {
        private Color _completeColor;
        public Color CompleteColor
        {
            get { return _completeColor; }
            set
            {
                _completeColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CompleteColor"));
            }
        }

        private Color _temporaryLabelColor;
        public Color TemporaryLabelColor
        {
            get { return _temporaryLabelColor; }
            set
            {
                _temporaryLabelColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TemporaryLabelColor"));
            }
        }

        private Color _awaitinglabelColor;
        public Color AwaitinglabelColor
        {
            get { return _awaitinglabelColor; }
            set
            {
                _awaitinglabelColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AwaitinglabelColor"));
            }
        }

        private Color _backfilledLabelColor;
        public Color BackfilledLabelColor
        {
            get { return _backfilledLabelColor; }
            set
            {
                _backfilledLabelColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BackfilledLabelColor"));
            }
        }
               

        public NewActivityViewModel()
        {         
            CompleteColor = Color.Blue;
            TemporaryLabelColor = Color.Blue;
            AwaitinglabelColor = Color.Blue;
            BackfilledLabelColor = Color.Blue;
        }
    }
}
