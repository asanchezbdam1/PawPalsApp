using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CrossClasses;
using System.Security.Cryptography;

namespace ServerActions
{
    /// <summary>
    /// Clase para el acceso
    /// a la base de datos.
    /// </summary>
    public class DBTasks
    {
        /// <summary>
        /// Cadena de conexión
        /// a la base de datos.
        /// Es una base de datos
        /// SQL en el equipo local
        /// con seguridad integrada.
        /// </summary>
        private const string CNSTRING = @"Server=(LocalDB)\MSSQLLocalDB;Database=PawPalsDB;Integrated Security=SSPI;";

        /// <summary>
        /// Inicia sesión del usuario
        /// pasado como parámetro.
        /// </summary>
        /// <param name="user">Usuario con información
        /// para iniciar sesión.</param>
        /// <returns>Su información
        /// si es correcto o un
        /// usuario sin información
        /// si algo está mal.</returns>
        public static object GetLoginResult(LoginUser user)
        {
            User result = null;
            try
            {
                if (VerifyLogin(user))
                {
                    var cn = new SqlConnection(CNSTRING);
                    cn.Open();
                    var cmd = new SqlCommand($"SELECT * FROM Users WHERE " +
                            $"Username LIKE '{user.Login}'");
                    //$"Username LIKE '{user.Name}' OR Email LIKE '{user.Email}'");
                    cmd.Connection = cn;
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = new User()
                        {
                            Id = dr.GetInt32(0),
                            Login = dr.GetString(1),
                            Email = dr.GetString(2),
                            Country = dr.GetString(4),
                            City = dr.GetString(5),
                            Name = dr.GetString(6)
                        };
                    };
                    cn.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            if (result == null)
            {
                return new User();
            }
            return result;
        }

        /// <summary>
        /// Registra el usuario
        /// pasado como parámetro.
        /// </summary>
        /// <param name="user">Usuario con
        /// información para el registro.</param>
        /// <returns>Su información
        /// si es correcto o un
        /// usuario sin información
        /// si algo está mal.</returns>
        public static object GetRegisterResult(RegisterUser user)
        {
            User result = null;
            try
            {
                if (!CheckIfRegistered(user))
                {
                    var cn = new SqlConnection(CNSTRING);
                    cn.Open();
                    var cmd = new SqlCommand($"INSERT INTO Users (Username, Email, Pwd, Country, City, FullName) " +
                        $"VALUES ('{user.Login}', '{user.Email}', '{GetHash(user.Pwd)}', '', '', '')");
                    cmd.Connection = cn;
                    var res = (int)cmd.ExecuteNonQuery();
                    if (res != 1)
                    {
                        return new User();
                    }
                    cmd.CommandText = $"SELECT * FROM Users WHERE " +
                        $"Username LIKE '{user.Login}' OR Email LIKE '{user.Email}'";
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = new User()
                        {
                            Id = dr.GetInt32(0),
                            Login = dr.GetString(1),
                            Email = dr.GetString(2),
                            Country = dr.GetString(4),
                            City = dr.GetString(5),
                            Name = dr.GetString(6)
                        };
                    };
                    cn.Close();
                    return result;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return new User();
        }

        /// <summary>
        /// Actualiza la información
        /// del usuario pasado
        /// como parámetro.
        /// </summary>
        /// <param name="user">Usuario con
        /// información para actualizar.</param>
        /// <returns>Su información
        /// si es correcto o un
        /// usuario sin información
        /// si algo está mal.</returns>
        public static object GetUpdateUserResult(UpdateUser user)
        {
            User result = null;
            try 
            {
                if (VerifyLogin(user))
                {
                    var cn = new SqlConnection(CNSTRING);
                    cn.Open();
                    var cmd = new SqlCommand($"UPDATE Users " +
                        $"SET FullName = '{user.Name}', Country = '{user.Country}', City = '{user.City}' " +
                        $"WHERE UserID = {user.Id} AND Username LIKE '{user.Login}'");
                    cmd.Connection = cn;
                    var res = (int)cmd.ExecuteNonQuery();
                    if (res != 1)
                    {
                        return new User();
                    }
                    cmd.CommandText = $"SELECT * FROM Users WHERE " +
                        $"Username LIKE '{user.Login}' OR Email LIKE '{user.Email}'";
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = new User()
                        {
                            Id = dr.GetInt32(0),
                            Login = dr.GetString(1),
                            Email = dr.GetString(2),
                            Country = dr.GetString(4),
                            City = dr.GetString(5),
                            Name = dr.GetString(6)
                        };
                    };
                    cn.Close();
                    return result;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return new User();
        }

