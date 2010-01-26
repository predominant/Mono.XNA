using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    internal class WMPMediaLibrary : IMediaLibrary
    {

        MediaSource Mediasource;

        public MediaSource mediasource
        {
            get
            {
                return Mediasource;
            }
            set
            {
                Mediasource = value;
            }
        }

        public string Name
        {
            get
            {
                return "Local Windows Media Player library";
            }
        }

        public MediaSourceType mediaSourceType
        {
            get
            {
                return MediaSourceType.LocalDevice;
            }
        }

        public SongCollection GetSongs()
        {
            throw new NotImplementedException();
        }

        public int getSong_PlayCount(object handle)
        {
            throw new NotImplementedException();
        }

        public bool getSong_IsProtected(object handle)
        {
            throw new NotImplementedException();
        }

        public AlbumCollection GetAlbums()
        {
            throw new NotImplementedException();
        }

        public PictureAlbum GetRootPictureAlbum()
        {
            throw new NotImplementedException();
        }

        public ArtistCollection GetArtists()
        {
            throw new NotImplementedException();
        }

        public GenreCollection GetGenres()
        {
            throw new NotImplementedException();
        }

        public PictureCollection GetPictures()
        {
            throw new NotImplementedException();
        }

        public PlaylistCollection GetPlaylists()
        {
            throw new NotImplementedException();
        }

        public bool Album_IsEqual(object first, object second, ref bool equal)
        {
            throw new NotImplementedException();
        }
    }
}
