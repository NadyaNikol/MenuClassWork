using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        ImageList list = null;
        ToolBar toolbar = null;

        public string Path { set; get; } = "";
        public Form1()
        {
            InitializeComponent();

            list = new ImageList();
            list.ImageSize = new Size(40, 40);
            list.Images.Add(new Bitmap("file.bmp"));
            list.Images.Add(new Bitmap("cut.bmp"));
            list.Images.Add(new Bitmap("paste.bmp"));

            toolbar = new ToolBar();
            toolbar.Appearance = ToolBarAppearance.Flat;
            toolbar.BorderStyle = BorderStyle.Fixed3D;

            toolbar.ImageList = list;
            toolbar.Location = new Point(this.Location.X, this.Location.Y);
            ToolBarButton toolBarButton1 = new ToolBarButton();
            toolBarButton1.Tag = "file";
            ToolBarButton toolBarButton2 = new ToolBarButton();
            toolBarButton2.Tag = "cut";
            ToolBarButton toolBarButton3 = new ToolBarButton();
            toolBarButton3.Tag = "paste";

            toolBarButton1.ImageIndex = 0;
            toolBarButton2.ImageIndex = 1;
            toolBarButton3.ImageIndex = 2;

            toolbar.Buttons.Add(toolBarButton1);
            toolbar.Buttons.Add(toolBarButton2);
            toolbar.Buttons.Add(toolBarButton3);

            this.Controls.Add(toolbar);


            toolbar.ButtonClick += Toolbar_ButtonClick;            


        }

        private void Toolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag)
            {

                case "file":
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            txtbDocument.Text = File.ReadAllText(openFileDialog.FileName);
                        }

                        txtbDocument.ReadOnly = false;
                        txtbDocument.Enabled = true;
                        сохранитьКакToolStripMenuItem.Enabled = true;

                        break;
                    }


                case "cut":
                    {
                        txtbDocument.Cut();
                        break;
                    }

                case "paste":
                    {
                        txtbDocument.Paste();
                        break;
                    }


                default:
                    break;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtbDocument.Text = File.ReadAllText(openFileDialog.FileName);

            txtbDocument.Enabled = true;
            сохранитьКакToolStripMenuItem.Enabled = true;

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Path))
            File.WriteAllText(Path, txtbDocument.Text);
        }



        private void новыйДокументToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtbDocument.Clear();
            txtbDocument.Enabled = true;
            сохранитьКакToolStripMenuItem.Enabled = true;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "(*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                this.Path = saveFileDialog.FileName;
                File.WriteAllText(saveFileDialog.FileName, txtbDocument.Text);
                сохранитьToolStripMenuItem.Enabled = true;
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbDocument.Text))
            {
                txtbDocument.Copy();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbDocument.Text))
            {
                txtbDocument.Cut();
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbDocument.Text))
            {
                txtbDocument.Paste();
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtbDocument.Text))
            {
                txtbDocument.Undo();
            }
        }

        private void изменитьЦветToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txtbDocument.Font = fontDialog.Font;

                if (fontDialog.ShowColor == true)
                {
                    txtbDocument.ForeColor = fontDialog.Color;
                }
            }
        }

        private void изменитьЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog.Color;
            }
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtbDocument.SelectAll();
        }
    }
}
