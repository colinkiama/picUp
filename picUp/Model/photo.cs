using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;
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

        public static async Task<bool> GetPhotosFromCameraRoll()
        {
            bool gotPhotos = false;

            QueryOptions queryOption = new QueryOptions
               (CommonFileQuery.OrderByDate, new string[] { ".png", ".jpg", ".jpeg", ".svg" });

            queryOption.FolderDepth = FolderDepth.Deep;


            var files = await KnownFolders.CameraRoll.CreateFileQueryWithOptions(queryOption).GetFilesAsync(0, 10);


            foreach (var file in files)
            {
                var photoToAdd = new photo();
                photoToAdd.FileName = file.DisplayName;
                photoToAdd.FileReference = file;
                BitmapImage photoSource = new BitmapImage();

                var streamToSetAs = await file.OpenAsync(FileAccessMode.ReadWrite);
                await photoSource.SetSourceAsync(streamToSetAs);

                photoToAdd.ImageSource = photoSource;
                photos.Add(photoToAdd);
            }


            return gotPhotos;
        }

        #endregion

    }
}
