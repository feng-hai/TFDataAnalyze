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
           UInt16 int16= crc16(bys, bys.Length);
            byte[] reBy = new byte[2];
            ConvertIntToByteArray(int16, ref reBy);

            str = ByteUtil.byteToHexStr(reBy);
            return str;
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
