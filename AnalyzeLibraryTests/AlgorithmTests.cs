using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalyzeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnalyzeLibrary.file;
using AnalyzeLibrary.protocol;
using System.Windows.Forms;
using AnalyzeLibrary.Util;
using System.ComponentModel;

namespace AnalyzeLibrary.Tests
{
    [TestClass()]
    public class AlgorithmTests
    {
        [TestMethod()]
        public void AlgorithmTest()
        {
            string[] temp = null;
            string[] test = DirFileHelper.GetFileNames(@"G:\CAN", "*.TXT", true);
            string[] protocols = AnalyzeLibrary.file.DirFileHelper.GetFileNames(System.IO.Directory.GetCurrentDirectory() + @"\resource", "test.xml", true);
            string str = DirFileHelper.GetFileStr(protocols[0]);
            DataFrames data = new DataFrames(test[0], str);
            data.GetData();
            data.DataToArray();
            List<string[]> tempList = data.ValueList;
            CSVUtil.dt2csvForList(tempList, System.IO.Directory.GetCurrentDirectory() + @"\resource\test1.csv", "test", string.Join(", ", data.Header.ToArray()));
            Algorithm a = new Algorithm("D:/test.xml", temp);
        }
    }
}


public class Person
{

    private string name;

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
}