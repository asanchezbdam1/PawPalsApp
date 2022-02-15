using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PawPalsApp.Classes;
using System.Threading.Tasks;

namespace PawPalsApp.Data
{
    public class SQLiteHigiene
    {
        SQLiteAsyncConnection db;

        public SQLiteHigiene(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Higiene>().Wait();
        }
        public Task<int> SaveHigieneAsync(Higiene higiene)
        {
            if (higiene.Id == 0)
            {
                return db.InsertAsync(higiene);
            }
            else
            {
                return db.UpdateAsync(higiene);
            }
        }
        public Task<List<Higiene>> GetHigieneAsync()
        {
            return db.Table<Higiene>().ToListAsync();
        }
        public Task<List<Higiene>> GetHigieneByMascotaAsync(string nombreMascota)
        {
            return
           db.Table<Higiene>().Where(p => p.IdMascota.Equals(nombreMascota)).ToListAsync();
        }
        public Task<int> DeleteHigieneAsync(Higiene higiene)
        {
            return db.DeleteAsync(higiene);
        }
    }
}
