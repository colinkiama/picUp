using picUp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace picUp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SwipePage : Page
   {
        // Global translation transform used for changing the position of 
        // the Rectangle based on input data from the touch contact.
        private TranslateTransform dragTranslation;

        private int myVar;

        public ObservableCollection<photo> photos = photo.photos;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public SwipePage()
        {
            this.InitializeComponent();
            DoThis();
            shownPic.ManipulationDelta += ShownPic_ManipulationDelta;
            dragTranslation = new TranslateTransform();
            shownPic.RenderTransform = this.dragTranslation;

        }

        private void ShownPic_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            dragTranslation.X += e.Delta.Translation.X;
            dragTranslation.Y = e.Delta.Translation.Y;
        }

        private async void DoThis()
        {
            await photo.GetPhotosFromCameraRoll();
            updatePhotoToDisplay();
        }

        private void updatePhotoToDisplay()
        {
            SwipePhoto.Source = photos.First().ImageSource;
        }
    }
}
