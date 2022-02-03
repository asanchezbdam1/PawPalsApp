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
                    break;
                case ActionOptions.REGISTER:
                    return DBTasks.GetRegisterResult((RegisterUser)obj);
                    break;
                case ActionOptions.UPDATE_USER:
                    return DBTasks.GetUpdateUserResult((UpdateUser)obj);
                    break;
                case ActionOptions.DELETE_USER:
                    return DBTasks.GetDeleteUserResult((DeleteUser)obj);
                    break;
                case ActionOptions.PUBLISH_POST:
                    return DBTasks.GetPublishPostResult((Post)obj);
                    break;
                case ActionOptions.REMOVE_POST:
                    return DBTasks.GetRemovePostResult((Post)obj);
                    break;
                case ActionOptions.RETRIEVE_POSTS:
                    return DBTasks.GetPosts((PostList)obj);
                    break;
                case ActionOptions.RETRIEVE_POSTS_FROM_USER:
                    return DBTasks.GetPostsFromUser((PostList)obj);
                    break;
                case ActionOptions.REPORT_POST:
                    return DBTasks.GetReportPostResult((ReportPost)obj);
                    break;
                case ActionOptions.LIKE_POST:
                    return DBTasks.GetLikePostResult((PostReaction)obj);
                    break;
                case ActionOptions.DISLIKE_POST:
                    return DBTasks.GetDislikePostResult((PostReaction)obj);
                    break;
                case ActionOptions.REMOVE_OPINION_FROM_POST:
                    return DBTasks.GetRemoveOpinionResult((PostReaction)obj);
                    break;
                default:
                    return null;
            }
        }
    }
}
