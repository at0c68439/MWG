using System;
namespace NWG.Helpers
{
    public class PickerActionEventArgs : EventArgs

    {
        public string pickerValue { get; set; }

        public PickerActionEventArgs(string pickervalue)

        {
            this.pickerValue = pickervalue;
        }

    }
}
