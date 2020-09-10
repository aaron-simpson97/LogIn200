using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMP
{
    public partial class LoginMP : Form
    {
        private InputHandler inHandler;
        public LoginMP(InputHandler ih)
        {
            InitializeComponent();
            inHandler = ih;
        }

        public void DisplayState(State state)
        {
            switch (state)
            {
                case State.START:
                    lbStateMessage.Text = "Please Enter Username";
                    tbPassword.Enabled = false;
                    uxLoginBtn.Enabled = false;
                    break;
                case State.GOTUSERNAME:
                    lbStateMessage.Text = "Please Enter Password";
                    tbPassword.Enabled = true;
                    break;
                case State.GOTPASSWORD:
                    lbStateMessage.Text = "Validating Credentials...";
                    break;
                case State.DECLINED:
                    tbUserName.Text = "";
                    tbPassword.Text = "";
                    lbStateMessage.Text = "Sorry, Invalid Credentials";
                    break;
                case State.SUCCESS:
                    lbStateMessage.Text = "Congrats! You are Loggedin";
                    break;
                default:
                    lbStateMessage.Text = "Invalid State";
                    break;

            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            inHandler(State.START, "");
        }

        private void tbUserName_TextChanged_1(object sender, EventArgs e)
        {
            inHandler(State.GOTUSERNAME, "");
        }

        private void tbPassword_TextChanged_1(object sender, EventArgs e)
        {
            uxLoginBtn.Enabled = true;
        }

        private void uxLoginBtn_Click_1(object sender, EventArgs e)
        {
            String un = tbUserName.Text;
            String up = tbPassword.Text;
            Console.WriteLine(un + " " + up);
            inHandler(State.GOTPASSWORD, un + ":" + up);
        }
    }
}
