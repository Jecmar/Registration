using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Business;

namespace Visual
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            var Skin = MaterialSkinManager.Instance;
            Skin.AddFormToManage(this);
            Skin.Theme = MaterialSkinManager.Themes.LIGHT;
            Skin.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            User user = new User();
            SqlDataReader Log;
            user.Usuario = materialSingleLineTextField1.Text;
            user.Password = materialSingleLineTextField2.Text;

            if (user.Usuario == materialSingleLineTextField1.Text)
            {
                label1.Visible = false;
                if (user.Password == materialSingleLineTextField2.Text)
                {
                    label2.Visible = false;
                    Log = user.Log();
                    if (Log.Read() == true)
                    {
                        this.Hide();
                        Menu M = new Menu();
                        M.Show();
                    }
                    else
                    {
                        label3.Text = "The Username or Password is incorrect, please try again";
                        label3.Visible = true;
                        materialSingleLineTextField1.Text = "";
                        materialSingleLineTextField2.Text = "";
                        materialSingleLineTextField1_Leave(null, e);
                        materialSingleLineTextField2_Leave(null, e);
                        materialSingleLineTextField1.Focus();
                    }
                }

                else
                {
                    //contraseña
                    label2.Text = user.Password;
                    label2.Visible = true;
                }
            }
            else
            {
                //usuario
                label1.Text = user.Usuario;
                label1.Visible = true;            }             
        }

        private void materialSingleLineTextField1_Enter(object sender, EventArgs e)
        {
            if(materialSingleLineTextField1.Text == "USERNAME")
            {
                materialSingleLineTextField1.Text = "";
                materialSingleLineTextField1.ForeColor = Color.LightGray;
            }
        }

        private void materialSingleLineTextField1_Leave(object sender, EventArgs e)
        {
            if(materialSingleLineTextField1.Text == "")
            {
                materialSingleLineTextField1.Text = "USERNAME";
                materialSingleLineTextField1.ForeColor = Color.DarkGray;
            }
        }

        private void materialSingleLineTextField2_Enter(object sender, EventArgs e)
        {
            if(materialSingleLineTextField2.Text == "PASSWORD")
            {
                materialSingleLineTextField2.Text = "";
                materialSingleLineTextField2.UseSystemPasswordChar = true;
            }
        }

        private void materialSingleLineTextField2_Leave(object sender, EventArgs e)
        {
            if(materialSingleLineTextField2.Text == "")
            {
                materialSingleLineTextField2.Text = "PASSWORD";
                materialSingleLineTextField2.UseSystemPasswordChar = false;
            }
        }
    }
}
