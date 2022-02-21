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
        /// <summary>
        /// Metodo que crea una nueva tabla para guardar dietas
        /// </summary>
        /// <param name="dbPath"></param>
        public SQLiteDieta(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Dieta>().Wait();
        }

        /// <summary>
        /// Metodo que en base a un objeto dieta este se guarda en la
        /// tabla o se sobreescribe 
        /// </summary>
        /// <param name="dieta"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo que devuelve la lista de objetos dieta en la tabla
        /// </summary>
        /// <returns></returns>
        public Task<List<Dieta>> GetDietaAsync()
        {
            return db.Table<Dieta>().ToListAsync();
        }

        /// <summary>
        /// Devuelve unas dietas dependiendo del nombre de mascota que se la pase como parametro
        /// </summary>
        /// <param name="nombreMascota"></param>
        /// <returns></returns>
        public Task<List<Dieta>> GetDietaByMascotaAsync(string nombreMascota)
        {
            return
           db.Table<Dieta>().Where(p => p.IdMascota.Equals(nombreMascota)).ToListAsync();
        }

        /// <summary>
        /// Elimina la dieta de la tabla pasada como parametro
        /// </summary>
        /// <param name="dieta"></param>
        /// <returns></returns>
        public Task<int> DeleteDietaAsync(Dieta dieta)
        {
            return db.DeleteAsync(dieta);
        }
    }
}
