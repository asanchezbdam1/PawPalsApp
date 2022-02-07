using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PawPalsApp.Classes;
using System.Threading.Tasks;

namespace PawPalsApp.Data
{
    public class SQLiteMascota
    {
        SQLiteAsyncConnection db;

        public SQLiteMascota(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Mascotas>().Wait();
        }
        public Task<int> SaveMascotaAsync(Mascotas mascota)
        {
            if (mascota.Id == 0)
            {
                return db.InsertAsync(mascota);
            }
            else
            {
                return db.UpdateAsync(mascota);
            }
        }
        public Task<List<Mascotas>> GetMascotasAsync()
        {
            return db.Table<Mascotas>().ToListAsync();
        }
        public Task<Mascotas> GetMascotasByIdAsync(int idMascota)
        {
            return
           db.Table<Mascotas>().Where(p => p.Id == idMascota).FirstOrDefaultAsync();
        }
        public Task<int> DeleteExperienciaAsync(Mascotas mascota)
        {
            return db.DeleteAsync(mascota);
        }
    }
}
