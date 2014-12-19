using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace MUSIC.SERVICES
{
    [ServiceContract]
    public interface ISongService
    {
        [OperationContract]
        List<ENTITIES.Song> GetSong();

        [OperationContract]
        List<ENTITIES.Album> GetAlbum();

        [OperationContract]
        List<ENTITIES.ListSong> GetLists();

        [OperationContract]
        List<ENTITIES.Song> GetCompleteSongs();

        [OperationContract]
        ENTITIES.PlayList AddPlayList(ENTITIES.PlayList oPlayList);

        [OperationContract]
        ENTITIES.ListSong AddList(ENTITIES.ListSong oList);

        [OperationContract]
        List<ENTITIES.Song> GetSongsByList(ENTITIES.ListSong oListSong);


    }
}
