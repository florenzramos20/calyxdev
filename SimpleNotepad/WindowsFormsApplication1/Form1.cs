using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        OpenFileDialog theDialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            lblNumLines.Text ="Line:"+textBox1.Lines.Count();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] lines = textBox1.Lines;
            lblNumLines.Text ="Line:"+ lines.Count();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            isOpen = false;

        }
        bool isOpen = false;
        private void btnOpen_Click(object sender, EventArgs e)
        {
      
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(theDialog.FileName.ToString());
                textBox1.Lines = lines;
                lblNumLines.Text = "Line:" + lines.Count();
                isOpen = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (isOpen)
            {
                File.WriteAllText(theDialog.FileName.ToString(), String.Empty);
                string[] linesfromText = textBox1.Text.Split('\n');
                File.WriteAllLines(theDialog.FileName.ToString(), linesfromText);
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.InitialDirectory = @"C:\";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string[] contents = textBox1.Text.ToString().Split('\n');
                    File.WriteAllLines(saveFileDialog1.FileName.ToString(), contents);
                }
            }
            


           

        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString()!=String.Empty)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
               saveFileDialog1.InitialDirectory = @"C:\";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string[] contents = textBox1.Text.ToString().Split('\n');
                    File.WriteAllLines(saveFileDialog1.FileName.ToString(),contents);
                }
            }
        }
    }
}
