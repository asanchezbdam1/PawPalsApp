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

        /// <summary>
        /// Metodo que crea una nueva tabla para guardar las mascotas
        /// </summary>
        /// <param name="dbPath"></param>
        public SQLiteMascota(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Mascotas>().Wait();
        }

        /// <summary>
        /// Metodo que en base a un objeto mascota este se guarda en la
        /// tabla o se sobreescribe 
        /// </summary>
        /// <param name="mascota"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo que devuelve la lista de objetos mascotas en la tabla
        /// </summary>
        /// <returns></returns>
        public Task<List<Mascotas>> GetMascotasAsync()
        {
            return db.Table<Mascotas>().ToListAsync();
        }

        /// <summary>
        /// Devuelve unas mascotas dependiendo del nombre de mascota que se la pase como parametro
        /// </summary>
        /// <param name="nombreMascota"></param>
        /// <returns></returns>
        public Task<Mascotas> GetMascotasByNameAsync(string nombreMascota)
        {
            return
           db.Table<Mascotas>().Where(p => p.Nombre.Equals(nombreMascota)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Elimina la mascota de la tabla pasada como parametro
        /// </summary>
        /// <param name="mascota"></param>
        /// <returns></returns>
        public Task<int> DeleteExperienciaAsync(Mascotas mascota)
        {
            return db.DeleteAsync(mascota);
        }
    }
}
