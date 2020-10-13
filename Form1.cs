using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl, kusimus;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2, a1, a2, a3;
        TextBox textbox;
        PictureBox pic_box;
        TabControl tabControl;
        TabPage page1, page2, page3;
        ListBox lbox;
        public Form1()
        {
            this.Height = 700;
            this.Width = 1100;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            //button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;
            //
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            //label
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);
            //
            tn.Nodes.Add(new TreeNode("Markeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstast-TextBox"));
            tn.Nodes.Add(new TreeNode("PictureBox-Pildikast"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Menu"));//меню
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {

                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                lbl = new Label();
                lbl.Text = "Tarkvara arendajad";
                lbl.Size = new Size(150, 30);
                lbl.Location = new Point(150, 200);
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Markeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;

            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp vasakule";
                r1.Location = new Point(300, 30);
                r1.CheckedChanged += new EventHandler(RadioButton_Changed);
                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(300, 70);
                r2.CheckedChanged += new EventHandler(RadioButton_Changed);


                this.Controls.Add(r1);
                this.Controls.Add(r2);

            }
            else if (e.Node.Text == "Tekstast-TextBox")
            {
                string text;
                try
                {
                    text = File.ReadAllText("text.txt");
                }
                catch (FileNotFoundException)
                {
                    text = "Tekst puudub";
                }
                textbox = new TextBox();
                textbox.Multiline = true;
                textbox.Text = text;
                textbox.Location = new Point(300, 300);
                textbox.Width = 200;
                textbox.Height = 200;
                Controls.Add(textbox);
            }
            else if (e.Node.Text == "PictureBox-Pildikast")
            {
                pic_box = new PictureBox();
                pic_box.Image = new Bitmap("smailik.png");
                pic_box.Location = new Point(450, 10);
                pic_box.Size = new Size(100, 100);
                pic_box.SizeMode = PictureBoxSizeMode.Zoom;
                pic_box.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pic_box);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                kusimus = new Label();
                kusimus.Text = "Millise vahelehe avada";
                kusimus.Size = new Size(150, 30);
                kusimus.Location = new Point(350, 130);
                a1 = new RadioButton();
                a1.Text = "Esimene";
                a1.Location = new Point(350, 150);
                a1.CheckedChanged += new EventHandler(radioTab);

                a2 = new RadioButton();
                a2.Text = "Teine";
                a2.Location = new Point(350, 170);
                a2.CheckedChanged += new EventHandler(radioTab);
                a3 = new RadioButton();
                a3.Text = "Kolmas";
                a3.Location = new Point(350, 190);
                a3.CheckedChanged += new EventHandler(radioTab);
                this.Controls.Add(a1);
                this.Controls.Add(a2);
                this.Controls.Add(a3);

            }
            
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad InpudBoxi näha?", "Aken koos nupu", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                }
            }
            
            else if (e.Node.Text == "ListBox")
            {
                string[] Colors_nimetused = new string[] { "Sinine", "Kollane", "Roheline", "Punane" };
                lbox = new ListBox();
                for (int i = 0; i < Colors_nimetused.Length; i++)
                {
                    lbox.Items.Add(Colors_nimetused[i]);
                    lbox.ForeColor = Color.Purple;
                }
                lbox.Location = new Point(150, 300);
                lbox.Width = Colors_nimetused.Length * 13;
                lbox.Height = Colors_nimetused.Length * 15;
                lbox.SelectedIndexChanged += Lbox_SelectedIndexChanged;
                this.Controls.Add(lbox);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet dataSet = new DataSet("Näita");
                dataSet.ReadXml("../../XMLFile.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(600, 200);
                dgv.Width = 400;
                dgv.Height = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "PLANT";
                dgv.DataSource = dataSet;
                this.Controls.Add(dgv);
            }

            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                BackColor = Color.White;
                ForeColor = Color.Black;
                MenuItem item1 = new MenuItem("File");//файл
                item1.MenuItems.Add("Edit");
                item1.MenuItems.Add("Exit", new EventHandler(item1_Exit));//выход
                MenuItem my = new MenuItem("My");//мое меню
                my.MenuItems.Add("New", new EventHandler(item1_new));//новое меню
                my.MenuItems.Add("Full screen", new EventHandler(item1_fullScreen));//большой экран
                my.MenuItems.Add("Random color", new EventHandler(item1_colors1));//рандомный цвет фона
                my.MenuItems.Add("Restarting the program", new EventHandler(item1_restart));//перезагрузка программы
                my.MenuItems.Add("Website", new EventHandler(item1_website));//ссылка на мой сайт 
                menu.MenuItems.Add(item1);
                menu.MenuItems.Add(my);


                this.Menu = menu;
            }
        }

        private void item1_website(object sender, EventArgs e)//меню
        {
            Process.Start("https://valjataga19.thkit.ee/");
        }

        private void item1_restart(object sender, EventArgs e)//меню
        {
            Application.Restart();
        }

        Random random_color = new Random();
        private void item1_colors1(object sender, EventArgs e)//меню
        {
            int Red = random_color.Next(0, 255);
            int Green = random_color.Next(0, 255);
            int Blue = random_color.Next(0, 255);
            this.BackColor = Color.FromArgb(Red, Green, Blue);
        }


        private void item1_fullScreen(object sender, EventArgs e)//меню
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void item1_Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas oled kindel?", "Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void item1_new(object sender, EventArgs e)//меню
        {
            if (MessageBox.Show("Kas tahad kustutada kõik?", "Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Controls.Clear();
                this.Controls.Add(tree);

            }
        }

        private void Lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = lbox.SelectedItem.ToString();

            if (item == "Sinine")
            {
                lbox.BackColor = Color.Blue;
            }
            if (item == "Kollane")
            {
                lbox.BackColor = Color.Yellow;
            }
            if (item == "Roheline")
            {
                lbox.BackColor = Color.Green;
            }
            if (item == "Punane")
            {
                lbox.BackColor = Color.Red;
            }
        }


        private void radioTab(object sender, EventArgs e)
        {
            tabControl = new TabControl();
            tabControl.Location = new Point(350, 150);
            tabControl.Size = new Size(200, 100);
            page1 = new TabPage("Esimene");
            page1.BackColor = Color.Red;
            page2 = new TabPage("Teine");
            page2.BackColor = Color.Blue;
            page3 = new TabPage("Kolmas");
            page3.BackColor = Color.Yellow;
            tabControl.Controls.Add(page1);
            tabControl.Controls.Add(page2);
            tabControl.Controls.Add(page3);
            this.Controls.Add(tabControl);
            if (a1.Checked)
            {
                this.tabControl.SelectedTab = page1;
            }
            else if (a2.Checked)
            {
                this.tabControl.SelectedTab = page2;
            }
            else if (a3.Checked)
            {
                this.tabControl.SelectedTab = page3;
            }
            a1.Dispose();
            a2.Dispose();
            a3.Dispose();
        }

        private void RadioButton_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}