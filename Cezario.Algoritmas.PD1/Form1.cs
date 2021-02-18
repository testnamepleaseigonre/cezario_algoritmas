using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cezario.Algoritmas.PD1
{
    public partial class Form1 : Form
    {
        private int symbolsCount = 128;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                checkIfDataValid(poslinkisTextBox.Text.ToString(), tekstasTextBox.Text.ToString());
                tekstoSifravimas(int.Parse(poslinkisTextBox.Text.ToString()), tekstasTextBox.Text.ToString()) ;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void checkIfDataValid(string poslinkis, string tekstas)
        {
            if (string.IsNullOrEmpty(poslinkis) || string.IsNullOrEmpty(tekstas))
                throw new Exception("Užpildykite laukus!");
            try
            {
                int.Parse(poslinkis);
            }
            catch
            {
                throw new Exception("Poslinkis turi buti skaiciumi!");
            }
            if(int.Parse(poslinkis) < 1 || int.Parse(poslinkis) > 127)
                throw new Exception("Poslinkis turi buti skaiciumi (1-127)!");
        }

        private void tekstoSifravimas(int poslinkis, string tekstas)
        {
            string uzsifruotasTekstas = null;
            List<int> textIntList = getTextIntList(tekstas);
            for (int i = 0; i < tekstas.Length; i++)
            {
                uzsifruotasTekstas += (char)((textIntList[i] + poslinkis) % symbolsCount);
            }
            uzsifruotasTextBox.Text = uzsifruotasTekstas;
        }

        private void tekstoDesifravimas(int poslinkis, string tekstas)
        {
            string desifruotasTekstas = null;
            List<int> textIntList = getTextIntList(tekstas);
            for (int i = 0; i < tekstas.Length; i++)
            {
                desifruotasTekstas += (char)(((textIntList[i] - poslinkis) + symbolsCount) % symbolsCount);
            }
            uzsifruotasTextBox2.Text = desifruotasTekstas;
        }

        private List<int> getTextIntList(string tekstas)
        {
            List<int> returnList = new List<int>();
            foreach (char ch in tekstas)
            {
                returnList.Add(ch);
            }
            return returnList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                checkIfDataValid(poslinkisTextBox2.Text.ToString(), tekstasTextBox2.Text.ToString());
                tekstoDesifravimas(int.Parse(poslinkisTextBox2.Text.ToString()), tekstasTextBox2.Text.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
