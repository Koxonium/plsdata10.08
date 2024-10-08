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
            db = new databaseHandler();
            db.ReadDB();
            db.deleteOne(food.prodlist[1]);
        }
    }
}
