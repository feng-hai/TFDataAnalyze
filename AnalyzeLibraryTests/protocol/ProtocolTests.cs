using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalyzeLibrary.protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeLibrary.protocol.Tests
{
    [TestClass()]
    public class ProtocolTests
    {
        Protocol pro = new Protocol("D:/test.xml");
         
        [TestMethod()]
        public void ProtocolTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void saveFileTest()
        {
            List<ProtocolFrame> temp = new List<ProtocolFrame>();
            ProtocolFrame pf = new ProtocolFrame();
            pf.FrameId = "333";
            List<ProtocolFrameItem> pfiList = new List<ProtocolFrameItem>();
            ProtocolFrameItem pfi = new ProtocolFrameItem();
            pfi.Name = "dd";
            pfiList.Add(pfi);
            pf.FrameItemList = pfiList;
            temp.Add(pf);
            pro.FrameList = temp;
            //pro.FrameList=
            pro.Name = "test";
            pro.saveFile();
           // Assert.
            //Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        
    }
}