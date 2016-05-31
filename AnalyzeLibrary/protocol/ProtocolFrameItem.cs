using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnalyzeLibrary.protocol
{
  public   class ProtocolFrameItem
    {
        private string name;
        private int start;
        private int length;
        private float resolution;
        private int offset;
        private float value;
        private string unit=string.Empty;
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
        public float Resolution
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

        public float Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }
    }
}
