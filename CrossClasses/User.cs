using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    /// <summary>
    /// Clase que modela el usuario
    /// con la sesión actual iniciada.
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Nombre de usuario para
        /// el inicio de sesión.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// País del usuario.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Ciudad del usuario.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Imagen de perfil del usuario.
        /// Actualmente sin mostrarse ni
        /// guardarse en base de datos.
        /// </summary>
        public byte[] Img { get; set; }

        /// <summary>
        /// Constructor de
        /// la clase usuario.
        /// </summary>
        public User()
        {
            Id = 0;
            Name = String.Empty;
            Email = String.Empty;
            Login = String.Empty;
            Pwd = String.Empty;
            Country = String.Empty;
            City = String.Empty;
            Img = new byte[1];
        }
    }

    /// <summary>
    /// Subtipo de usuario para
    /// registrarlo como nuevo usuario.
    /// </summary>
    [Serializable]
    public class RegisterUser : User { }

    /// <summary>
    /// Subtipo de usuario para el
    /// inicio de sesión del usuario.
    /// </summary>
    [Serializable]
    public class LoginUser : User { }

    /// <summary>
    /// Subtipo de usuario para
    /// la actualización de
    /// información del usuario.
    /// </summary>
    [Serializable]
    public class UpdateUser : User { }

    /// <summary>
    /// Subtipo de usuario para
    /// el borrado del usuario.
    /// </summary>
    [Serializable]
    public class DeleteUser : User { }
}
