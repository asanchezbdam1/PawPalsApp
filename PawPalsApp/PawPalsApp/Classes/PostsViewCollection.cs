using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace PawPalsApp.Classes
{
    /// <summary>
    /// Clase que modela una lista
    /// observable de publicaciones.
    /// </summary>
    public class PostsViewCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public PostsViewCollection()
        {
            CollectionChanged += PVCollectionChanged;
        }

        /// <summary>
        /// Añade a la observación o
        /// elimina el objeto añadido
        /// o eliminado a la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PVCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object item in e.NewItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemPropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (object item in e.OldItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemPropertyChanged;
                }
            }
        }

        /// <summary>
        /// Método que se ejecuta al
        /// modificar la propiedad de
        /// una publicación para actualizar
        /// la lista y con ello la interfaz.
        /// </summary>
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, IndexOf((T)sender));
            OnCollectionChanged(args);
        }
    }
}
