using System;
using System.ComponentModel;
using SQLite;
using SQLite.Net.Attributes;

namespace NWG.Model
{

    [Table("NewActivity")]
    public class NewActivityModel : INotifyPropertyChanged
     {
        public string Name { get; set; }

        private int _id = 1;       
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _groupId;
        public String GroupId
        {
            get
            {
                return _groupId;
            }
            set
            {
                this._groupId = value;
                OnPropertyChanged(nameof(GroupId));
            }
        }

        private string _location;
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                this._location = value;
                OnPropertyChanged(nameof(_location));
            }
        }

        private string _colour;
        [MaxLength(50)]
        public string Colour
        {
            get
            {
                return _colour;
            }
            set
            {
                this._colour = value;
                OnPropertyChanged(nameof(_colour));
            }
        }
        private string _length;
        public string Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
                OnPropertyChanged(nameof(Length));
            }
        }

        private string _width;
        public string Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Length));
            }
        }

        private string _depth;
        public string Depth
        {
            get
            {
                return _depth;
            }
            set
            {
                _depth = value;
                OnPropertyChanged(nameof(Depth));
            }
        }

        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private string _surface;
        public string Surface
        {
            get
            {
                return _surface;
            }
            set
            {
                _surface = value;
                OnPropertyChanged(nameof(Surface));
            }
        }

        private string _publicOrPrivate;
        public string PublicOrPrivate
        {
            get
            {
                return _publicOrPrivate;
            }
            set
            {
                _publicOrPrivate = value;
                OnPropertyChanged(nameof(PublicOrPrivate));
            }
        }

        private bool _isSiteCleared;
        public bool IsSiteCleared
        {
            get
            {
                return _isSiteCleared;
            }
            set
            {
                _isSiteCleared = value;
                OnPropertyChanged(nameof(IsSiteCleared));
            }
        }

        private bool _isSpoilRemoved;
        public bool IsSpoilRemoved
        {
            get
            {
                return _isSpoilRemoved;
            }
            set
            {
                _isSpoilRemoved = value;
                OnPropertyChanged(nameof(IsSpoilRemoved));
            }
        }

        private string _comments;
        public string Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                OnPropertyChanged(nameof(Comments));
            }
        }

        private string _materialDescription;
        public string MaterialDescription
        {
            get
            {
                return _materialDescription;
            }
            set
            {
                _materialDescription = value;
                OnPropertyChanged(nameof(MaterialDescription));
            }
        }

        private string _captureImage;
        public string CaptureImage
        {
            get
            {
                return _captureImage;
            }
            set
            {
                _captureImage = value;
                OnPropertyChanged(nameof(CaptureImage));
            }
        }

        private string _geoLocation;
        public string GeoLocation
        {
            get
            {
                return _geoLocation;
            }
            set
            {
                _geoLocation = value;
                OnPropertyChanged(nameof(GeoLocation));
            }
        }

        public bool IsNotEmptyRow { get; set; } = true;

        public bool IsReviewed { get; set; } = false;

        public string StatusIcon
        {
            get { return IsReviewed ? "Green.png" : "Red.png"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
