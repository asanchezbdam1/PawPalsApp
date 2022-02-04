using CrossClasses;
using ServerVerificators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerActions
{
    public class ServerActions
    {
        public static object GetResponse(object obj)
        {
            ActionOptions action = ActionVerificator.VerifyAction(obj);
            switch (action)
            {
                case ActionOptions.LOGIN:
                    return DBTasks.GetLoginResult((LoginUser)obj);
                case ActionOptions.REGISTER:
                    return DBTasks.GetRegisterResult((RegisterUser)obj);
                case ActionOptions.UPDATE_USER:
                    return DBTasks.GetUpdateUserResult((UpdateUser)obj);
                case ActionOptions.DELETE_USER:
                    return DBTasks.GetDeleteUserResult((DeleteUser)obj);
                case ActionOptions.PUBLISH_POST:
                    return DBTasks.GetPublishPostResult((Post)obj);
                case ActionOptions.REMOVE_POST:
                    return DBTasks.GetRemovePostResult((Post)obj);
                case ActionOptions.RETRIEVE_POSTS:
                    return DBTasks.GetPosts((PostList)obj);
                case ActionOptions.RETRIEVE_POSTS_FROM_USER:
                    return DBTasks.GetPostsFromUser((PostList)obj);
                case ActionOptions.REPORT_POST:
                    return DBTasks.GetReportPostResult((PostReport)obj);
                case ActionOptions.LIKE_POST:
                    return DBTasks.GetLikePostResult((PostReaction)obj);
                case ActionOptions.DISLIKE_POST:
                    return DBTasks.GetDislikePostResult((PostReaction)obj);
                case ActionOptions.REMOVE_OPINION_FROM_POST:
                    return DBTasks.GetRemoveOpinionResult((RemovePostReaction)obj);
                default:
                    return null;
            }
        }
    }
}
