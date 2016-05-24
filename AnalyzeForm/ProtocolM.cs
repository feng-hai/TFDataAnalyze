using AnalyzeLibrary.file;
using AnalyzeLibrary.protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using static AnalyzeForm.DataAnalyzeSystem;

namespace AnalyzeForm
{
    public partial class ProtocolM : Form
    {
        public ProtocolM()
        {
            InitializeComponent();
        }
        BindingList<Protocol> protocolList;
        private void ProtocolM_Load(object sender, EventArgs e)
        {
            initProtocol();
        }
        private void initProtocol() {


            string[] protocols = AnalyzeLibrary.file.DirFileHelper.GetFileNames(System.IO.Directory.GetCurrentDirectory() + @"\resource", "*.xml", true);

            IList<Protocol> infoList = new List<Protocol>();

            foreach (string str in protocols)
            {
                Protocol inf = (Protocol)AnalyzeLibrary.Util.XmlUtil.Deserialize(typeof(Protocol), DirFileHelper.GetFileStr(str)); ;

                infoList.Add(inf);
            };
            protocolList = new BindingList<Protocol>(infoList);

            listBox1.DataSource = protocolList;
            listBox1.ValueMember = "Url";
            listBox1.DisplayMember = "Name";
        }


        int _selIndex = -1;
        Protocol pro;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == _selIndex)
                return;

            pro = (Protocol)listBox1.SelectedItem;

            textBox1.Text = pro.Name;
            textBox2.Text = pro.Description;


            _selIndex = listBox1.SelectedIndex;
        }
        /// <summary>
        /// 修改协议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            pro.Name = textBox1.Text;
            pro.Description = textBox2.Text;
            var oldName = AnalyzeLibrary.file.DirFileHelper.GetFileNameNoExtension(pro.Url);
            if (oldName != pro.Name)
            {
                pro.DeleteFile();
                pro.Url = System.IO.Directory.GetCurrentDirectory() + @"\resource\" + pro.Name + ".xml";
            }
            pro.saveFile();

            int temp = _selIndex;
            initProtocol();
            listBox1.SelectedIndex = temp;
            MessageBox.Show("保存协议成功");
        }
        /// <summary>
        /// 新增协议
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Protocol pro1 = new Protocol(System.IO.Directory.GetCurrentDirectory() + @"\resource\" + "test01.xml");
            pro1.Name = "test01";
            protocolList.Add(pro1);
            pro1.saveFile();
            MessageBox.Show("新增协议成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pro = (Protocol)listBox1.SelectedItem;
            protocolList.Remove(pro);
            pro.DeleteFile();
            MessageBox.Show("删除协议成功");
        }
    }
}
