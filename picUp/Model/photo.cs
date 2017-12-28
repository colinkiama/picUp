using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace picUp.Model
{
    public class photo
    {
        #region Fields

        public static ObservableCollection<photo> photos = new ObservableCollection<photo>();

        #endregion

        #region Properties

        public BitmapImage ImageSource { get; set; }
        public StorageFile FileReference { get; set; }
        public string FileName { get; set; }

        #endregion

        #region Constructors

        public photo()
        {

        }

        public photo(string fileName, BitmapImage imageSource, StorageFile fileReference)
        {
            FileName = fileName;
            ImageSource = imageSource;
            FileReference = FileReference;
        }

        #endregion

        #region Methods

       

        #endregion

    }
}
