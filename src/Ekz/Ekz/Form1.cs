using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ekz
{
    public partial class Form1 : Form
    {
        string curFile;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Html files(*.html)|*.html|All files(*.*)|*.*";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                  "Программу разработал:\n Студент группы ПКсп-119\n Калинин Андрей Алексеевич\n Вариант 11.",
                  "О программе",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.None,
                  MessageBoxDefaultButton.Button3);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.AllowWebBrowserDrop = false;
            openFileDialog1.ShowDialog();
            string[] repSplit = openFileDialog1.FileName.Split('\\');
            curFile = repSplit[repSplit.Length - 1];
            webBrowser1.Navigate(openFileDialog1.FileName);

            if (curFile == "var1.html"|| curFile == "var2.html")
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                MessageBox.Show(
                 "Для данного файла не предусмотрено решение.\n Откройте файл var1.html или var2.html",
                 "Ошибка",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button3);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 formRez = new Form2();
                double x = Convert.ToDouble(textBox1.Text), y = Convert.ToDouble(textBox2.Text);
                if (curFile == "var1.html")
                {
                    if (y <= 1 && y >= -1 && x >= -1 && x <= 0 || x > 0 && Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(1, 2))
                    {
                        if (y < 1 && y > -1 && x > -1 && x <= 0 || x >= 0 && Math.Pow(x, 2) + Math.Pow(y, 2) < Math.Pow(1, 2))
                        {
                            formRez.Show();
                            formRez.resultSet("Точка находится внутри фигуры");
                        }
                        else
                        {
                            formRez.Show();
                            formRez.resultSet("Точка находится на границе фигуры");
                        }
                    }
                    else
                    {
                        formRez.Show();
                        formRez.resultSet("Точка находится вне фигуры");

                    }
                }
                
                else if (curFile == "var2.html")
                {
                    if (y <= 4 && y >= -4 && x >= -5 && x <= 5 && ((x >= 1 && y <= -2 * x + 6) || (y <= 0 && y <= (-x - 35) / 10) || (x <= 1 && y <= (7 * x + 17) / 6)))
                    {
                        if (y < 4 && y > -4 && x > -5 && x <= 5 && ((x >= 1 && y < -2 * x + 6) || (y <= 0 && y < (-x - 35) / 10) || (x <= 1 && y < (7 * x + 17) / 6)))
                        {
                            formRez.Show();
                            formRez.resultSet("Точка находится внутри фигуры");
                        }
                        else
                        {
                            formRez.Show();
                            formRez.resultSet("Точка находится на границе фигуры");

                        }
                    }
                    else
                    {
                        formRez.Show();
                        formRez.resultSet("Точка находится вне фигуры");
                    }
                }
                else
                {
                    MessageBox.Show(
                     "Для данного файла не предусмотрено решение.\n Откройте файл var1.html или var2.html",
                     "Ошибка",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button3);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(
                 $"Похоже вы ввели не число. {exp}",
                 "Ошибка",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button3);
            }
        }
    }
}
