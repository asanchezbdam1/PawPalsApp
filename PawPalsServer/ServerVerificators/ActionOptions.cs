using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerVerificators
{
    public enum ActionOptions
    {
        ERROR,
        LOGIN, REGISTER, UPDATE_USER, DELETE_USER,
        PUBLISH_POST, REMOVE_POST, RETRIEVE_POSTS, RETRIEVE_POSTS_FROM_USER,
        REPORT_POST, LIKE_POST, DISLIKE_POST, REMOVE_OPINION_FROM_POST
    }
}
