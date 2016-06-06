using AnalyzeLibrary.file;
using AnalyzeLibrary.protocol;
using AnalyzeLibrary.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AnalyzeLibrary.protocol
{
    public class DataFrames
    {
        public DataFrames(string dataPath, string protocolPath)
        {
            this.dataPath = dataPath;
            this.protocolPath = protocolPath;
            FrameHeader();
        }
        List<string> header = new List<string>();
        List<string[]> valueList = new List<string[]>();
        private string dataPath;
        private string protocolPath;

       

        private List<DataFrame> listFrame = new List<DataFrame>();

        public List<DataFrame> ListFrame
        {
            get
            {
                return listFrame;
            }

            set
            {
                listFrame = value;
            }
        }

        public List<string> Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }
        }

        public List<string[]> ValueList
        {
            get
            {
                return valueList;
            }

            set
            {
                this.valueList = value;
            }
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <returns></returns>
        public  string formateDate()
        {
            StringBuilder sb = new StringBuilder();
            string name= DirFileHelper.GetFileNameNoExtension(this.dataPath);
            string [] dateArray=this.dataPath.Split('\\');
            sb.Append(dateArray[dateArray.Length - 4]);
            sb.Append("-");
            sb.Append(dateArray[dateArray.Length - 3]);
            sb.Append("-");
            sb.Append(dateArray[dateArray.Length - 2]);
            sb.Append(" ");
            sb.Append(name.Substring(0, 2));
            sb.Append(":");
            sb.Append(name.Substring(2, 2));
            sb.Append(":");
            sb.Append(name.Substring(4, 2));
            return sb.ToString();

        }

        /// <summary>
        /// 分析帧对应的数据
        /// </summary>
        private void analyzeFrame(DataFrame df)
        {
            Protocol pro1 = (Protocol)XmlUtil.Deserialize(typeof(Protocol), this.protocolPath);
            pro1.Url = this.protocolPath;
            //  System.ComponentModel.BindingList<ProtocolFrame> frameList = new System.ComponentModel.BindingList<ProtocolFrame>(pro1.FrameList);

       

            ProtocolFrame frame = this.FindFrame(pro1.FrameList, df.FrameId);
            if (frame != null)
            {

                foreach (ProtocolFrameItem item in frame.FrameItemList)
                {
                    string temp = df.FrameContent.Substring(item.Start, item.Length);
                    item.Value = Int32.Parse(temp, System.Globalization.NumberStyles.HexNumber) * item.Resolution + item.Offset;
                    df.ItemList.Add(item);
                }

            }

        }

        private void FrameHeader()
        {

            Protocol pro1 = (Protocol)XmlUtil.Deserialize(typeof(Protocol), this.protocolPath);
            pro1.Url = this.protocolPath;
            //  System.ComponentModel.BindingList<ProtocolFrame> frameList = new System.ComponentModel.BindingList<ProtocolFrame>(pro1.FrameList);

            this.Header.Add("数据时间");
            foreach (ProtocolFrame frame in pro1.FrameList)
            {
                foreach (ProtocolFrameItem item in frame.FrameItemList)
                {
                    if(item.Name!="")
                    {
                    this.Header.Add(item.Name);
                    }
                }
            }

        }
        /// <summary>
        /// 根据帧Id查询帧定义
        /// </summary>
        /// <param name="frameList">协议包含帧列表</param>
        /// <param name="frameId">帧Id</param>
        /// <returns></returns>
        private ProtocolFrame FindFrame(List<ProtocolFrame> frameList, string frameId)
        {
            foreach (ProtocolFrame item in frameList)
            {
                if (item.FrameId == frameId)
                {
                    return item;

                }
            }

            return null;
        }


        public void GetData()
        {
            FileStream fs = null;
            BinaryReader br = null;

            try
            {
                fs = new FileStream(this.dataPath, FileMode.Open, FileAccess.Read);
                // StreamReader sr = new StreamReader(fs, Encoding.Default);
                br = new BinaryReader(fs);

                byte[] start = br.ReadBytes((int)br.BaseStream.Length);
                string temp = ByteUtil.byteToHexStr(start);
                string[] tampArray = Regex.Split(temp, "7E7E", RegexOptions.IgnoreCase);
               var fileDate= Convert.ToDateTime(formateDate());
                foreach (string str in tampArray)
                {
                    string tempStr = str.Replace("7E", "");
                    DataFrame df = new DataFrame(tempStr, fileDate);
                    fileDate=  df.CurrentTime;
                    analyzeFrame(df);
                    if(df.IsYes)
                    {
                        listFrame.Add(df);
                    }
                  
                }



            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }

                if (br != null)
                {
                    br.Close();
                }


            }


        }
        /// <summary>
        /// 根据解析出的数据格式化数组
        /// </summary>
        public void DataToArray()
        {
            Dictionary<int, string[]> test = new Dictionary<int, string[]>();
            foreach (DataFrame frame in this.ListFrame)
            {
                string[] tempFrame=null;
                if (!test.ContainsKey(frame.FrameNo))
                {
                    if(frame.ItemList.Count>0)
                    {
                        tempFrame = new string[this.Header.Count];
                        tempFrame[0] = frame.StartDate;
                        test.Add(frame.FrameNo, tempFrame);

                    }
                }
                else {
                    tempFrame = test[frame.FrameNo];
                }
              
                foreach (ProtocolFrameItem item in frame.ItemList)
                {

                   
                    int index = this.header.IndexOf(item.Name);
                    tempFrame[index] = item.Value.ToString();
                }
            }

            foreach (var item in test)
            {
                this.ValueList.Add(item.Value); 
            }
        }


    }
}
