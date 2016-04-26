using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeLibrary.protocol
{
  public   class ProtocolFrameItem
    {
        private string name;
        private int start;
        private int length;
        private int resolution;
        private int offset;
        /// <summary>
        /// 协议帧项名称
        /// </summary>
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
        /// <summary>
        /// 协议帧项开始位
        /// </summary>
        public int Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }
        /// <summary>
        /// 协议帧项长度
        /// </summary>
        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }
        /// <summary>
        /// 协议帧项分辨率
        /// </summary>
        public int Resolution
        {
            get
            {
                return resolution;
            }

            set
            {
                resolution = value;
            }
        }
        /// <summary>
        /// 协议帧项偏移量
        /// </summary>
        public int Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
            }
        }
    }
}
