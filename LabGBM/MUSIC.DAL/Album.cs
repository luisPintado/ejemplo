using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MUSIC.DAL
{
    public class Album
    {
        public static List<ENTITIES.Album> GetAll()
        {
            List<ENTITIES.Album> lAlbums = null;
            try
            {

                using (IDataReader sqrSource = DAL.Core.GetConnection.ExecuteReader("spTblAlbumGetAll"))
                {
                    lAlbums = new List<ENTITIES.Album>();
                    while (sqrSource.Read())
                    {
                        lAlbums.Add(new ENTITIES.Album()
                        {
                            IdAlbum = sqrSource.GetInt32(0),
                            Name = sqrSource.GetString(1),
                            Year = sqrSource.GetInt32(2),                            
                            Genre = new ENTITIES.GenreMusic()
                            {
                                Id = sqrSource.GetInt32(3)
                            }
                        });
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw (sqlEx);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return lAlbums;
        }
    }
}
