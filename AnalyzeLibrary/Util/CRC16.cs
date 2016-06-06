using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyzeLibrary.Util
{
    public class CRC16
    {
        public CRC16() { }


        public static string CRC16String(string data)
        {
            string str = string.Empty;
            byte[] bys = ByteUtil.strToToHexByte(data);
            // UInt16 int16= crc16(bys, bys.Length);
            //  byte[] reBy = new byte[2];

          
           // ConvertIntToByteArray(int16, ref reBy);

           // str = Convert.ToString((crc16_(bys, bys.Length)),16);
            str = Convert.ToString((checkBytes(bys)), 16);
            return str;
        }


        public static byte checkBytes(byte[] data)
        {
            byte temp = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                temp =(byte) (temp ^ data[i]);
            }

            return temp;

        }
        public static byte crc16_(byte[] data, int len)
        {
           
            int xda, xdapoly;
            int i, j, xdabit;
            xda = 0xFFFF;
            xdapoly = 0x1021;
            for (i = 0; i < len; i++)
            {
                xda ^= data[i];
                for (j = 0; j < 8; j++)
                {
                    xdabit = (int)(xda & 0x01);
                    xda >>= 1;
                    if (xdabit == 1)
                        xda ^= xdapoly;
                }
            }
           byte temdata = (byte)(xda & 0xFF);
            //temdata[1] = (byte)(xda >> 8);
            return temdata;
        }
        public static UInt16 crc16(byte[] data, int len)
        {
            UInt16 i, j;
            UInt16 temp;

            temp = 0xFFFF;
            for (i = 0; i < len; i++)
            {
                temp =(UInt16) (temp ^ data[i]);
                for (j = 0; j < 8; j++)
                {
                    if ((temp & 0x0001)==1)
                    {
                        temp = (UInt16)(temp >> 1);
                        temp = (UInt16)(temp ^ 0x1021);
                    }
                    else
                        temp = (UInt16)(temp >> 1);
                }
            }
            return  temp;

        }

        /// <summary>
        /// 把int32类型的数据转存到4个字节的byte数组中
        /// </summary>
        /// <param name="m">int32类型的数据</param>
        /// <param name="arry">4个字节大小的byte数组</param>
        /// <returns></returns>
        static bool ConvertIntToByteArray(UInt16 m, ref byte[] arry)
        {
            if (arry == null) return false;
            if (arry.Length < 2) return false;

            arry[0] = (byte)(m & 0xFF);
            arry[1] = (byte)((m & 0xFF00) >> 8);
            return true;
        }



    }

}
