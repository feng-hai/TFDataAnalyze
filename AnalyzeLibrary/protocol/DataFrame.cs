using AnalyzeLibrary.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace AnalyzeLibrary.protocol
{
    public class DataFrame
    {

        public DataFrame(string data,DateTime startDate)
        {
            this.orgStr = data;
            this.currentTime=startDate;
            this.formate();
        }
        private string orgStr;
        private string startDate;
        private int frameNo;
        private string frameId;
        private string frameContent;
        private string code;
        private string name;

        private DateTime currentTime;
       

      

        private List<ProtocolFrameItem> itemList = new List<ProtocolFrameItem>();

        public string StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public int FrameNo
        {
            get
            {
                return frameNo;
            }

            set
            {
                frameNo = value;
            }
        }

        public string FrameId
        {
            get
            {
                return frameId;
            }

            set
            {
                frameId = value;
            }
        }

        public string FrameContent
        {
            get
            {
                return frameContent;
            }

            set
            {
                frameContent = value;
            }
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public List<ProtocolFrameItem> ItemList
        {
            get
            {
                return itemList;
            }

            set
            {
                itemList = value;
            }
        }

        public DateTime CurrentTime
        {
            get
            {
                return currentTime;
            }

            set
            {
                currentTime = value;
            }
        }

        public void formate()
        {
            DateTime dt = currentTime;
            string no = this.orgStr.Substring(0, 8);
            this.FrameNo = Int32.Parse(no, System.Globalization.NumberStyles.HexNumber); ;
            string msStr = this.orgStr.Substring(8, 4);
            int ms = Int16.Parse(msStr, System.Globalization.NumberStyles.HexNumber);
           dt= dt.AddMilliseconds(ms);
            this.CurrentTime = dt;
            this.StartDate = dt.ToString("HH:mm:ss");
            string frameId = this.orgStr.Substring(12, 8).ToUpper();
            byte[] temp = ByteUtil.strToToHexByte(frameId);
            Array.Reverse(temp);
            string rTemp = ByteUtil.byteToHexStr(temp);
            this.FrameId = rTemp;
            this.FrameContent = this.orgStr.Substring(20, 16);
            this.code = this.orgStr.Substring(36, 2);
        }



    }
}
