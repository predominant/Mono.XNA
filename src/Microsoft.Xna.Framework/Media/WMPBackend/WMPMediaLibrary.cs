using System;
using System.Collections.Generic;
using System.Text;
using Interop.WMPLib;

namespace Microsoft.Xna.Framework.Media
{
    internal class WMPMediaLibrary : IMediaLibrary
    {
        IWMPCore wmp = (IWMPCore)(new WindowsMediaPlayerClass());

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
            IWMPMediaCollection media = wmp.mediaCollection;
            IWMPPlaylist playlist = media.getAll();
            List<Song> songlist = new List<Song>();

            for (int i = 0; i < playlist.count; i++)
            {
                IWMPMedia temp = playlist[i];
                if (temp.getItemInfo("MediaType") == "audio")
                {
                    int wmprating;
                    int rating;
                    int tracknumber;
                    int playcount;
                    bool IsProtected;
                    if (!int.TryParse(temp.getItemInfo("UserRating"), out wmprating))
                    {
                        throw new Exception();
                    }
                    if (wmprating >= 87) rating = 10;
                    else if (wmprating >= 63) rating = 8;
                    else if (wmprating >= 38) rating = 6;
                    else if (wmprating >= 13) rating = 4;
                    else if (wmprating >= 1) rating = 2;
                    else rating = 0;
                    if (!int.TryParse(temp.getItemInfo("WM/TrackNumber"), out tracknumber))
                    {
                        tracknumber = 0;
                    }
                    if (!int.TryParse(temp.getItemInfo("PlayCount"), out playcount))
                    {
                        throw new Exception();
                    }
                    if (!bool.TryParse(temp.getItemInfo("Is_Protected"), out IsProtected))
                    {
                        throw new Exception();
                    }
                    TimeSpan duration = new TimeSpan(0, 0, 0, 0, (int)(temp.duration * 1000.0));
                    songlist.Add(new Song(temp.name, duration, rating, tracknumber, temp, mediasource));
                }
            }
            SongCollection songs = new SongCollection(songlist);
            return songs;
        }

        public int getSong_PlayCount(object handle)
        {
            int playcount;
            if (!int.TryParse(((IWMPMedia)(handle)).getItemInfo("PlayCount"), out playcount))
            {
                throw new Exception();
            }
            return playcount;
        }

        public bool getSong_IsProtected(object handle)
        {
            bool IsProtected;
            if (!bool.TryParse(((IWMPMedia)(handle)).getItemInfo("Is_Protected"), out IsProtected))
            {
                throw new Exception();
            }
            return IsProtected;
        }

        public AlbumCollection GetAlbums()
        {
            throw new NotImplementedException();
            IWMPMediaCollection media = wmp.mediaCollection;
            IWMPPlaylist playlist = media.getAll();
            List<Album> albumlist = new List<Album>();

            for (int i = 0; i < playlist.count; i++)
            {
                IWMPMedia temp = playlist[i];
                if (temp.getItemInfo("MediaType") == "audio")
                {
                    string albumname = temp.getItemInfo("Album");
                }
            }
            AlbumCollection albums = new AlbumCollection(albumlist);
            return albums;
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

        public void Mediaqueue_Play_Song(object handle)
        {
            throw new NotImplementedException();
        }

        public bool Album_IsEqual(object first, object second, ref bool equal)
        {
            throw new NotImplementedException();
        }
    }
}
