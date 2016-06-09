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

        public DataFrame(string data, DateTime startDate)
        {
            this.orgStr = data;
            this.currentTime = startDate;
            this.formate();
        }
        private string orgStr;
        private string startDate;
        private int frameNo;
        private string frameId;
        private string frameContent;
        private string code;
        private string name;
        private uint rowNo;

        private DateTime currentTime;

        private bool isYes = false;




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

        public bool IsYes
        {
            get
            {
                return isYes;
            }

            set
            {
                isYes = value;
            }
        }

        public uint RowNo
        {
            get
            {
                return rowNo;
            }

            set
            {
                rowNo = value;
            }
        }

        public void formate()
        {
            DateTime dt = currentTime;
            if (this.orgStr.Length == 38)
            {


                string no = this.orgStr.Substring(0, 8);
                byte[] tempNO = ByteUtil.strToToHexByte(no);
                Array.Reverse(tempNO);
                string noResult = ByteUtil.byteToHexStr(tempNO);
                this.FrameNo = Int32.Parse(noResult, System.Globalization.NumberStyles.HexNumber);
                string msStr = this.orgStr.Substring(8, 4);
                byte[] tempMs = ByteUtil.strToToHexByte(msStr);
                Array.Reverse(tempMs);
                string rTempMs = ByteUtil.byteToHexStr(tempMs);
                int ms = Int16.Parse(rTempMs, System.Globalization.NumberStyles.HexNumber);
                dt = dt.AddMilliseconds(ms);
                this.CurrentTime = dt;
                this.StartDate = dt.ToString("HH:mm:ss");
                string frameId = this.orgStr.Substring(12, 8).ToUpper();
                byte[] temp = ByteUtil.strToToHexByte(frameId);
                Array.Reverse(temp);
                string rTemp = ByteUtil.byteToHexStr(temp);
                this.FrameId = rTemp;
                string content = this.orgStr.Substring(20, 16);
                content.Replace("7D02", "7E");
                content.Replace("7D01", "7D");
                var checkCode = this.orgStr.Substring(0, 36);
                string resutlStr = CRC16.CRC16String(checkCode);
                this.FrameContent = this.orgStr.Substring(20, 16);
                byte[] tempContent = ByteUtil.strToToHexByte(this.FrameContent);
                Array.Reverse(tempContent);
                this.frameContent = ByteUtil.byteToHexStr(tempContent);
                this.code = this.orgStr.Substring(36, 2);
                if (resutlStr.ToUpper() == this.code)
                {
                    this.IsYes = true;
                }
            }
        }



    }
}
