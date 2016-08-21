using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyzeLibrary.result
{
   public class Parameter
    {
        private string dataPath = string.Empty;
        private string protocolPath = string.Empty;
        private int timeSpan;
        private string address_save = string.Empty;

        public Parameter(string dataPath, string protocolPath, int timeSpan,string addr)
        {
            this.dataPath = dataPath;
            this.protocolPath = protocolPath;
            this.timeSpan = timeSpan;
            this.Address_save = addr;
        }

        public string DataPath
        {
            get
            {
                return dataPath;
            }

            set
            {
                dataPath = value;
            }
        }

        public string ProtocolPath
        {
            get
            {
                return protocolPath;
            }

            set
            {
                protocolPath = value;
            }
        }

        public int TimeSpan
        {
            get
            {
                return timeSpan;
            }

            set
            {
                timeSpan = value;
            }
        }

        public string Address_save
        {
            get
            {
                return address_save;
            }

            set
            {
                address_save = value;
            }
        }
    }
}
