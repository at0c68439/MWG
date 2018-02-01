using System;
using Xamarin.Forms.Platform.iOS; using Xamarin.Forms; using System.ComponentModel;
using NWG.iOS.CustomRenderer;
using NWG;

[assembly: ExportRenderer(typeof(MyEntry), typeof(BorderLessEntryRenderer))]
namespace NWG.iOS.CustomRenderer
{
    public class BorderLessEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)         {             base.OnElementPropertyChanged(sender, e);              Control.Layer.BorderWidth = 0;              Control.BorderStyle = UIKit.UITextBorderStyle.None;         }
    }
}
