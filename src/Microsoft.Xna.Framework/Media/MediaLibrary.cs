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
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
        public AlbumCollection Albums
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public ArtistCollection Artists
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public GenreCollection Genres
        {
            get
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        public PlaylistCollection Playlists
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PictureAlbum RootPictureAlbum
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SongCollection Songs
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
