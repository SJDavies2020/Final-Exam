// Steven Davies
// 200411361
// Final Exam - Comp1030


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalExamQuestion
{
    public partial class contactForm : Form
    {
        public contactForm()
        {
            InitializeComponent();
        }
        private void contactForm_Load(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            textBoxValidation();
        }

        private void chkPermission_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPermission.Checked)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }

        }

        public void reset()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Clear();
                }
            }

            foreach (Control y in this.Controls)
            {
                if (y is CheckBox)
                {
                    ((CheckBox)y).Checked = false;
                }
            }
            // Question 5. Uncomment the foreach loop and debug where necessary.

           foreach (Control z in this.Controls)
           {
               if (z is ComboBox)
           {
                    // Reset the Combo Box Selection
                    cmbStreetType.SelectedIndex = -1;
                    cmbProvinces.SelectedIndex = -1;
           }
           }
        }

        public void textBoxValidation()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please fill in your first name", "INPUT ERROR");
            }
            else if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please fill in your last name", "INPUT ERROR");
            }
            else if (string.IsNullOrWhiteSpace(txtStreetNumber.Text))
            {
                MessageBox.Show("Please fill in your street number", "INPUT ERROR");
            }
            else if (string.IsNullOrWhiteSpace(txtStreetName.Text))
            {
                MessageBox.Show("Please fill in your street name", "INPUT ERROR");
            }
            else if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Please fill in your city", "INPUT ERROR");
            }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill in your email address", "INPUT ERROR");
            }
            else if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Please fill in your user name", "INPUT ERROR");
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in your password", "INPUT ERROR");
            }
            else if (string.IsNullOrWhiteSpace(txtPasswordVerify.Text))
            {
                MessageBox.Show("Please fill in your password verification", "INPUT ERROR");
            }
            else
            {
                streetNumValidation();
                return;
            }
        }

        // Question 2
        // Add number validation to the textbox labelled txtStreetNumber verifying the entry is an integer

        public void streetNumValidation()
        {
            Int32 TheStreetNum;

            // Test to see if the TextBox is an integer Value
            Boolean StreetNum = Int32.TryParse(txtStreetNumber.Text, out TheStreetNum);

            // If Integer then do nothing               
            if (StreetNum)
            {
            }
            // If Not Integer then Show message Box;
            else
            {
                MessageBox.Show("Please Enter a Number Only!");
            }
            streetTypeNotEmpty();
        }

        public void streetTypeNotEmpty()
        {
            if (string.IsNullOrEmpty(cmbStreetType.Text))
            {
                MessageBox.Show("Street type is blank", "INPUT ERROR");
            }
            else
            {
                provincesNotEmpty();
                return;
            }
        }
        public void provincesNotEmpty()
        {
            if (string.IsNullOrEmpty(cmbProvinces.Text))
            {
                MessageBox.Show("Provinces field is blank", "INPUT ERROR");
            }
            else
            {
                emailValidation();
                return;
            }
        }

        private void emailValidation()
        {
            if (this.IsValidEmail(txtEmail.Text))
            {
                passwordVerify(txtPassword.Text,txtPasswordVerify.Text);
                output();
            }
            else
            {
                MessageBox.Show(txtEmail.Text + " is not in a valid email format.", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        // Question 3. Add an if statement that validates that the two text boxes (txtPassword and txtPasswordVerify are the same.
        // Where the result is true, call the method output (see below).
        // Pass into function the 2 passwords and check if they are equal. If not show a message box.
        public void passwordVerify(String Pass1, String Pass2)
        {
            if (Pass1 == Pass2)
            {
                output();
            }

            else {
                MessageBox.Show("Passwords don't match!");
            }
        }
        private bool IsValidEmail(string email)
        {

            return Regex.IsMatch(txtEmail.Text, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
        }

        // Question 4. Add an array based on the SelectedIndex of the cmbProvinces that will return the full province name
        // in the message box. The list of the provinces are commented out below and can be accessed by
        // uncommenting them. The result MUST replace the cmbProvinces output in the MessageBox
        private void output()
        {
            // Create String array of the province Names;
            String[] MyProvinces = { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland Labrador", "Nova Scotia", "Northwest Territories", "Nunavut, Ontario", "Prince Edward Island", "Quebec", "Saskatchewan", "Yukon" };

            // Alberta British Columbia Manitoba New Brunswick Newfoundland Labrador Nova Scotia Northwest Territories Nunavut Ontario Prince Edward Island Quebec Saskatchewan Yukon

            // Check the Combo Box Status.  If no selection do nothing. If selection then show results.
            if (cmbProvinces.SelectedIndex == -1)
            {
            }
            else
            {
            DialogResult dialogResult = MessageBox.Show("Name: " + "\t\t" + txtFirstName.Text + " " + txtLastName.Text + "\n" +
            "Address: " + "\t\t" + txtStreetNumber.Text + " " + txtStreetName.Text + " " + cmbStreetType.Text + "\n" +
            "\t\t" + txtCity.Text + ", " + MyProvinces[(cmbProvinces.SelectedIndex)] + "\n" +
            "Email: " + "\t\t" + txtEmail.Text + "\n" +
            "User Name: " + "\t" + txtUserName.Text + "\nPassword:\t" + txtPassword.Text + "\n\nPASSWORD CONFIRMED\n\nDo you wish to close the application?"
            , "SUBMISSION CONFIRMATION", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.No)
                {
                        reset();
                }
            }
        }

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        }

        private void timeNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void validateTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxValidation();
        }
    }
}





