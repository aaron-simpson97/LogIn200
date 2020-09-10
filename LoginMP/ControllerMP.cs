using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMP
{
    public enum State
    {
        NOTINIT = -1,
        START = 0,
        GOTUSERNAME,
        GOTPASSWORD,
        SUCCESS,
        DECLINED,
        EXIT
    }
    public class ControllerMP
    {
        private StateObserver observer;
        CredentialsMP model;

        public ControllerMP(CredentialsMP m)
        {
            model = m;
        }
        public void register(StateObserver obs)
        {
            observer = obs;
        }
        public void handleEvents(State state, String args)
        {
            switch (state)
            {
                case State.START:

                    observer(State.START);
                    break;
                case State.GOTUSERNAME:
                    observer(State.GOTUSERNAME);
                    break;
                case State.GOTPASSWORD:
                    observer(State.GOTPASSWORD);
                    bool valid = validateCredentials(args);
                    if (valid)
                    {
                        observer(State.SUCCESS);
                    }
                    else
                    {
                        observer(State.DECLINED);
                    }
                    break;
                default:
                    break;
            }
        }

        private bool validateCredentials(String cred)
        {
            bool result = false;
            String[] tokens = cred.Split(':');
            String un = tokens[0];
            String up = tokens[1];

            result = model.Validate(un, up);
            return result;
        }
    }
}
