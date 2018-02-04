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

        private bool _isSiteClearedToggeled;
        public bool IsSiteClearedToggeled
        {
            get { return _isSiteClearedToggeled; }
            set
            {
                _isSiteClearedToggeled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsSiteClearedToggeled"));
            }
        }

        private bool _isSpoilRemovedToggeled;
        public bool IsSpoilRemovedToggeled
        {
            get { return _isSpoilRemovedToggeled; }
            set
            {
                _isSiteClearedToggeled = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsSpoilRemovedToggeled"));
            }
        }

        public NewActivityViewModel()
        {         
            CompleteColor = Color.FromHex("#9F9F9F");
            TemporaryLabelColor = Color.FromHex("#9F9F9F");;
            AwaitinglabelColor = Color.FromHex("#9F9F9F");;
            BackfilledLabelColor = Color.FromHex("#9F9F9F");;
        }
    }
}
