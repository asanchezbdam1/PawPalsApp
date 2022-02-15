using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PawPalsApp.Classes;
using System.Threading.Tasks;

namespace PawPalsApp.Data
{
    public class SQLiteEjercicio
    {
        SQLiteAsyncConnection db;

        public SQLiteEjercicio(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Ejercicios>().Wait();
        }
        public Task<int> SaveEjercicioAsync(Ejercicios ejercicio)
        {
            if (ejercicio.Id == 0)
            {
                return db.InsertAsync(ejercicio);
            }
            else
            {
                return db.UpdateAsync(ejercicio);
            }
        }
        public Task<List<Ejercicios>> GetEjercicioAsync()
        {
            return db.Table<Ejercicios>().ToListAsync();
        }
        public Task<List<Ejercicios>> GetEjercicioByMascotaAsync(string nombreMascota)
        {
            return
           db.Table<Ejercicios>().Where(p => p.IdMascota.Equals(nombreMascota)).ToListAsync();
        }
        public Task<int> DeleteEjercicioAsync(Ejercicios ejercicio)
        {
            return db.DeleteAsync(ejercicio);
        }
    }
}
