using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMP
{
    public delegate void InputHandler(State state, String args);
    public delegate void StateObserver(State state);
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CredentialsMP model = new CredentialsMP();
            ControllerMP controller = new ControllerMP(model);
            LoginMP view = new LoginMP(controller.handleEvents);
            controller.register(view.DisplayState);
            Application.Run(view);
        }
    }
}
