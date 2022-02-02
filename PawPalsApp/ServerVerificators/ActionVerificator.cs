using CrossClasses;
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
