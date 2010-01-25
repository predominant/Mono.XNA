using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class MediaLibrary : IDisposable
    {
        private AlbumCollection albums;
        private ArtistCollection artists;
        private GenreCollection genres;
        private MediaSource mediaSource;
        private PictureCollection pictures;
        private PlaylistCollection playlists;
        private PictureAlbum rootPictureAlbum;
        private SongCollection songs;


        public MediaLibrary()
        {
        }

        public MediaLibrary(MediaSource mediaSource)
        {
            //this.songs = SongCollection.Empty;
            //this.artists = ArtistCollection.Empty;
            //this.albums = AlbumCollection.Empty;
            //this.playlists = PlaylistCollection.Empty;
            //this.genres = GenreCollection.Empty;
            //this.pictures = PictureCollection.Empty;
            //this.rootPictureAlbum = PictureAlbum.Empty;
            this.mediaSource = mediaSource;
        }

        public void Dispose()
        {
        }

        public AlbumCollection Albums
        {
            get
            {
                return mediaSource.GetAlbums();
            }
        }
        public ArtistCollection Artists
        {
            get
            {
                return mediaSource.GetArtists();
            }
        }

        public GenreCollection Genres
        {
            get
            {
                return mediaSource.GetGenres();
            }
        }

        public MediaSource MediaSource
        {
            get
            {
                return this.mediaSource;
            }
        }

        public PictureCollection Pictures
        {
            get
            {
                return mediaSource.GetPictures();
            }
        }

        public PlaylistCollection Playlists
        {
            get
            {
                return mediaSource.GetPlaylists();
            }
        }

        public PictureAlbum RootPictureAlbum
        {
            get
            {
                return mediaSource.GetRootPictureAlbum();
            }
        }

        public SongCollection Songs
        {
            get
            {
               return mediaSource.GetSongs();
            }
        }
    }
}
