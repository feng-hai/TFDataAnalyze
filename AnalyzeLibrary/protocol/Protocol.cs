///////////////////////////////////////////////////////////
//  Protocol.cs
//  Implementation of the Class Protocol
//  Generated by Enterprise Architect
//  Created on:      24-4月-2016 9:16:28
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
    /// 协议类
    /// </summary>
    public class Protocol
    {
        private string name;
        private List<ProtocolFrame> frameList=new List<ProtocolFrame> ();
        private string url;
        private string description;


        public Protocol(string url)
        {
            this.Url = url;

         
        }
        public Protocol() {

        }

        ~Protocol()
        {

        }
        /// <summary>
        /// 协议名称
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

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public void saveFile()
        {
            DirFileHelper.CreateFile(Url, this.ToString());
        }
        public void DeleteFile()
        {
            var oldName = AnalyzeLibrary.file.DirFileHelper.GetFileNameNoExtension(Url);
            var temp = System.IO.Directory.GetCurrentDirectory() + @"\back\"+DirFileHelper.GetDateDir();
            if(!DirFileHelper.IsExistDirectory(temp))
            {
                DirFileHelper.CreateDirectory(temp);
            }
          
            DirFileHelper.MoveFile(Url, temp+@"\"  + oldName + ".xml");
        }
        /// <summary>
        /// 序列化为xml字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return XmlUtil.Serializer(typeof(Protocol), this);
        }
    }//end Protocol

}//end namespace analyze