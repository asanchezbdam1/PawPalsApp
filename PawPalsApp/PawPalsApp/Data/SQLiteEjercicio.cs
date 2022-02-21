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
        /// <summary>
        /// Metodo que crea una nueva tabla para guardar ejercicios
        /// </summary>
        /// <param name="dbPath"></param>
        public SQLiteEjercicio(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Ejercicios>().Wait();
        }

        /// <summary>
        /// Metodo que en base a un objeto ejercicios este se guarda en la
        /// tabla o se sobreescribe 
        /// </summary>
        /// <param name="ejercicio"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo que devuelve la lista de objetos ejercicios en la tabla
        /// </summary>
        /// <returns></returns>
        public Task<List<Ejercicios>> GetEjercicioAsync()
        {
            return db.Table<Ejercicios>().ToListAsync();
        }

        /// <summary>
        /// Devuelve unos ejercicios dependiendo del nombre de mascota que se la pase como parametro
        /// </summary>
        /// <param name="nombreMascota"></param>
        /// <returns></returns>
        public Task<List<Ejercicios>> GetEjercicioByMascotaAsync(string nombreMascota)
        {
            return
           db.Table<Ejercicios>().Where(p => p.IdMascota.Equals(nombreMascota)).ToListAsync();
        }

        /// <summary>
        /// Elimina el Ejercicio de la tabla pasada como parametro
        /// </summary>
        /// <param name="ejercicio"></param>
        /// <returns></returns>
        public Task<int> DeleteEjercicioAsync(Ejercicios ejercicio)
        {
            return db.DeleteAsync(ejercicio);
        }
    }
}
