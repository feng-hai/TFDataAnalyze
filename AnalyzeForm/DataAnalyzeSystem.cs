using AnalyzeLibrary.file;
using AnalyzeLibrary.protocol;
using AnalyzeLibrary.result;
using AnalyzeLibrary.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            LoadProtocol();

        }

        private void LoadProtocol()
        {
            string[] protocols = DirFileHelper.GetFileNames(System.IO.Directory.GetCurrentDirectory() + @"\resource", "*.xml", true);

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
                treeView1.Nodes.Clear();
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

        private void LoadResultFile()
        {
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

            string protocolUrl = null;
            if (comboBox1.SelectedItem != null)
            {
                var curItem = (Info)comboBox1.SelectedItem;
                protocolUrl = curItem.Id;
            }
            if (protocolUrl == null)
            {
                MessageBox.Show("请选择协议");
                return;
            }


            analyzeData.Enabled = false;
            analyzeData.Text = "解析中...";


            string extension = ConfigurationManager.AppSettings["fileExtension"];
            string[] test = DirFileHelper.GetFileNames(textBox1.Text,  "*."+ extension, true);
            // string[] protocols = AnalyzeLibrary.file.DirFileHelper.GetFileNames(protocolUrl, true);
            string str = DirFileHelper.GetFileStr(protocolUrl);

            string timeSpanInt = timeSpan.Text;
            int spanTime = 0;
            if (!int.TryParse(timeSpanInt, out spanTime))
            {
                spanTime = 20;
            }

            ManualResetEvent eventX = new ManualResetEvent(false);
            ThreadPool.SetMaxThreads(6, 3);

            ThreadFile tf = new ThreadFile(0,test.Length, eventX);

            foreach (string dataP in test)
            {

                Parameter p = new Parameter(dataP, str, spanTime, textBox2.Text);
                ThreadPool.QueueUserWorkItem(new WaitCallback(tf.ThreadProc), p);


                //DataFrames data = new DataFrames(dataP, str, spanTime);
                //data.GetData();
                //data.DataToArray();

                //DateTime dt = Convert.ToDateTime(data.formateDate());
                //if (data.ValueList.Count > 0)
                //{
                //    List<string[]> tempList = data.ValueList;
                //    CSVUtil.dt2csvForList(tempList, textBox2.Text + "/" + dt.ToString("yyyyMMddHHmmss") + @".CSV", "", string.Join(", ", data.Header.ToArray()));
                //    CSVUtil.GenerateWorkSheetWithSB(tempList, textBox2.Text + "/" + dt.ToString("yyyyMMddHHmmss") + @".xls", "", string.Join(", ", data.Header.ToArray()));
                //    LoadResultFile();
                //}

            }




          
            //等待事件的完成，即线程调用ManualResetEvent.Set()方法
            //eventX.WaitOne  阻止当前线程，直到当前 WaitHandle 收到信号为止。 
            eventX.WaitOne(Timeout.Infinite, true);
            LoadResultFile();
            //Console.WriteLine("断点测试");
            //Thread.Sleep(10000);
            //Console.WriteLine("运行结束");



                
               


            analyzeData.Enabled = true;
            analyzeData.Text = "数据解析";

            MessageBox.Show("数据解析完成");

        }

        private void InitTree(string file, TreeNode node)
        {

            var temp = loadDirectories(file);
            foreach (string fileName in temp)
            {
                var tempNode = AddNode(node, fileName);
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
        private TreeNode AddNode(TreeNode root, string fileName)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadProtocol();
        }
    }
}
