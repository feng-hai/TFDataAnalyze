using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeLibrary.result
{
    class AnalyzeResultItem
    {

        private DateTime time;
        private string id;
        private List<ResultItemParameter> parameter;

        public DateTime Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        internal List<ResultItemParameter> Parameter
        {
            get
            {
                return parameter;
            }

            set
            {
                parameter = value;
            }
        }

        public AnalyzeResultItem()
        {

        }

    }
}
