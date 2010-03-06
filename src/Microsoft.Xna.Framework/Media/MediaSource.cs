using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class MediaSource
    {
        private IMediaLibrary library;

        internal MediaSource(IMediaLibrary backend)
        {
            library = backend;
            library.mediasource = this;
        }

        public static IList<MediaSource> GetAvailableMediaSources()
        {
            return new MediaSource[]
            {
//#if WMP_MEDIALIBRARY_BACKEND
                new MediaSource( new WMPMediaLibrary()) 
//#endif
            };
        }


        public override string ToString()
        {
            return this.Name;
        }

        public MediaSourceType MediaSourceType
        {
            get
            {
                return library.mediaSourceType;
            }
        }

        public string Name
        {
            get
            {
                return library.Name;
            }
        }

        internal SongCollection GetSongs()
        {
            return library.GetSongs();
        }

        internal int getSong_PlayCount(object handle)
        {
            return library.getSong_PlayCount(handle);
        }

        internal bool getSong_IsProtected(object handle)
        {
            return library.getSong_IsProtected(handle);
        }

        internal AlbumCollection GetAlbums()
        {
            return library.GetAlbums();
        }

        internal PictureAlbum GetRootPictureAlbum()
        {
            return library.GetRootPictureAlbum();
        }

        internal ArtistCollection GetArtists()
        {
            return library.GetArtists();
        }

        internal GenreCollection GetGenres()
        {
            return library.GetGenres();
        }

        internal PictureCollection GetPictures()
        {
            return library.GetPictures();
        }

        internal PlaylistCollection GetPlaylists()
        {
            return library.GetPlaylists();
        }

        internal void Mediaqueue_Play_Song(object handle)
        {
            library.Mediaqueue_Play_Song(handle);
        }

        internal bool Album_IsEqual(object first, object second, ref bool equal)
        {
            return library.Album_IsEqual(first, second, ref equal);
        }
    }
}
