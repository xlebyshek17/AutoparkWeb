using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoparkWeb.Models.Entity;

namespace AutoparkWeb.Models.Repositories
{
    public class SparePartsRepository : DbConnection, IRepository<SpareParts>
    {
        public SparePartsRepository(string connection) : base(connection)
        {
            
        }

        public void Create(SpareParts detail)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Insert into SpareParts(Name) values(@Name)";

                db.Execute(sqlQuery, detail);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Delete from SpareParts where Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public SpareParts Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<SpareParts>($"Select * from SpareParts where Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<SpareParts> GetList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<SpareParts>($"Select * from SpareParts").ToList();
            }
        }

        public void Update(SpareParts detail)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $"Update SpareParts set Name = @Name where Id = @Id";
                db.Execute(sqlQuery, detail);
            }
        }
    }
}
