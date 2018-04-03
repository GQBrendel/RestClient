using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpRestClien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdGO_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = txtRequestURI.Text;

            if(rdoRollOwn.Checked)
            {
                rClient.authTech = authenticationTechnique.RollYourOwn;
                DebugOutput("AuthTechinique: " + rClient.authTech);
                DebugOutput("AuthType " + rClient.authType);
            }
            else
            {
                rClient.authTech = authenticationTechnique.RollYourOwn;
                DebugOutput("AuthTechinique: " + rClient.authTech);
                DebugOutput("AuthType ??? - NetCred decides!");
            }
            rClient.userName = txtUserName.Text ;
            rClient.userPassword = txtPassword.Text;

            DebugOutput("Rest Client Created");
            string strResponse = string.Empty;

            strResponse = rClient.MakeRequest();

            DebugOutput(strResponse);
        }

        #region Debug
        public void DebugOutput(string strDebugText)
        {
           // try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
          //  catch (Exception ex)
            {
                //System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
        #endregion

    }
}
