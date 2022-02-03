using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CrossClasses;

namespace ServerActions
{
    public class DBTasks
    {
        private const string CNSTRING = "";
        public static object GetLoginResult(LoginUser user)
        {
            return user;
        }

        internal static object GetRegisterResult(RegisterUser obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetUpdateUserResult(UpdateUser obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetDeleteUserResult(DeleteUser obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetPublishPostResult(Post obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetRemovePostResult(Post obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetPosts(PostList obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetPostsFromUser(PostList obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetReportPostResult(ReportPost obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetLikePostResult(PostReaction obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetDislikePostResult(PostReaction obj)
        {
            throw new NotImplementedException();
        }

        internal static object GetRemoveOpinionResult(PostReaction obj)
        {
            throw new NotImplementedException();
        }
    }
}
