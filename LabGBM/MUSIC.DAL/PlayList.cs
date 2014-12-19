using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MUSIC.DAL
{
    public class PlayList
    {
        public static ENTITIES.PlayList Add(ENTITIES.PlayList oPlayList)
        {
            object oResult = null;
            try
            {
                oResult = DAL.Core.GetConnection.ExecuteScalar("spTblPlayListAdd", oPlayList.Song.IdSong, oPlayList.List.Id, oPlayList.DateCreation);
                if (oResult != null)
                    oPlayList.Id = int.Parse(oResult.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw (sqlEx);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oPlayList;
        }

    }
}
