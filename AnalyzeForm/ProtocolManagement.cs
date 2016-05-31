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
    public partial class ProtocolManagement : Form
    {
        public class Info
        {
            public string Id { get; set; }
            public string Name { get; set; }

        }

        private int frameId = 0;
        public ProtocolManagement()
        {
            InitializeComponent();
        }

        private void ProtocolManagement_Load(object sender, EventArgs e)
        {
            string[] protocols = AnalyzeLibrary.file.DirFileHelper.GetFileNames(System.IO.Directory.GetCurrentDirectory() + @"\resource", "*.xml", true);

            IList<Info> infoList = new List<Info>();
            Info inf1 = new Info()
            {
                Id = "",
                Name = "请选择协议"
            };
            infoList.Add(inf1);
            foreach (string str in protocols)
            {
                Info inf = new Info()
                {
                    Id = str,
                    Name = AnalyzeLibrary.file.DirFileHelper.GetFileNameNoExtension(str)
                };
                infoList.Add(inf);
            };

            comboBox1.DataSource = infoList;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";


            //List<string> nList = new List<string>();
            //nList.Add("January");
            //nList.Add("February");
            //nList.Add("March");
            //nList.Add("April");
            //listBox1.DataSource = nList;





        }
        int _selIndex = -1;
        bool isNew = true;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == _selIndex)
                return;


            if (listBox1.SelectedValue != null && listBox1.SelectedIndex != -1)
            {
                if (isNew && listBox1.SelectedIndex == 0)
                {
                    isNew = false;
                    return;
                }
                ProtocolFrame curItem = (ProtocolFrame)listBox1.SelectedItem;

                textBox1.Text = curItem.FrameId;
                // Find the string in ListBox2.
                // int index = listBox2.FindString(curItem);
                // If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
                //  if (index == -1)
                panel1.Controls.Clear();
                frameId = 0;
                foreach (ProtocolFrameItem item in curItem.FrameItemList)
                {

                    createConttrol(panel1, item);
                }

            }
            _selIndex = listBox1.SelectedIndex;
            // Get the currently selected item in the ListBox.


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void BindGridViewForIList<T>(DataGridView gv, IList<T> datasource)
        {
            BindingList<T> _bindinglist = new BindingList<T>(datasource);
            BindingSource _source = new BindingSource(_bindinglist, null);
            gv.DataSource = _source;
        }

        private void newParameter_Click(object sender, EventArgs e)
        {
            createConttrol(panel1, new ProtocolFrameItem());

        }

        private void createConttrol(Panel panel, ProtocolFrameItem item)
        {
            var y = panel.VerticalScroll.Value;
            int index = frameId++;
            GroupBox gbox = new GroupBox();
            gbox.Text = "参数项（" + index + "）";
            gbox.Name = index.ToString();
            gbox.Height = 88;
            gbox.Width = 500;
            gbox.TabIndex = index;
            gbox.Location = new Point(17, index == 0 ? 20 : 90 * index + 20 - y);

            panel.Controls.Add(gbox);
            createText(gbox, "参数名称:", item.Name, "param", 0, 0);
            createText(gbox, "  起始位:", item.Start.ToString(), "start", 165, 0);
            createText(gbox, "    长度:", item.Length.ToString(), "length", 165 * 2, 0);
            createText(gbox, "  分辨率:", item.Resolution.ToString(), "pixel", 0, 32);
            createText(gbox, "  偏移量:", item.Offset.ToString(), "offset", 165, 32);
            if(item.Unit!=null)
            {
                createText(gbox, "  单位:", item.Unit.ToString(), "unit", 165 * 2, 32);
            }
          
        }

        private void createText(GroupBox gb, string name, string value, string id, int preW, int preH)
        {
            Label tempLabel = new Label();
            tempLabel.Text = name;
            tempLabel.Name = gb.Name + "label" + id;
            tempLabel.Location = new Point(preW + 3, preH + 22);
            tempLabel.Size = new Size(60, 17);
            gb.Controls.Add(tempLabel);
            TextBox tempText = new TextBox();
            tempText.Text = value;
            tempText.Name = gb.Name + "text_" + id;
            tempText.Location = new Point(preW + 65, preH + 17);
            tempText.Size = new Size(100, 21);
            tempText.BringToFront();
            gb.Controls.Add(tempText);

        }

        Protocol pro1;
        BindingList<ProtocolFrame> frameList;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selIndex = -1;
            initListbox(true);


        }

        private void initListbox(bool isClear)
        {
            var curItem = (Info)comboBox1.SelectedItem;
            if (isClear)
            {
                textBox1.Text = "";
                panel1.Controls.Clear();

            }
            frameId = 0;
            if (curItem.Id != "")
            {

                string url = curItem.Id;
                string str = DirFileHelper.GetFileStr(url);
                pro1 = (Protocol)XmlUtil.Deserialize(typeof(Protocol), str);
                pro1.Url = url;
                frameList = new System.ComponentModel.BindingList<ProtocolFrame>(pro1.FrameList);

                listBox1.DataSource = frameList;
                listBox1.ValueMember = "FrameId";
                listBox1.DisplayMember = "FrameId";
                //if (listBox1.Items.Count > 0)
                //{


                //    listBox1.ClearSelected();


                //    listBox1.SelectedIndex = _selIndex;
                //}
            }
        }
        //保持帧
        private void button4_Click(object sender, EventArgs e)
        {
            ProtocolFrame curItem = (ProtocolFrame)listBox1.SelectedItem;
            curItem.FrameId = textBox1.Text;
            curItem.FrameItemList.Clear();
            foreach (Control c in panel1.Controls)
            {

                ProtocolFrameItem item = new ProtocolFrameItem();
                foreach (Control cc in c.Controls)
                {
                    if (cc is TextBox)
                    {
                        var tempName = cc.Name.Substring(cc.Name.LastIndexOf('_')
                            + 1);
                       
                        string value = ((TextBox)cc).Text;

                        switch (tempName)
                        {
                            case "param":
                                item.Name = value;
                                break;
                            case "start":
                                item.Start = int.Parse(value);
                                break;
                            case "length":
                                item.Length = int.Parse(value);
                                break;
                            case "pixel":
                                item.Resolution = float.Parse(value);
                                break;
                            case "offset":
                                item.Offset = int.Parse(value);
                                break;
                            case "unit":
                                item.Unit = value;
                                break;

                        }
                        

                    }
                }
                if(item.Name!="")
                { 
                curItem.FrameItemList.Add(item);
                }
            }

            pro1.saveFile();
            ; string temp = textBox1.Text;
            initListbox(false);
            listBox1.SelectedValue = temp;
            MessageBox.Show("协议帧保存成功！");


        }
        //新增帧
        private void button3_Click(object sender, EventArgs e)
        {
            if (frameList != null)
            {
              


            ProtocolFrame frame = new ProtocolFrame();
                frame.FrameId = "test";
                frameList.Add(frame);
                pro1.saveFile();
                MessageBox.Show("新增协议帧成功 ！");
            }
            else {
                MessageBox.Show("请选择协议");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProtocolFrame curItem = (ProtocolFrame)listBox1.SelectedItem;
            frameList.Remove(curItem);
            pro1.saveFile();
            MessageBox.Show("删除协议帧成功 ！");

        }
    }

    public struct SelfRun
    {
        public SelfRun(string name, string description)
        : this()
        {
            ProtocolName = name;
            protocolDescription = description;

        }
        private string protocolName;
        private string protocolDescription;


        public string ProtocolName
        {
            get
            {
                return protocolName;
            }

            set
            {
                protocolName = value;
            }
        }

        public string ProtocolDescription
        {
            get
            {
                return protocolDescription;
            }
            set
            {
                protocolDescription = value;
            }
        }
    }
}


