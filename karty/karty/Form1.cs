using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace karty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Baza_danych.ZaladujDaneBazy("pracownicy", " ", dataGridView1);
            Baza_danych.ZaladujDaneBazy("karty", " ", dataGridView2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor != DefaultBackColor) button4.BackColor = DefaultBackColor;
            else  button4.BackColor = Color.GreenYellow;

        }
    }
}
