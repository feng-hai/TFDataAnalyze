using AnalyzeLibrary.result;
using AnalyzeLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AnalyzeLibrary.protocol
{
  public  class ThreadFile
    {
        public ThreadFile(int count,int max, ManualResetEvent mre)
        {
            iMaxCount = max;
            iCount = count;
            eventX = mre;
        }

        public static int iCount = 0;
        public static int iMaxCount = 0;
        public ManualResetEvent eventX;
        public void ThreadProc(object addr)
        {
           
            Parameter param = (Parameter)addr;

            //Thread.Sleep(2000);
            DataFrames data = new DataFrames(param.DataPath, param.ProtocolPath, param.TimeSpan);
            param.SetValue("【"+iCount+"/"+iMaxCount+"】 正在解析："+param.DataPath);
            data.GetData();
            data.DataToArray();
            param.SetValue("【" + iCount + "/" + iMaxCount + "】 成功解析：" + param.DataPath);
            DateTime dt = Convert.ToDateTime(data.formateDate());
            if (data.ValueList.Count > 0)
            {
                List<string[]> tempList = data.ValueList;
                CSVUtil.dt2csvForList(tempList, param.Address_save + "/" + dt.ToString("yyyyMMddHHmmss") + @".CSV", "", string.Join(", ", data.Header.ToArray()));
                // CSVUtil.GenerateWorkSheetWithSB(tempList, param.Address_save + "/" + dt.ToString("yyyyMMddHHmmss") + @".xls", "", string.Join(", ", data.Header.ToArray()));
                // LoadResultFile();
                param.SetValue("【" + iCount + "/" + iMaxCount + "】 成功解析：" + param.DataPath);
            }
            else {
                List<string[]> tempList = data.ValueList;
                CSVUtil.dt2csvForList(tempList, param.Address_save + "/" + dt.ToString("yyyyMMddHHmmss") + @".CSV", "", string.Join(", ", data.Header.ToArray()));
            }
            //Interlocked.Increment()操作是一个原子操作，作用是:iCount++ 具体请看下面说明 
            //原子操作，就是不能被更高等级中断抢夺优先的操作。你既然提这个问题，我就说深一点。
            //由于操作系统大部分时间处于开中断状态，
            //所以，一个程序在执行的时候可能被优先级更高的线程中断。
            //而有些操作是不能被中断的，不然会出现无法还原的后果，这时候，这些操作就需要原子操作。
            //就是不能被中断的操作。
            Interlocked.Increment(ref iCount);
            param.SetValue("【" + iCount + "/" + iMaxCount + "】 成功解析：" + param.DataPath);
            if (iCount == iMaxCount)
            {
                Console.WriteLine("发出结束信号!");
                //将事件状态设置为终止状态，允许一个或多个等待线程继续。
                eventX.Set();
            }
        }
    }
}
