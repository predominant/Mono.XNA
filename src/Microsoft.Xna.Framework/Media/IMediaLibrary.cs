using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    interface IMediaLibrary
    {
        string Name
        {
            get;
        }

        MediaSourceType mediaSourceType
        {
            get;
        }

        MediaSource mediasource
        {
            get;
            set;
        }

        SongCollection GetSongs();
        AlbumCollection GetAlbums();
        PictureAlbum GetRootPictureAlbum();
        GenreCollection GetGenres();
        ArtistCollection GetArtists();
        PictureCollection GetPictures();
        PlaylistCollection GetPlaylists();

        int getSong_PlayCount(object handle);
        bool getSong_IsProtected(object handle);

        void Mediaqueue_Play_Song(object handle);

        bool Album_IsEqual(object first, object second, ref bool equal);
    }
}
