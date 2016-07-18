using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnalyzeLibrary.Util
{
    public class CSVUtil
    {


        public static void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }


        /// <summary>
        /// 导出报表为Csv
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="strFilePath">物理路径</param>
        /// <param name="tableheader">表头</param>
        /// <param name="columname">字段标题,逗号分隔</param>
        public static bool dt2csv(DataTable dt, string strFilePath, string tableheader, string columname)
        {
            try
            {
                string strBufferLine = "";
                StreamWriter strmWriterObj = new StreamWriter(strFilePath, false, System.Text.Encoding.UTF8);
                strmWriterObj.WriteLine(tableheader);
                strmWriterObj.WriteLine(columname);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strBufferLine = "";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j > 0)
                            strBufferLine += ",";
                        strBufferLine += dt.Rows[j].ToString();
                    }
                    strmWriterObj.WriteLine(strBufferLine);
                }
                strmWriterObj.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 导出报表为Csv
        /// </summary>
        /// <param name="list">list</param>
        /// <param name="strFilePath">物理路径</param>
        /// <param name="tableheader">表头</param>
        /// <param name="columname">字段标题,逗号分隔</param>
        public static bool dt2csvForList(List<string[]> list, string strFilePath, string tableheader, string columname)
        {

           // GenerateWorkSheetWithSB(list, strFilePath, tableheader, columname);
            try
            {
                string strBufferLine = "";
                StreamWriter strmWriterObj = new StreamWriter(strFilePath, false, System.Text.Encoding.Default);
                //strmWriterObj.WriteLine(tableheader);
                strmWriterObj.WriteLine(columname);
                for (int i = 0; i < list.Count; i++)
                {
                    strBufferLine = "";
                    for (int j = 0; j < list[i].Length; j++)
                    {
                        if (j > 0)
                            strBufferLine += ",";
                        if (string.IsNullOrEmpty(list[i][j]))
                        {
                            strBufferLine += string.Empty;
                        }
                        else
                        {
                            strBufferLine += list[i][j].ToString();
                        }

                    }
                    strmWriterObj.WriteLine(strBufferLine);
                }
                strmWriterObj.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //public static bool dt2csvForList_Web(List<string[]> list, string strFilePath, string tableheader, string columname)
        //{
        //    try
        //    {
        //        System.Web.HttpContext context = System.Web.HttpContext.Current;
        //        //  StreamWriter strmWriterObj = new StreamWriter(strFilePath, false, System.Text.Encoding.Default);

        //        StringBuilder sb = new StringBuilder(columname);
        //        //strmWriterObj.WriteLine(tableheader);
        //        // strmWriterObj.WriteLine(columname);
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            for (int j = 0; j < list[i].Length; j++)
        //            {
        //                if (j > 0)
        //                    sb.Append(",");
        //                if (string.IsNullOrEmpty(list[i][j]))
        //                {
        //                    sb.Append(string.Empty);
        //                }
        //                else
        //                {
        //                    sb.Append(list[i][j].ToString());
        //                }

        //            }
        //            //  strmWriterObj.WriteLine(strBufferLine);
        //        }
        //        StringWriter sw = new StringWriter(sb);
        //        sw.Close();
        //        context.Response.Clear();
        //        /*  
        //         * Acme 2012-07-04 edit  
        //         *   
        //        context.Response.Charset = "gb2312";  
        //        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");  
        //        context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/octet-stream"; //"application/vnd.ms-excel"; //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet                    
        //        //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));  
        //        */
        //        //below is new writing    
        //        context.Response.Charset = "UTF-8";
        //        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        //        context.Response.HeaderEncoding = System.Text.Encoding.UTF8;
        //        context.Response.ContentType = "text/csv";
        //        //主要是下面这一句  
        //        context.Response.BinaryWrite(new byte[] { 0xEF, 0xBB, 0xBF });
        //        context.Response.Write(sw);
        //        context.Response.AppendHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(strFilePath, System.Text.Encoding.UTF8).Replace("+", "%20"));
        //        //context.Response.OutputStream.Write(fileData, 0, fileData.Length);    
        //        context.Response.Flush();
        //        context.Response.End();


        //        // strmWriterObj.Close();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}


        /// <summary>
		/// Creates Excel Header 		
		/// </summary>
		/// <returns>Excel Header Strings</returns>
		private static string ExcelHeader()
        {
            // Excel header
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<?xml version=\"1.0\"?>\n");
            sb.Append("<?mso-application progid=\"Excel.Sheet\"?>\n");
            sb.Append("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
            sb.Append("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
            sb.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\" ");
            sb.Append("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" ");
            sb.Append("xmlns:html=\"http://www.w3.org/TR/REC-html40\">\n");
            sb.Append("<DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">");
            sb.Append("<Author>Dekajp@gmail.com</Author>");
            sb.Append("</DocumentProperties>");
            sb.Append("<ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">\n");
            sb.Append("<ProtectStructure>False</ProtectStructure>\n");
            sb.Append("<ProtectWindows>False</ProtectWindows>\n");
            sb.Append("</ExcelWorkbook>\n");

            return sb.ToString();
        }

        /// <summary>
        /// Read styles and copy it to the Excel string
        /// </summary>
        /// <param name="filename">Styles.config</param>
        /// <returns></returns>
        private static string ExcelStyles(string filename)
        {
            System.IO.StreamReader SR;
            string S;
            string strFileText = string.Empty;
            SR = System.IO.File.OpenText(filename);
            S = SR.ReadLine();
            strFileText = S;
            while (S != null)
            {
                S = SR.ReadLine();

                strFileText += S + "\n";
            }
            SR.Close();
            return strFileText;
        }

        private static  string ExcelWorkSheetOptions()
        {
            // This is Required Only Once ,	But this has to go after the First Worksheet's First Table		
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("\n<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">\n<Selected/>\n </WorksheetOptions>\n");
            return sb.ToString();
        }

        /// <summary>
        /// Cerates the First Worksheet 
        /// </summary>
        /// <returns>String</returns>
        private static string  WriteFirstWorkSheet()
        {
            //These tags can be generated by jsut creating an test Excel and Save As "Spreadsheet XML"
            string strFirstWorkSheet = string.Empty;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //	sb+="";
            string strNewLine = "\n";
            strFirstWorkSheet += "<Worksheet ss:Name=\"Sheet1\">" + strNewLine;
            strFirstWorkSheet += "<Table ss:ExpandedColumnCount=\"2\" ss:ExpandedRowCount=\"10\" x:FullColumns=\"1\"   x:FullRows=\"1\">" + strNewLine;
            strFirstWorkSheet += "<Column ss:AutoFitWidth=\"0\" ss:Width=\"79.5\"/>" + strNewLine;
            strFirstWorkSheet += "<Row ss:Index=\"2\">" + strNewLine;
            // Merge Cells
            strFirstWorkSheet += "<Cell ss:MergeAcross=\"1\" ss:StyleID=\"s26\"><Data ss:Type=\"String\">Column Merged</Data></Cell>" + strNewLine;
            strFirstWorkSheet += "</Row>" + strNewLine;
            // Bold
            strFirstWorkSheet += "<Row ss:Index=\"4\">" + strNewLine;
            strFirstWorkSheet += "<Cell ss:StyleID=\"s24\"><Data ss:Type=\"String\">Bold</Data></Cell>" + strNewLine;
            strFirstWorkSheet += "</Row>" + strNewLine;
            strFirstWorkSheet += "<Row ss:Index=\"6\">" + strNewLine;
            //Italics
            strFirstWorkSheet += "<Cell ss:StyleID=\"s25\"><Data ss:Type=\"String\">Italics</Data></Cell>" + strNewLine;
            strFirstWorkSheet += "</Row>" + strNewLine;
            strFirstWorkSheet += "<Row ss:Index=\"8\">" + strNewLine;
            //Hyperlink
            strFirstWorkSheet += "<Cell ss:StyleID=\"s27\" ss:HRef=\"#Worksheet1!A1\" ><Data ss:Type=\"String\">Hyperlink</Data></Cell>" + strNewLine;
            strFirstWorkSheet += "</Row>" + strNewLine;
            //Row Height
            strFirstWorkSheet += "<Row ss:Index=\"10\" ss:AutoFitHeight=\"0\" ss:Height=\"30\">" + strNewLine;
            strFirstWorkSheet += "<Cell><Data ss:Type=\"String\">Row Height</Data></Cell>" + strNewLine;
            strFirstWorkSheet += "</Row>" + strNewLine;
            // Close Tags
            strFirstWorkSheet += "</Table>" + strNewLine;
            strFirstWorkSheet += "</Worksheet>" + strNewLine;

            return strFirstWorkSheet;
        }
        // Final Filtaration of String Code generated by above code
        public static string ConvertHTMLToExcelXML(string strHtml)
        {

            // Just to replace TR with Row
            strHtml = strHtml.Replace("<tr>", "<Row ss:AutoFitHeight=\"1\" >\n");
            strHtml = strHtml.Replace("</tr>", "</Row>\n");

            //replace the cell tags
            strHtml = strHtml.Replace("<td>", "<Cell><Data ss:Type=\"String\">");
            strHtml = strHtml.Replace("</td>", "</Data></Cell>\n");

            return strHtml;
        }

        public  static void GenerateWorkSheetWithSB(List<string[]> list, string strFilePath, string tableheader, string columname)
        {

            StringBuilder strExcelXml = new StringBuilder();
           // System.Diagnostics.Debug.WriteLine(" Start " + System.DateTime.Now.ToString());
          //  System.Windows.Forms.MessageBox.Show(" Start Generating " + System.DateTime.Now.ToString());
            //First Write the Excel Header
            strExcelXml.Append(ExcelHeader());
            // Get all the Styles
            //strExcelXml.Append(ExcelStyles("styles.config"));

            // Create First Worksheet
           // strExcelXml.Append(WriteFirstWorkSheet());
            // Worksheet options Required only one time 
            //strExcelXml.Append(ExcelWorkSheetOptions());


            //for (int i = 1; i < iWorkSheet; i++)
            //{
                // Create First Worksheet tag
                strExcelXml.Append("<Worksheet ss:Name=\"WorkSheet" + tableheader + "\">");
                // Then Table Tag
                strExcelXml.Append("<Table>");
                list.Insert(0,columname.Split(','));
                for (int k = 0; k < list.Count; k++)
                {
                    // Row Tag
                    strExcelXml.Append("<tr>");
                    for (int j = 0; j < list[k].Length; j++)
                    {
                        // Cell Tags
                        strExcelXml.Append("<td>");
                        strExcelXml.Append(list[k][j]);
                        strExcelXml.Append("</td>");
                    }
                    strExcelXml.Append("</tr>");

                }
                strExcelXml.Append("</Table>");


                strExcelXml.Append("</Worksheet>");
            //}
            // Close the Workbook tag (in Excel header you can see the Workbook tag)
            strExcelXml.Append("</Workbook>\n");

          //  System.Windows.Forms.MessageBox.Show(" Finished  " + System.DateTime.Now.ToString());

            #region "Write Into File"
            try
            {


                System.IO.File.Delete(strFilePath);

                System.IO.StreamWriter sw = new System.IO.StreamWriter(strFilePath, true, System.Text.Encoding.Unicode);
                sw.Write(ConvertHTMLToExcelXML(strExcelXml.ToString()));
                sw.Close();


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            System.Windows.Forms.MessageBox.Show("Data Exported Successfully.");
            #endregion
        }



    }
}
