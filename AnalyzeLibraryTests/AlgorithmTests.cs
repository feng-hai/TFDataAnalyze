using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalyzeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeLibrary.Tests
{
    [TestClass()]
    public class AlgorithmTests
    {
        [TestMethod()]
        public void AlgorithmTest()
        {
            string[] temp=null;
            Algorithm a = new Algorithm("D:/test.xml", temp);

        }
    }
}