using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Preparation.Models
{
    public class ConnectionFactory : IDisposable
    {

        #region IDisposable Support  
        private bool disposedValue = false; // To detect redundant calls  

        public Context ForInMemory()
        {
            var option = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName: "PreparationTest").Options;

            var context = new Context(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        public Context ForSQLServer()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<Context>().UseSqlite(connection).Options;

            var context = new Context(option);

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
