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
        public Form1()
        {
            InitializeComponent();

            list = new ImageList();
            list.ImageSize = new Size(40, 40);
            list.Images.Add(new Bitmap("file.bmp"));
            list.Images.Add(new Bitmap("change.bmp"));
            list.Images.Add(new Bitmap("setting.bmp"));

            toolbar = new ToolBar();
            toolbar.Appearance = ToolBarAppearance.Flat;
            toolbar.BorderStyle = BorderStyle.Fixed3D;

            toolbar.ImageList = list;
            toolbar.Location = new Point(this.Location.X, this.Location.Y);
            ToolBarButton toolBarButton1 = new ToolBarButton();
            toolBarButton1.Tag = "file";
            ToolBarButton toolBarButton2 = new ToolBarButton();
            toolBarButton2.Tag = "change";
            ToolBarButton toolBarButton3 = new ToolBarButton();
            toolBarButton3.Tag = "setting";

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
            switch (e.Button)
            {


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
        }
    }
}
