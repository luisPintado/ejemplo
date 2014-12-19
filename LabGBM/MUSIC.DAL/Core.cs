using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MUSIC.DAL
{
    public class Core
    {

        private static DatabaseProviderFactory Factory = null;
        private static Database NameDB = null;
        public static string NameStringBD;
        private static DbConnection _dbConnection = null;

        public static Database GetConnection
        {
            get
            {
                if (NameDB == null)
                {
                    Factory = new DatabaseProviderFactory();
                    NameDB = Factory.CreateDefault();
                    _dbConnection = NameDB.CreateConnection();
                }
                return NameDB;
            }
        }


        public static DbConnection GetDbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = NameDB.CreateConnection();
                }
                return _dbConnection;
            }
        }

        public static Database GetConnectionByName
        {
            get
            {
                if (NameDB == null)
                {
                    Factory = new DatabaseProviderFactory();
                    NameDB = Factory.Create(NameStringBD);
                }
                return NameDB;
            }
        }


        public static void ChangeConnection()
        {
            if (NameDB != null)
            {
                NameDB.CreateConnection().Close();
                NameDB = null;
            }
            GetConnectionByName.CreateConnection();
        }
    }

}
