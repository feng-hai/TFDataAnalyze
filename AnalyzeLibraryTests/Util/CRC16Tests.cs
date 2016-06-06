using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalyzeLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyzeLibrary.Util.Tests
{
    [TestClass()]
    public class CRC16Tests
    {
        [TestMethod()]
        public void CRC16StringTest()
        {
           var temp= CRC16.CRC16String("00000000B5139F0100000001020304050607");
        }
    }
}