using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TickCode.ORM
{
    public class DapperWrapper
    {
        private readonly static string connectionStr = "server= 47.98.106.199;User ID=sa;Password=Maxwell110;Database=TicketCodeTestDB;MultipleActiveResultSets=true;";

        public static List<T> GetAll<T>(string sql)
        {
            using (IDbConnection db = new SqlConnection(connectionStr))
            {
                return db.Query<T>(sql).ToList();
            }
        }

        public static void Insert(string sql)
        {
            using (IDbConnection db = new SqlConnection(connectionStr))
            {
                db.Execute(sql);
            }
        }

        public static void Update(string sql)
        {
            using (IDbConnection db = new SqlConnection(connectionStr))
            {
                db.Execute(sql);
            }
        }

        public static T GetSingle<T>(string sql)
        {
            using (IDbConnection db = new SqlConnection(connectionStr))
            {
                return db.QueryFirst<T>(sql);
            }
        }

        public static void Delete(string sql)
        {
            using (IDbConnection db = new SqlConnection(connectionStr))
            {
                db.Execute(sql);
            }
        }

    }
}
