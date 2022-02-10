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
    public class DBTasks
    {
        private const string CNSTRING = @"Server=(LocalDB)\MSSQLLocalDB;Database=PawPalsDB;Integrated Security=SSPI;";
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
                        return null;
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

        public static object GetUpdateUserResult(UpdateUser user)
        {
            User result = null;
            try 
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
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return new User();
        }

        public static object GetDeleteUserResult(DeleteUser obj)
        {
            throw new NotImplementedException();
        }

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

        public static object GetRemovePostResult(Post obj)
        {
            throw new NotImplementedException();
        }

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
                while (dr.Read())
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
                    posts.Posts.Add(new Post()
                    {
                        ID = dr.GetInt32(0),
                        Username = name,
                        Img = (byte[])dr["Img"]
                    });
                }
                cn.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return posts;
        }

        public static object GetPostsFromUser(PostList posts)
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
                while (dr.Read())
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
                    cmdn.CommandText = $"SELECT Liked FROM Reactions " +
                        $"WHERE UserID = {posts.RequesterID} AND PostID = {dr.GetInt32(0)}";
                    var liked = (bool)cmdn.ExecuteScalar();
                    posts.Posts.Add(new Post()
                    {
                        ID = dr.GetInt32(0),
                        Username = name,
                        Img = (byte[])dr["Img"],
                        Reaction = (liked) ? PostReaction.LIKE : PostReaction.DISLIKE
                    });
                }
                cn.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return posts;
        }

        public static object GetReportPostResult(PostReport obj)
        {
            throw new NotImplementedException();
        }

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
                return PostReaction.LIKE;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return PostReaction.NONE;
        }

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
