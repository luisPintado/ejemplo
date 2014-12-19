using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MUSIC.DAL
{
    public class Song
    {

        public static List<ENTITIES.Song> GetAll() 
        {
            List<ENTITIES.Song> lSongs = null;
            try
            {

                using (IDataReader sqrSource = DAL.Core.GetConnection.ExecuteReader("spTblSongsGetAllComplete"))
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
                                IdAlbum = sqrSource.GetInt32(4)                             
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

        //public static List<ENTITIES.Song> GetAllComplete()
        //{
        //    List<ENTITIES.Song> lnewResult = new List<ENTITIES.Song>();
        //    lnewResult.Add(new ENTITIES.Song() { 
        //            Autor = "Luis Pintado", 
        //            Duration = "12:12", 
        //            IdSong = 1, 
        //            Source = "SHALLALA",
        //            Album = new ENTITIES.Album(){
        //                 IdAlbum= 1,
        //                 Name= "EN Tus pies",
        //                  Year = 1999,
        //                 Genre = new ENTITIES.GenreMusic()
        //                 {
        //                      Description="Metal",
        //                      Id=1
        //                 }
        //            }
        //    });
        //    lnewResult.Add(new ENTITIES.Song()
        //    {
        //        Autor = "Maria Chona",
        //        Duration = "13:11",
        //        IdSong = 2,
        //        Source = "CREDD",
        //        Album = new ENTITIES.Album()
        //        {
        //            IdAlbum = 2,
        //            Name = "Con todo",
        //            Year = 2000,
        //            Genre = new ENTITIES.GenreMusic()
        //            {
        //                Description = "Salsa",
        //                Id = 2
        //            }
        //        }
        //    });
        //    lnewResult.Add(new ENTITIES.Song()
        //    {
        //        Autor = "Jaguares",
        //        Duration = "13:23",
        //        IdSong = 3,
        //        Source = "CART",
        //        Album = new ENTITIES.Album()
        //        {
        //            IdAlbum = 3,
        //            Name = "Chica",
        //            Year = 1999,
        //            Genre = new ENTITIES.GenreMusic()
        //            {
        //                Description = "Salsa",
        //                Id = 2
        //            }
        //        }
        //    });


        //    return lnewResult;
        //}

        public static List<ENTITIES.Song> GetAllComplete()
        {
            List<ENTITIES.Song> lSongs = null;
            try
            {

                using (IDataReader sqrSource = DAL.Core.GetConnection.ExecuteReader("spTblSongsGetAllComplete"))
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
