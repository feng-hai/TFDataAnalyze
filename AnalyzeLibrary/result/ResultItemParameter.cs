using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnalyzeLibrary.result
{
    class ResultItemParameter

    {
        private string key;
        private int value;
        /// <summary>
        /// 参数名
        /// </summary>
        public string Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }
        /// <summary>
        /// 参数值
        /// </summary>
        public int Value
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
    }
   
}
