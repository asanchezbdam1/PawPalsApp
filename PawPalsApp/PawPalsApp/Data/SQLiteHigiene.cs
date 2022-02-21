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
        /// <summary>
        /// Metodo que crea una nueva tabla para guardar higiene
        /// </summary>
        /// <param name="dbPath"></param>
        public SQLiteHigiene(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Higiene>().Wait();
        }

        /// <summary>
        /// Metodo que en base a un objeto higiene este se guarda en la
        /// tabla o se sobreescribe 
        /// </summary>
        /// <param name="higiene"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo que devuelve la lista de objetos higiene en la tabla
        /// </summary>
        /// <returns></returns>
        public Task<List<Higiene>> GetHigieneAsync()
        {
            return db.Table<Higiene>().ToListAsync();
        }

        /// <summary>
        /// Devuelve unas higienes dependiendo del nombre de mascota que se la pase como parametro
        /// </summary>
        /// <param name="nombreMascota"></param>
        /// <returns></returns>
        public Task<List<Higiene>> GetHigieneByMascotaAsync(string nombreMascota)
        {
            return
           db.Table<Higiene>().Where(p => p.IdMascota.Equals(nombreMascota)).ToListAsync();
        }

        /// <summary>
        /// Elimina la higiene de la tabla pasada como parametro
        /// </summary>
        /// <param name="higiene"></param>
        /// <returns></returns>
        public Task<int> DeleteHigieneAsync(Higiene higiene)
        {
            return db.DeleteAsync(higiene);
        }
    }
}
