using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TreeView tree = null;
        ImageList gallery = null;
        ListBox listbox = null;

        public Form1()
        {
            InitializeComponent();

            this.SetBounds (300, 300, 600, 1000);
            tree = new TreeView();
            this.Controls.Add(tree);

            tree.SetBounds(300, 30, 300, 400);

            TreeNode node1 = new TreeNode("Новый узел");
            tree.Nodes.Add(node1);

            try
            {
                gallery = new ImageList();
                tree.ImageList = gallery;
                gallery.ImageSize = new Size(50, 50);

                Bitmap bmp = new Bitmap("image1.bmp");
                gallery.Images.Add(bmp);

                bmp = new Bitmap("images.bmp");
                gallery.Images.Add(bmp);

                node1 = new TreeNode("Изображение", 0, 1);
                tree.Nodes.Add(node1);
                node1 = new TreeNode("Изображение", 1, 0);
                tree.Nodes.Add(node1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            tree.DoubleClick += Tree_DoubleClick;

            listbox = new ListBox();
            listbox.SetBounds(20, 200, 250, 300);
            this.Controls.Add(listbox);

            TreeNode[] treenodes =
            {
                new TreeNode("Iphone 5"),
                new TreeNode("Iphone 6"),
            };

            TreeNode[] treenodes2 =
            {
                new TreeNode("Huawei 5"),
                new TreeNode("Huawei 6"),
            };

            TreeNode apple = new TreeNode("Apple");
            treeView1.Nodes.Add(apple);
            apple.Nodes.AddRange(treenodes);

            TreeNode huawei = new TreeNode("Huawei");
            treeView1.Nodes.Add(huawei);
            huawei.Nodes.AddRange(treenodes2);

            recurce_list(treeView1.Nodes);

        }

        private void recurce_list(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                listbox.Items.Add(node.Text);
                if (node.Nodes.Count<0)
                {
                    recurce_list(node.Nodes);
                }
            }
        }

        private void Tree_DoubleClick(object sender, EventArgs e)
        {
            TreeView tv = sender as TreeView;
            tv.Nodes.Remove(tv.SelectedNode);
        }
    }
}