        /// <summary>
        /// Borra el usuario
        /// pasado como parámetro.
        /// </summary>
        /// <param name="user">Usuario con
        /// información para eliminar.</param>
        /// <returns>Su información
        /// si es correcto o un
        /// usuario sin información
        /// si algo está mal.</returns>
        public static object GetDeleteUserResult(DeleteUser user)
        {
            try
            {
                if (VerifyLogin(user))
                {
                    var cn = new SqlConnection(CNSTRING);
                    cn.Open();
                    var cmd = new SqlCommand($"DELETE FROM Users " +
                        $"WHERE UserID = {user.Id} AND Username LIKE '{user.Login}'");
                    cmd.Connection = cn;
                    var res = (int)cmd.ExecuteNonQuery();
                    if (res != 1)
                    {
                        return new User();
                    }
                    cn.Close();
                    return user;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return user;
        }

        /// <summary>
        /// Guarda la publicación
        /// pasada como parámetro.
        /// </summary>
        /// <param name="post">Publicación a guardar</param>
        /// <returns>La misma publicación si es
        /// correcto o una nueva si no lo es.</returns>
        public static object GetPublishPostResult(Post post)
        {
            try
            {
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var bytes = new SqlParameter("@image", SqlDbType.Binary)
                {
                    Direction = ParameterDirection.Input,
                    Size = post.Img.Length,
                    Value = post.Img
                };

                var cmd = new SqlCommand($"INSERT INTO Posts (UserID, Img) " +
                    $"VALUES ({post.UID}, @image)");
                cmd.Parameters.Add(bytes);
                cmd.Connection = cn;
                var res = (int)cmd.ExecuteNonQuery();
                if (res != 1)
                {
                    return new Post();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); post = new Post(); }
            return post;
        }

        /// <summary>
        /// Borra la publicación
        /// pasada como parámetro.
        /// PENDIENTE IMPLEMENTAR.
        /// </summary>
        /// <param name="post">Publicación a eliminar.</param>
        /// <returns>Resultado de borrar la publicación.</returns>
        public static object GetRemovePostResult(Post post)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rellena la lista de
        /// publicaciones pasada
        /// como parámetro.
        /// </summary>
        /// <param name="posts">Lista de publicaciones a rellenar.</param>
        /// <returns>La lista de publicaciones
        /// tras intentar rellenarla.</returns>
        public static object GetPosts(PostList posts)
        {
            try
            {
                posts.Posts.Clear();
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var cmd = new SqlCommand($"SELECT TOP 15 * FROM Posts WHERE NOT UserID = {posts.RequesterID} " +
                    $"AND PostID NOT IN (SELECT PostID FROM Reactions WHERE UserID = {posts.RequesterID}) " +
                    $"ORDER BY UploadDate");
                cmd.Connection = cn;
                var dr = cmd.ExecuteReader();
                posts.Posts = GetPostsInfo(dr, posts.RequesterID);
                cn.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return posts;
        }

        /// <summary>
        /// Rellena la lista de
        /// publicaciones pasada
        /// como parámetro con
        /// publicaciones del
        /// usuario que las solicita.
        /// </summary>
        /// <param name="posts">Lista de publicaciones a rellenar.</param>
        /// <returns>La lista de publicaciones
        /// tras intentar rellenarla.</returns>
        public static object GetPostsFromUser(PostList posts)
        {
            try
            {
                posts.Posts.Clear();
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var cmd = new SqlCommand($"SELECT TOP 15 * FROM Posts WHERE UserID = {posts.RequesterID} " +
                    $"ORDER BY UploadDate");
                cmd.Connection = cn;
                var dr = cmd.ExecuteReader();
                posts.Posts = GetPostsInfo(dr, posts.RequesterID);
                cn.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return posts;
        }

        /// <summary>
        /// Rellena la lista de
        /// publicaciones pasada
        /// como parámetro con
        /// publicaciones vistas por el
        /// usuario que las solicita.
        /// </summary>
        /// <param name="posts">Lista de publicaciones a rellenar.</param>
        /// <returns>La lista de publicaciones
        /// tras intentar rellenarla.</returns>
        public static object GetPostHistoryFromUser(PostList posts)
        {
            try
            {
                posts.Posts.Clear();
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var cmd = new SqlCommand($"SELECT TOP 15 * FROM Posts WHERE NOT UserID = {posts.RequesterID} " +
                    $"AND PostID IN (SELECT PostID FROM Reactions WHERE UserID = {posts.RequesterID}) " +
                    $"ORDER BY UploadDate");
                cmd.Connection = cn;
                var dr = cmd.ExecuteReader();
                posts.Posts = GetPostsInfo(dr, posts.RequesterID);
                cn.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return posts;
        }

        /// <summary>
        /// Obtiene la información de
        /// las publicaciones pasadas como
        /// parámetro como resultado de consulta.
        /// </summary>
        /// <param name="dr">Resultado de la consulta de publicaciones.</param>
        /// <param name="userID">ID del usuario que solicita las publicaciones.</param>
        /// <returns>Lista de publicaciones a partir de la consulta con información.</returns>
        private static List<Post> GetPostsInfo(SqlDataReader dr, int userID)
        {
            var posts = new List<Post>();
            while (dr.Read())
            {
                try
                {
                    string name = String.Empty;
                    var cmdn = new SqlCommand();
                    cmdn.CommandText = $"SELECT Username FROM Users WHERE UserID = {dr.GetInt32(1)}";
                    var cnn = new SqlConnection(CNSTRING);
                    cnn.Open();
                    cmdn.Connection = cnn;
                    var drn = cmdn.ExecuteReader();
                    while (drn.Read())
                    {
                        name = drn.GetString(0);
                    }
                    drn.Close();
                    cmdn.CommandText = $"SELECT COUNT(PostID) FROM Reactions " +
                        $"WHERE PostID = {dr.GetInt32(0)} AND Liked = 0";
                    var dislikes = (int)cmdn.ExecuteScalar() + 1;
                    cmdn.CommandText = $"SELECT COUNT(PostID) FROM Reactions " +
                        $"WHERE PostID = {dr.GetInt32(0)} AND Liked = 1";
                    var likes = (int)cmdn.ExecuteScalar() + 1;
                    likes = (likes == 0) ? 1 : likes;
                    dislikes = (dislikes == 0) ? 1 : dislikes;
                    Post p = new Post()
                    {
                        ID = dr.GetInt32(0),
                        Username = name,
                        Img = (byte[])dr["Img"],
                        Likes = likes,
                        Dislikes = dislikes,
                    };
                    try
                    {
                        cmdn.CommandText = $"SELECT Liked FROM Reactions " +
                            $"WHERE UserID = {userID} AND PostID = {dr.GetInt32(0)}";
                        var liked = (bool)cmdn.ExecuteScalar();
                        p.Reaction = (liked) ? PostReaction.LIKE : PostReaction.DISLIKE;
                    }
                    catch (Exception ex) { }
                    posts.Add(p);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return posts;
        }

        /// <summary>
        /// Guarda el reporte
        /// de una publicación.
        /// </summary>
        /// <param name="postRep">Publicación reportada.</param>
        /// <returns>Resultado de reportar la publicación.</returns>
        public static object GetReportPostResult(PostReport postRep)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Resultado de dar "me gusta" a una publicación.
        /// </summary>
        /// <param name="p">Información de la reacción.</param>
        /// <returns>Reacción que tiene el post finalmente.</returns>
        public static object GetLikePostResult(PostReacted p)
        {
            try
            {
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var cmd = new SqlCommand($"DELETE FROM Reactions WHERE PostID = {p.PostID} AND UserID = {p.UserID}");
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"INSERT INTO Reactions (PostID, UserID, Liked) VALUES ({p.PostID}, {p.UserID}, {1})";
                cmd.ExecuteNonQuery();
                cn.Close();
                return PostReaction.LIKE;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return PostReaction.NONE;
}

        /// <summary>
        /// Resultado de dar "no me gusta" a una publicación.
        /// </summary>
        /// <param name="p">Información de la reacción.</param>
        /// <returns>Reacción que tiene el post finalmente.</returns>
        public static object GetDislikePostResult(PostReacted p)
        {
            try
            {
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var cmd = new SqlCommand($"DELETE FROM Reactions WHERE PostID = {p.PostID} AND UserID = {p.UserID}");
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"INSERT INTO Reactions (PostID, UserID, Liked) VALUES ({p.PostID}, {p.UserID}, {0})";
                cmd.ExecuteNonQuery();
                cn.Close();
                return PostReaction.DISLIKE;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return PostReaction.NONE;
        }

        /// <summary>
        /// Resultado de dar quitar la reacción a una publicación.
        /// </summary>
        /// <param name="p">Información de la reacción.</param>
        /// <returns>Reacción que tiene el post finalmente.</returns>
        public static object GetRemoveOpinionResult(PostReacted p)
        {
            try
            {
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var cmd = new SqlCommand($"DELETE FROM Reactions WHERE PostID = {p.PostID} AND UserID = {p.UserID}");
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                cn.Close();
                return PostReaction.NONE;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return PostReaction.LIKE;
        }

        /// <summary>
        /// Comprueba si la información
        /// del usuario pasado como
        /// parámetro es correcta
        /// para iniciar su sesión.
        /// </summary>
        /// <param name="user">Usuario a comprobar</param>
        /// <returns>Verdadero si es correcto el inicio de sesión.</returns>
        private static bool VerifyLogin(User user)
        {
            try
            {
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var cmd = new SqlCommand($"SELECT Pwd FROM Users WHERE " +
                            $"Username LIKE '{user.Login}' OR Email LIKE '{user.Email}'");
                cmd.Connection = cn;
                var res = (string)cmd.ExecuteScalar();
                if (res.Equals(GetHash(user.Pwd)))
                {
                    return true;
                }
                cn.Close();
            } catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        /// <summary>
        /// Comprueba si el usuario pasado
        /// como parámetro está registrado.
        /// </summary>
        /// <param name="user">Usuario a comprobar.</param>
        /// <returns>Verdadero si está registrado el usuario.</returns>
        private static bool CheckIfRegistered(RegisterUser user)
        {
            try
            {
                var cn = new SqlConnection(CNSTRING);
                cn.Open();
                var cmd = new SqlCommand($"SELECT COUNT(*) FROM Users WHERE " +
                        $"Username LIKE '{user.Login}' OR Email LIKE '{user.Email}'");
                cmd.Connection = cn;
                var res = (int)cmd.ExecuteScalar();
                if (res == 0)
                {
                    return false;
                }
                cn.Close();
            } catch (Exception ex) { Console.WriteLine(ex.Message); }
            return true;
        }

        /// <summary>
        /// Obtiene el Hash para almacenar
        /// o comprobar una contraseña.
        /// </summary>
        /// <param name="str">Cadena a convertir a hash.</param>
        /// <returns>Hash de la cadena de texto.</returns>
        private static string GetHash(string str)
        {
            try
            {
                using (SHA256 algorithm = SHA256.Create())
                {
                    var res = algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
                    var sb = new StringBuilder();
                    for (int i = 0; i < res.Length; i++)
                    {
                        sb.Append(res[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            } catch (Exception ex) { Console.WriteLine(ex.Message); }
            return null;
        }
    }
}
