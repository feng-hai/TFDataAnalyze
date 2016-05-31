using AnalyzeLibrary.file;
using AnalyzeLibrary.protocol;
using AnalyzeLibrary.Util;
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
               // MessageBox.Show(temp.ToString(), "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("已选择文件夹:" + sss, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string sss = folder.SelectedPath;
                if (string.IsNullOrEmpty(sss))
                {
                    MessageBox.Show("请选择解析后文件存放位置");
                    return;
                }
                textBox2.Text = sss;

                LoadResultFile();
                //string[] temp = loadFile(sss);
                //TreeNode root = new TreeNode();
                //root.Text = DirFileHelper.GetFileName(sss);
                //root.Tag = sss;
                //treeView2.Nodes.Clear();
                //treeView2.Nodes.Add(root);
                //InitTree(sss, root);
                //MessageBox.Show("已选择文件夹:" + sss, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadResultFile() {
            string sss = textBox2.Text;
            string[] temp = loadFile(sss);
            TreeNode root = new TreeNode();
            root.Text = DirFileHelper.GetFileName(sss);
            root.Tag = sss;
            treeView2.Nodes.Clear();
            treeView2.Nodes.Add(root);
            InitTree(sss, root);
          //  MessageBox.Show("已选择文件夹:" + sss, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择原始数据");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("请选择解析文本保存路径");
                return;
            }
            analyzeData.Enabled = false;
            label4.Text = "解析中...";
          
            string[] test = DirFileHelper.GetFileNames(textBox1.Text, "*.TXT", true);
            string[] protocols = AnalyzeLibrary.file.DirFileHelper.GetFileNames(System.IO.Directory.GetCurrentDirectory() + @"\resource", "test.xml", true);

            foreach(string strP in protocols)
            {
                string str = DirFileHelper.GetFileStr(strP);
                foreach(string dataP in test)
                {
                    DataFrames data = new DataFrames(dataP, str);
                    data.GetData();
                    data.DataToArray();

                   DateTime dt= Convert.ToDateTime(data.formateDate());
                    if(data.ValueList.Count>0)
                    {
                        List<string[]> tempList = data.ValueList;
                        CSVUtil.dt2csvForList(tempList, textBox2.Text +"/"+dt.ToString("yyyyMMddHHmmss")+ @".csv", "test", string.Join(", ", data.Header.ToArray()));
                        LoadResultFile();
                    }
                   
                }
              

            }

            analyzeData.Enabled = true;
            label4.Text = "解析完成";


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
