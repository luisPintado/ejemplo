using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MUSIC.SERVICES
{

    public class SongService : ISongService
    {
    
        public List<ENTITIES.Song> GetSong()
        {
            return DAL.Song.GetAll();
        }

        public List<ENTITIES.Album> GetAlbum()
        {
            return DAL.Album.GetAll();
        }

        public List<ENTITIES.ListSong> GetLists()
        {
            return DAL.ListSong.GetAll();
        }

        public List<ENTITIES.Song> GetCompleteSongs()
        {
            return DAL.Song.GetAllComplete();
        }


        public ENTITIES.PlayList AddPlayList(ENTITIES.PlayList oPlayList)
        {
            return DAL.PlayList.Add(oPlayList);
        }

        public ENTITIES.ListSong AddList(ENTITIES.ListSong oList)
        {
            return DAL.ListSong.Add(oList);
        }

        public List<ENTITIES.Song> GetSongsByList(ENTITIES.ListSong oListSong)
        {
            return DAL.ListSong.GetAll(oListSong);
        }
    }
}