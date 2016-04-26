///////////////////////////////////////////////////////////
//  Analyze.cs
//  Implementation of the Class Analyze
//  Generated by Enterprise Architect
//  Created on:      24-4��-2016 9:16:28
//  Original author: FH
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AnalyzeLibrary.result;

namespace AnalyzeLibrary
{
    /// <summary>
    /// ����������
    /// </summary>
    public class Analyze
    {
       
        private IAlgorithm algorithm;

        public Analyze(IAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }
        public AnalyzeResult analyzeData()
        {
            return algorithm.calculation();
        }

        ~Analyze()
        {

        }

    }//end Analyze

}//end namespace analyze