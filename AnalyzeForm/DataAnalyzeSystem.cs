using AnalyzeLibrary.file;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace AnalyzeForm
{
    public partial class DataAnalyzeSystem : Form
    {


        public class Info
        {
            public string Id { get; set; }
            public string Name { get; set; }

        }
        public DataAnalyzeSystem()
        {
            InitializeComponent();
        }

        private void protocolManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProtocolManagement pmForm = new ProtocolManagement();
            pmForm.StartPosition = FormStartPosition.CenterParent;
            this.Visible = false;
            pmForm.ShowDialog();
            this.Visible = true;


        }

        private void dataAnalyzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProtocolM pmForm = new ProtocolM();
            pmForm.StartPosition = FormStartPosition.CenterParent;
            this.Visible = false;
            pmForm.ShowDialog();
            this.Visible = true;

        }
        private void closseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void DataAnalyzeSystem_Load(object sender, EventArgs e)
        {
           string [] protocols= DirFileHelper.GetFileNames(System.IO.Directory.GetCurrentDirectory()+@"\resource", "*.xml", true);

            IList<Info> infoList = new List<Info>();
            foreach (string str in protocols)
            {
                Info inf = new Info() { Id = str, Name = DirFileHelper.GetFileNameNoExtension(str) };
                infoList.Add(inf);
            };

            comboBox1.DataSource = infoList;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string sss = folder.SelectedPath;
                textBox1.Text = sss;
                string[] temp = loadFile(sss);
                TreeNode root = new TreeNode();
                root.Text = DirFileHelper.GetFileName(sss);
                root.Tag = sss;
                treeView1.Nodes.Add(root);
                InitTree(sss, root);
                MessageBox.Show(temp.ToString(), "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("已选择文件夹:" + sss, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string sss = folder.SelectedPath;
                textBox2.Text = sss;
                string[] temp = loadFile(sss);
                TreeNode root = new TreeNode();
                root.Text = DirFileHelper.GetFileName(sss);
                root.Tag = sss;
                treeView2.Nodes.Add(root);
                InitTree(sss, root);
                MessageBox.Show("已选择文件夹:" + sss, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void InitTree(string file ,TreeNode node)
        {

            var temp = loadDirectories(file);
            foreach (string fileName in temp)
            {
               var tempNode= AddNode(node, fileName);
                InitTree(fileName, tempNode);
            }
            if (!DirFileHelper.IsEmptyDirectory(file))
            {
                var tempFile = loadFile(file);
                foreach (string fileN in tempFile)
                {
                    AddNode(node, fileN);
                }

            }
        }
        private TreeNode AddNode(TreeNode root  , string fileName)
        {
            
                TreeNode node = new TreeNode();
                node.Text = DirFileHelper.GetFileName(fileName);
                node.Tag = fileName;
                root.Nodes.Add(node);
                return node;
             
            
        }

        private string[] loadFile(string url)
        {
            return DirFileHelper.GetFileNames(url, "*", false);
        }

        private string[] loadDirectories(string url)
        {
            return DirFileHelper.GetDirectories(url, "*", false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
