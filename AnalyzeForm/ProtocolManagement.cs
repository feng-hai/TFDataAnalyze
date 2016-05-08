using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalyzeForm
{
    public partial class ProtocolManagement : Form
    {
        public ProtocolManagement()
        {
            InitializeComponent();
        }

        private void ProtocolManagement_Load(object sender, EventArgs e)
        {
           



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void BindGridViewForIList<T>(DataGridView gv, IList<T> datasource)
        {
            BindingList<T> _bindinglist = new BindingList<T>(datasource);
            BindingSource _source = new BindingSource(_bindinglist,null);
            gv.DataSource = _source;
        }

        private void newParameter_Click(object sender, EventArgs e)
        {
            for(int i=0;i<10;i++)
            {
                createConttrol(panel1,i);
            }
       
        }

        private void createConttrol(Panel panel,int index)
        {
            GroupBox gbox = new GroupBox();

            gbox.Text = "参数项（"+index+"）";
            gbox.Top =index*90;
            gbox.Name = index.ToString();
            gbox.Height = 88;
            gbox.Width = 500;
            gbox.TabIndex =index;
            gbox.Location = new Point(12,90 * index);
       
            panel.Controls.Add(gbox);
            createText(gbox, "参数名称:", "test","param",0,0);
            createText(gbox, "  起始位:", "test", "start", 165,0);
            createText(gbox, "    长度:", "test", "length", 165*2,0);
            createText(gbox, "  分辨率:", "test", "pixel", 0,32);
            createText(gbox, "  偏移量:", "test", "offset", 165,32);
        }

        private void createText(GroupBox gb, string name, string value,string id,int preW,int preH)
        {
            Label tempLabel = new Label();
            tempLabel.Text = name;
            tempLabel.Name = gb.Name+"label" + id;
            tempLabel.Location = new Point(preW + 3, preH+22);
            tempLabel.Size = new Size(60, 17);
            gb.Controls.Add(tempLabel);
            TextBox tempText = new TextBox();
            tempText.Text = value;
            tempText.Name =gb.Name+ "text" + id;
            tempText.Location = new Point(preW + 65, preH+17);
            tempText.Size = new Size(100, 21);
            tempText.BringToFront();
            gb.Controls.Add(tempText);

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
            }            set
            {
                protocolDescription = value;
            }
        }
    }
}


