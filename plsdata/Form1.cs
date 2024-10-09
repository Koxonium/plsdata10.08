using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plsdata
{
    public partial class Form1 : Form
    {
        databaseHandler db;
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        void Start()
        {
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.ForeColor = Color.FromArgb(15,220,110);

            db = new databaseHandler();
            readInfo();

            AddButton.Click += addOne;
            RemoveButton.Click += deleteOneButton;
            RemoveAllButton.Click += deleteAllButtonClick;

        }


        void addOne(object s, EventArgs e)    //fönt a gombnál elég a += így, a gombnak kell egy object megy egy event <---
        {
            try
            {
                food oneFood = new food();
                oneFood.name = guna2TextBox1.Text;
                oneFood.quantity = int.Parse(guna2TextBox2.Text);
                db.insertOne(oneFood);
                readInfo();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        void deleteOneButton(object s, EventArgs e)
        {
            int temp = listBox1.SelectedIndex;
            if (temp < 0){
                return;
            }
            db.deleteOne(food.prodlist[temp]);
            food.prodlist.RemoveAt(temp);
            readInfo();
        }

        void deleteAllButtonClick(object s, EventArgs e)
        {
            db.deleteAll();
            readInfo();
        }

        void readInfo()
        {
            listBox1.Items.Clear();
            db.ReadDB();
            foreach (food item in food.prodlist)
            {
                listBox1.Items.Add($"Termék: {item.name}, Ár: {item.quantity}");
            }
        }
    }
}
