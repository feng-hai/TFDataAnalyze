using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeLibrary.protocol
{
  public   class ProtocolFrame
    {

        private string frameId;
        private List<ProtocolFrameItem> frameItemList;
        /// <summary>
        /// 协议帧Id
        /// </summary>
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
        /// <summary>
        /// 协议帧包含的项
        /// </summary>
        public  List<ProtocolFrameItem> FrameItemList
        {
            get
            {
                return frameItemList;
            }

            set
            {
                frameItemList = value;
            }
        }
        /// <summary>
        /// 判断帧数据是否合法
        /// </summary>
        /// <param name="item">协议帧数据</param>
        /// <returns></returns>
        internal bool CheckProtocolFrame(string item)
        {
            return true;
        }
    }
}
