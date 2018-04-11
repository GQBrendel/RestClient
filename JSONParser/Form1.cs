using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace JSONParser
{
    public partial class JSONParser : Form
    {
        public JSONParser()
        {
            InitializeComponent();
        }

        #region UI events
        private void cmdDeserialise_Click(object sender, EventArgs e)
        {
            deserialiseJSON(txtInput.Text);
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtDebugOutput.Text = string.Empty;
        }
        #endregion


        #region json functions
        private void deserialiseJSON(string strJSON)
        {
            try
            {
                var jPerson = JsonConvert.DeserializeObject<jsonPerson>(strJSON);
                debugOutput("Here's our JSON object: " + jPerson.ToString());
                debugOutput("Here's the First Name: " + jPerson.firstname);

                debugOutput("Here's the Street Address: " + jPerson.address.streetAddress);
                
                foreach(var num in jPerson.phoneNumbers)
                {
                    debugOutput(num.type.ToString() + " - " + num.number.ToString());
                }

                /*var jPerson = JsonConvert.DeserializeObject<dynamic>(strJSON);
                debugOutput("Here's our JSON object: " + jPerson.ToString());
                debugOutput("Here's the Name: " + jPerson.name);*/

            }
            catch (Exception ex)
            {
                debugOutput("We had a problem: " + ex.Message.ToString());
            }
        }

        #endregion
        #region Debug Output
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtDebugOutput.Text = txtDebugOutput.Text + strDebugText + Environment.NewLine;
                txtDebugOutput.SelectionStart = txtDebugOutput.TextLength;
                txtDebugOutput.ScrollToCaret();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }
        
        #endregion



    }
}
