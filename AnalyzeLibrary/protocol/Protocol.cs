///////////////////////////////////////////////////////////
//  Protocol.cs
//  Implementation of the Class Protocol
//  Generated by Enterprise Architect
//  Created on:      24-4��-2016 9:16:28
//  Original author: FH
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AnalyzeLibrary.Util;
using AnalyzeLibrary.file;

namespace AnalyzeLibrary.protocol
{
    /// <summary>
    /// Э����
    /// </summary>
    public class Protocol
    {
        private string name;
        private List<ProtocolFrame> frameList;
        private string url;


        public Protocol(string url)
        {
            this.url = url;
        }
        public Protocol() {

        }

        ~Protocol()
        {

        }
        /// <summary>
        /// Э������
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

        public List<ProtocolFrame> FrameList
        {
            get
            {
                return frameList;
            }

            set
            {
                frameList = value;
            }
        }

        public void saveFile()
        {
            DirFileHelper.CreateFile(url, this.ToString());
        }
        /// <summary>
        /// ���л�Ϊxml�ַ���
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return XmlUtil.Serializer(typeof(Protocol), this);
        }
    }//end Protocol

}//end namespace analyze