using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PawPalsApp.Classes;
using System.Threading.Tasks;

namespace PawPalsApp.Data
{
    public class SQLiteDieta
    {
        SQLiteAsyncConnection db;

        public SQLiteDieta(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Dieta>().Wait();
        }
        public Task<int> SaveDietaAsync(Dieta dieta)
        {
            if (dieta.Id == 0)
            {
                return db.InsertAsync(dieta);
            }
            else
            {
                return db.UpdateAsync(dieta);
            }
        }
        public Task<List<Dieta>> GetDietaAsync()
        {
            return db.Table<Dieta>().ToListAsync();
        }
        public Task<List<Dieta>> GetDietaByMascotaAsync(string nombreMascota)
        {
            return
           db.Table<Dieta>().Where(p => p.IdMascota.Equals(nombreMascota)).ToListAsync();
        }
        public Task<int> DeleteDietaAsync(Dieta dieta)
        {
            return db.DeleteAsync(dieta);
        }
    }
}
