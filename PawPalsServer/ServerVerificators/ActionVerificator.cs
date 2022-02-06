﻿using CrossClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerVerificators
{
    public static class ActionVerificator
    {
        public static ActionOptions VerifyAction(Object action)
        {
            if (action is User)
            {
                return VerifyUserAction((User)action);
            }
            if (action is Post)
            {
                Post p = action as Post;
                if (p.ID == 0 && p.UID != 0)
                {
                    return ActionOptions.PUBLISH_POST;
                }
                if (p.Liked) return ActionOptions.LIKE_POST;
                if (p.Disliked) return ActionOptions.DISLIKE_POST;
                return ActionOptions.REMOVE_OPINION_FROM_POST;
            }
            if (action is PostList)
            {
                if (((PostList)action).FromRequester) return ActionOptions.RETRIEVE_POSTS_FROM_USER;
                return ActionOptions.RETRIEVE_POSTS;
            }
            return ActionOptions.ERROR;
        }

        private static ActionOptions VerifyUserAction(User user)
        {
            if (user is RegisterUser)
                return ActionOptions.REGISTER;
            if (user is LoginUser)
                return ActionOptions.LOGIN;
            if (user is UpdateUser)
                return ActionOptions.UPDATE_USER;
            if (user is DeleteUser)
                return ActionOptions.DELETE_USER;
            return ActionOptions.ERROR;
        }
    }
}
