using System;
using System.ComponentModel;

namespace NWG.Model
{
   
        public class BaseViewModel : INotifyPropertyChanged

        {

            /// <summary>

            /// Occurs when [property changed].

            /// </summary>

            public event PropertyChangedEventHandler PropertyChanged;

            /// <summary>

            /// Raises the <see cref="E:PropertyChanged" /> event.

            /// </summary>

            /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>

            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChanged?.Invoke(this, e);
            }

        }
    }

