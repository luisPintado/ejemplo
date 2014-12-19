using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MUSIC.DAL
{
    public class ListSong
    {

        //public static List<ENTITIES.ListSong> GetAll()
        //{
        //    List<ENTITIES.ListSong> lList = new List<ENTITIES.ListSong>();
        //    lList.Add(new ENTITIES.ListSong() {  Id = 1, Name="Romantico", Create = DateTime.Now });
        //    lList.Add(new ENTITIES.ListSong() { Id = 2, Name = "Metal", Create = DateTime.Now });
        //    lList.Add(new ENTITIES.ListSong() { Id = 3, Name = "Regueton", Create = DateTime.Now });
        //    return lList;
        //}

        public static List<ENTITIES.ListSong> GetAll()
        {
            List<ENTITIES.ListSong> lListSongs = null;
            try
            {
                using (IDataReader sqrSource = DAL.Core.GetConnection.ExecuteReader("spTblListGetAll"))
                {
                    lListSongs = new List<ENTITIES.ListSong>();
                    while (sqrSource.Read())
                    {
                        lListSongs.Add(new ENTITIES.ListSong()
                        {
                            Id = sqrSource.GetInt32(0),
                            Name = sqrSource.GetString(1),
                            Create = sqrSource.GetDateTime(2)
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
            return lListSongs;
        }

        public static ENTITIES.ListSong Add(ENTITIES.ListSong oList)
        {
            object oResult = null;
            try
            {
                oResult = DAL.Core.GetConnection.ExecuteScalar("spTblListAdd", oList.Name, DateTime.Now);
               if (oResult != null)
                   oList.Id = int.Parse(oResult.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw (sqlEx);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oList;
        }

        public static List<ENTITIES.Song> GetAll(ENTITIES.ListSong oListSong)
        {
            List<ENTITIES.Song> lSongs = null;
            try
            {
                using (IDataReader sqrSource = DAL.Core.GetConnection.ExecuteReader("spTblSongsGetByIdList",oListSong.Id))
                {
                    lSongs = new List<ENTITIES.Song>();
                    while (sqrSource.Read())
                    {
                        lSongs.Add(new ENTITIES.Song()
                        {
                            IdSong = sqrSource.GetInt32(0),
                            Source = sqrSource.GetString(1),
                            Duration = sqrSource.GetString(2),
                            Autor = sqrSource.GetString(3),
                            Album = new ENTITIES.Album()
                            {
                                IdAlbum = sqrSource.GetInt32(4),
                                Name = sqrSource.GetString(5),
                                Year = sqrSource.GetInt32(6),
                                Genre = new ENTITIES.GenreMusic()
                                {
                                    Id = sqrSource.GetInt32(7),
                                    Description = sqrSource.GetString(8)
                                }
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
            return lSongs;
        }
    }
}
