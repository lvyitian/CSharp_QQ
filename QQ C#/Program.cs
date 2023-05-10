/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/10
 * 时间: 21:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace QQ_C_
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		public static _Hash Hash=new _Hash();
		public static _Bin Xbin=new _Bin();
		public static Stopwatch timeobj=new Stopwatch();
		public static _Other Other=new _Other();
		public static FileStream LogFile=null;
		private static readonly object temp_1827=new object();
		public static bool temp_1722=false;
		public static byte[] temp_1721=new byte[16];
		public static long temp_1719=0;
		public static long temp_1720=0;
		public static int temp_1717=0;
		public static int temp_1718=0;
		public static long temp_1723=0;
		public static byte[] temp_1716=new byte[0];
		public static byte[] temp_1714=new byte[8];
		public static byte[] temp_1715=new byte[8];
		[DllImport("asm.dll",SetLastError=true,EntryPoint="temp_1713")]
		public extern static long temp_1713(int temp_1823);
		[DllImport("user32.dll",SetLastError=true,EntryPoint="PeekMessageA")]
		public extern static bool PeekMessage(MSG lpMsg,int hwnd,int wMsgFilterMin,int wMsgFilterMax,int wRemoveMsg);
		[DllImport("user32.dll",SetLastError=true,EntryPoint="GetInputState")]
		public extern static int GetInputState();
		[DllImport("user32.dll",SetLastError=true,EntryPoint="TranslateMessage")]
		public extern static bool TranslateMessage(MSG message);
		[DllImport("user32.dll",SetLastError=true,EntryPoint="DispatchMessageA")]
		public extern static int DispatchMessage(MSG message);
		public static byte[] StringToBytes(String str)
		{
			return System.Text.Encoding.Default.GetBytes(str);
		}
		public static String BytesToString(byte[] bytes)
		{
			return System.Text.Encoding.Default.GetString(bytes);
		}
		public static void FastHandleEvents()
		{
			if(GetInputState()!=0)
			{
				HandleEvents();
			}
		}
		public static void HandleEvents()
		{
			MSG CurrMsg=new MSG();
			while(PeekMessage(CurrMsg,0,0,0,1))
			{
				TranslateMessage(CurrMsg);
				DispatchMessage(CurrMsg);
			}
		}
		// <summary>  
        /// 定位指定的 System.Byte[] 在此实例中的第一个匹配项的索引。  
        /// </summary>  
        /// <param name="srcBytes">源数组</param>  
        /// <param name="searchBytes">查找的数组</param>  
        /// <param name="startindex">开始查找的位置(位置值从1开始)</></param>
        /// <returns>返回的索引位置(从1开始)；否则返回值为 -1。</returns>  
        public static int ByteIndexOf(byte[] srcBytes, byte[] searchBytes,int startindex=1)
        {
            if (srcBytes == null) { return -1; }
            if (searchBytes == null) { return -1; }
            if (srcBytes.Length == 0) { return -1; }
            if (searchBytes.Length == 0) { return -1; }
            if (srcBytes.Length < searchBytes.Length) { return -1; }
            for (int i = startindex-1; i < srcBytes.Length - searchBytes.Length; i++)
            {
                if (srcBytes[i] == searchBytes[0])
                {
                    if (searchBytes.Length == 1) { return i+1; }
                    bool flag = true;
                    for (int j = 1; j < searchBytes.Length; j++)
                    {
                        if (srcBytes[i + j] != searchBytes[j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) { return i+1; }
                }
            }
            return -1;
        }
        /// <summary>
        /// 往原字节集数组加入数据
        /// </summary>
        /// <param name="src">原字节集数组</param>
        /// <param name="data">新字节集</param>
        public static void BytesArrayAppend(ref byte[][] src,byte[] data)
        {
        	byte[][] temp=new byte[src.Length+1][];
        	for(int i=0;i<src.Length;i++)
        	{
        		temp[i]=src[i];
        	}
        	temp[src.Length]=data;
        	src=temp;
        }
        /// <summary>
        /// 返回一个字节集，其中包含指定字节集中从指定位置算起指定数量的字节。
        /// </summary>
        /// <param name="origin">原字节集</param>
        /// <param name="start">开始位置(位置值从1开始)</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public static byte[] getBytesMiddle(byte[] origin,int start,int count)
        {
        	byte[] result=new byte[count];
        	start--;
        	for(int i=start;i<start+count;i++)
        	{
        		result[i-start]=origin[i];
        	}
        	return result;
        }
        /// <summary>
        /// 返回一个字节集，其中包含指定字节集中从左边算起指定数量的字节。
        /// </summary>
        /// <param name="src">原字节集</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public static byte[] getBytesLeft(byte[] src,int count)
        {
        	byte[] result=new byte[count];
        	for(int i=0;i<count;i++)
        	{
        		result[i]=src[i];
        	}
        	return result;
        }
        /// <summary>
        /// 返回一个字节集，其中包含指定字节集中从右边算起指定数量的字节。
        /// </summary>
        /// <param name="src">原字节集</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public static byte[] getBytesRight(byte[] src,int count)
        {
        	byte[] result=new byte[count];
        	for(int i=0;i<count;i++)
        	{
        		result[i]=src[src.Length-i-1];
        	}
        	return result;
        }
        public static void AppendToArray<T>(ref T[] array,T[] data)
        {
        	T[] result=new T[array.Length+data.Length];
        	for(int i=0;i<array.Length;i++)
        	{
        		result[i]=array[i];
        	}
        	for(int i=array.Length;i<array.Length+data.Length;i++)
        	{
        		result[i]=data[i-array.Length];
        	}
        	array=result;
        }
        public static void AppendToArray<T>(ref T[] array,T data)
        {
        	T[] result=new T[array.Length+1];
        	for(int i=0;i<array.Length;i++)
        	{
        		result[i]=array[i];
        	}
        	result[array.Length]=data;
        	array=result;
        }
        public static bool ContainsArgs(String[] args,String expression)
        {
        	for(int i=0;i<args.Length;i++)
        	{
        		try{
        		if(args[i].Contains(expression))
        			return true;
        		}catch(Exception){}
        	}
        	return false;
        }
        public static bool writeFile(String path,byte[] data,FileMode mode=FileMode.OpenOrCreate,FileAccess access=FileAccess.Write,FileShare share=FileShare.ReadWrite)
        {
        	FileStream temp=File.Open(path,mode,access,share);
        	temp.Write(data,0,data.Length);
        	temp.Flush();
        	temp.Close();
        	temp.Dispose();
        	return true;
        }
        public static byte[] readFile(String path,FileMode mode=FileMode.Open,FileAccess access=FileAccess.Read,FileShare share=FileShare.ReadWrite)
        {
            FileStream temp=File.Open(path,mode,access,share);
            byte[] data=new byte[(int)temp.Length];
            temp.Read(data,0,(int)temp.Length);
        	temp.Flush();
        	temp.Close();
        	temp.Dispose();
        	return data;
        }
        public static bool Log(String text,bool autonewline=true)
        {
        	if(LogFile!=null)
        	{
        	byte[] data=System.Text.Encoding.Default.GetBytes(text);
        	if(autonewline)
        	{
        		AppendToArray(ref data,System.Text.Encoding.Default.GetBytes(Environment.NewLine));
        	}
        	LogFile.Write(data,0,data.Length);
        	LogFile.Flush();
        	return true;	
        	}else{
        		return false;
        	}
        }
        public static String DeleteLastSpace(String text)
        {
        	if(text.Substring(text.Length-1)==" ")
        	{
        		return text.Substring(0,text.Length-1);
        	}else{
        		return text;
        	}
        }
        public static bool Log(byte[] data,bool autonewline=true)
        {
        	if(LogFile!=null)
        	{
        	if(autonewline)
        	{
        		AppendToArray(ref data,System.Text.Encoding.Default.GetBytes(Environment.NewLine));
        	}
        	LogFile.Write(data,0,data.Length);
        	LogFile.Flush();
        	return true;	
        	}else{
        		return false;
        	}
        }
        public static void temp_1703(byte[] temp_1755,byte[] temp_1756,bool temp_1757,byte[] temp_1758)
        {
        	long temp_1759=0;
        	int temp_1760=0;
        	long temp_1761=0;
        	long temp_1762=0;
        	long temp_1763=0;
        	long temp_1764=0;
        	long temp_1765=0;
        	long temp_1766=0;
        	int temp_1767=0;
        	long temp_1768=0;
        	temp_1759=3816266640;
        	temp_1761=temp_1704(temp_1755,1,4);
        	temp_1762=temp_1704(temp_1755,5,4);
        	temp_1763=temp_1704(temp_1721,1,4);
        	temp_1764=temp_1704(temp_1721,5,4);
        	temp_1765=temp_1704(temp_1721,9,4);
        	temp_1766=temp_1704(temp_1721,13,4);
        	if(temp_1757)
        	{
        		temp_1760=16;
        	}else{
        		temp_1760=32;
        	}
        	for(int i=0;i<temp_1760;i++)
        	{
        		temp_1767=i+1;
        		temp_1768=temp_1709(temp_1709(temp_1712(temp_1761,4)+temp_1765,temp_1761+temp_1759),temp_1711(temp_1761,5)+temp_1766);
        		temp_1762-=temp_1768;
        		temp_1762=temp_1710(temp_1762,4294967295);
        		temp_1768=temp_1709(temp_1709(temp_1712(temp_1762,4)+temp_1763,temp_1762+temp_1759),temp_1711(temp_1762,5)+temp_1764);
        		temp_1761-=temp_1768;
        		temp_1761=temp_1710(temp_1761,4294967295);
        		temp_1759-=2654435769;
        		temp_1759=temp_1710(temp_1759,4294967295);
        	}
        	temp_1705(temp_1761,temp_1762,ref temp_1758);
        	
        }
        public static bool temp_1701(byte[] temp_1741,byte[] temp_1742,int temp_1743,bool temp_1744,ref byte[] temp_1745)
        {
        	int temp_1746=0;
        	byte[] temp_1747=new byte[0];
        	int temp_1748=0;
        	int temp_1749=0;
        	int temp_1750=0;
        	temp_1717=0;
        	temp_1718=0;
        	temp_1721=temp_1742;
        	temp_1747=new byte[temp_1743+7];
        	temp_1748=temp_1741.Length;
        	temp_1703(temp_1741,temp_1721,true,temp_1715);
        	temp_1719=temp_1715[0]&7;
        	unchecked{
        	temp_1746=(int)(temp_1748-temp_1719-10);
        	}
        	for(int i=temp_1743;i<=temp_1747.Length;i++)
        	{
        		temp_1749=i;
        		temp_1747[temp_1749-1]=0;
        		i=temp_1749;
        	}
        	temp_1716=new byte[temp_1746];
        	temp_1718=0;
        	temp_1717=8;
        	temp_1723=8;
        	temp_1719++;
        	temp_1720=1;
        	while(temp_1720<=2)
        	{
        		if(temp_1719<8)
        		{
        			temp_1719++;
        			temp_1720++;
        		}
        		if(temp_1719==8)
        		{
        			temp_1747=temp_1741;
        			temp_1702(temp_1741,temp_1743,temp_1748);
        		}
        	}
        	temp_1750=1;
        	while(temp_1746!=0)
        	{
        		if(temp_1719<8)
        		{
        			if(temp_1750<=temp_1716.Length)
        			{
        				if(temp_1719+1<=temp_1715.Length)
        				{
        					if(temp_1743+temp_1718+temp_1719<=temp_1747.Length)
        					{
        						temp_1716[temp_1750-1]=(byte)(temp_1747[temp_1743+temp_1718+temp_1719-1]^temp_1715[temp_1719]);
        					}else{
        						return false;
        					}
        				}else{
        					return false;
        				}
        			}else{
        				return false;
        			}
        			temp_1750++;
        			temp_1746--;
        			temp_1719++;
        		}
        		if(temp_1719==8)
        		{
        			temp_1747=temp_1741;
        			temp_1718=temp_1717-8;
        			temp_1702(temp_1741,temp_1743,temp_1748);
        		}
        	}
        	for(int i=1;i<=7;i++)
        	{
        		temp_1749=i;
        		if(temp_1719<8)
        		{
        			temp_1719++;
        			if(temp_1719==8)
        			{
        				temp_1747=temp_1741;
        				temp_1702(temp_1741,temp_1743,temp_1748);
        			}
        		}
        		i=temp_1749;
        	}
        	temp_1745=temp_1716;
        	return true;
        }
        public static bool temp_1702(byte[] temp_1751,int temp_1752,int temp_1753)
        {
        	int temp_1754=0;
        	for(int i=1;i<=8;i++)
        	{
        		temp_1754=i;
        		if(temp_1723+temp_1754>temp_1753)
        		{
        			return true;
        		}
        		if(temp_1752+temp_1717+temp_1754-1>temp_1751.Length)
        		{
        			return false;
        		}
        		temp_1715[temp_1754-1]=(byte)(temp_1715[temp_1754-1]^temp_1751[temp_1752+temp_1717+temp_1754-2]);
        		i=temp_1754;
        	}
        	temp_1703(temp_1715,temp_1721,true,temp_1715);
        	if(temp_1715.Length==0)
        	{
        		return false;
        	}
        	temp_1723+=8;
        	temp_1717+=8;
        	temp_1719=0;
        	return true;
        }
        public static byte[] temp_1698(byte[] temp_1724,byte[] temp_1725)
        {
        	byte[] temp_1726=new byte[0];
        	//int temp_1727=0;
        	//String temp_1728="";
        	byte[] temp_1729=new byte[0];
        	byte[] temp_1730=new byte[0];
        	byte[] temp_1830=new byte[0];
        	lock(temp_1827)
        	{
        		if(temp_1724.Length==0)
        		{
        			return new byte[0];
        		}
        		if(temp_1725.Length==0)
        		{
        			temp_1725=new byte[16];
        		}
        		temp_1699(ref temp_1725,ref temp_1730);
        		temp_1699(ref temp_1724,ref temp_1729);
        		temp_1718=0;
        		temp_1717=0;
        		temp_1719=0;
        		temp_1720=0;
        		temp_1716=new byte[0];
        		temp_1701(temp_1729,temp_1730,1,true,ref temp_1726);
        		temp_1830=temp_1726;
        	}
        	return temp_1830;
        }
        public static void temp_1699(ref byte[] temp_1731,ref byte[] temp_1732)
        {
        	temp_1732=temp_1731;
        }
        public static long temp_1710(long temp_1812,long temp_1813)
        {
        	byte[] temp_1814=new byte[0];
        	byte[] temp_1815=new byte[0];
        	byte[] temp_1816=new byte[0];
        	int temp_1817=0;
        	long temp_1818=0;
        	temp_1814=Xbin.Flip(Xbin.Long2Bin(temp_1812));
        	temp_1815=Xbin.Flip(Xbin.Long2Bin(temp_1813));
        	temp_1816=new byte[8];
        	for(int i=0;i<8;i++)
        	{
        		temp_1817=i+1;
        		temp_1816[temp_1817-1]=(byte)(temp_1814[temp_1817-1]&temp_1815[temp_1817-1]);
        	}
        	temp_1818=Xbin.Bin2Long(temp_1816);
        	return temp_1818;
        }
        public static long temp_1709(long temp_1805,long temp_1806)
        {
        	byte[] temp_1807=new byte[0];
        	byte[] temp_1808=new byte[0];
        	byte[] temp_1809=new byte[0];
        	int temp_1810=0;
        	long temp_1811=0;
        	temp_1807=Xbin.Flip(Xbin.Long2Bin(temp_1805));
        	temp_1808=Xbin.Flip(Xbin.Long2Bin(temp_1806));
        	temp_1809=new byte[8];
        	for(int i=0;i<8;i++)
        	{
        		temp_1810=i+1;
        		temp_1809[temp_1810-1]=(byte)(temp_1807[temp_1810-1]^temp_1808[temp_1810-1]);
        	}
        	temp_1811=Xbin.Bin2Long(temp_1809);
        	return temp_1811;
        }
        public static long temp_1704(byte[] temp_1769,int temp_1770,int temp_1771)
        {
        	long temp_1772=0;
        	int temp_1773=0;
        	int temp_1774=0;
        	if(temp_1771>4)
        	{
        		temp_1773=temp_1770+4;
        	}else{
        		temp_1773=temp_1770+temp_1771;
        	}
        	for(int i=temp_1770;i<=(temp_1773-1);i++)
        	{
        		temp_1774=i;
        		temp_1772=temp_1772<<8;
        		temp_1772=temp_1772 | temp_1769[temp_1774-1];
        		i=temp_1774;
        	}
        	unchecked{
        	return temp_1713((int)temp_1772);
        	}
        }
        public static long temp_1712(long temp_1821,int temp_1822)
        {
        	for(int i=0;i<temp_1822;i++)
        	{
        		unchecked{
        		temp_1821*=2;
        		}
        	}
        	return temp_1821;
        }
        public static long temp_1711(long temp_1819,int temp_1820)
        {
        	for(int i=0;i<temp_1820;i++)
        	{
        		temp_1819/=2;
        	}
        	return temp_1819;
        }
        public static void temp_1705(long temp_1775,long temp_1776,ref byte[] temp_1777)
        {
        	byte[] temp_1778=new byte[8];
        	temp_1778[0]=(byte)((temp_1775>>24)&255);
        	temp_1778[1]=(byte)((temp_1775>>16)&255);
        	temp_1778[2]=(byte)((temp_1775>>8)&255);
        	temp_1778[3]=(byte)(temp_1775&255);
        	temp_1778[4]=(byte)((temp_1776>>24)&255);
        	temp_1778[5]=(byte)((temp_1776>>16)&255);
        	temp_1778[6]=(byte)((temp_1776>>8)&255);
        	temp_1778[7]=(byte)(temp_1776&255);
        	temp_1777=temp_1778;
        }
        public static void temp_1708(byte[] temp_1790,byte[] temp_1791,bool temp_1792,ref byte[] temp_1793)
        {
        	long temp_1794=0;
        	int temp_1795=0;
        	long temp_1796=0;
        	long temp_1797=0;
        	long temp_1798=0;
        	long temp_1799=0;
        	long temp_1800=0;
        	long temp_1801=0;
        	int temp_1802=0;
        	//long temp_1803=0;
        	temp_1793=new byte[0];
        	temp_1796=temp_1704(temp_1790,1,4);
        	temp_1797=temp_1704(temp_1790,5,4);
        	temp_1798=temp_1704(temp_1721,1,4);
        	temp_1799=temp_1704(temp_1721,5,4);
        	temp_1800=temp_1704(temp_1721,9,4);
        	temp_1801=temp_1704(temp_1721,13,4);
        	if(temp_1792)
        	{
        		temp_1795=16;
        	}else{
        		temp_1795=32;
        	}
        	for(int i=0;i<temp_1795;i++)
        	{
        		temp_1802=i+1;
        		temp_1794=temp_1710(temp_1794,4294967295);
        		temp_1794+=2654435769;
        		temp_1797=temp_1710(temp_1797,4294967295);
        		unchecked{
        		temp_1796+=temp_1709(temp_1709(temp_1712(temp_1797,4)+temp_1798,temp_1797+temp_1794),temp_1711(temp_1797,5)+temp_1799);
        		}
        		temp_1796=temp_1710(temp_1796,4294967295);
        		unchecked{
        		temp_1797+=temp_1709(temp_1709(temp_1712(temp_1796,4)+temp_1800,temp_1796+temp_1794),temp_1711(temp_1796,5)+temp_1801);
        		}
        	}
        	temp_1705(temp_1796,temp_1797,ref temp_1793);
        }
        public static void temp_1707(bool temp_1787)
        {
        	byte[] temp_1788=new byte[0];
        	int temp_1789=0;
        	temp_1719=1;
        	for(int i=0;i<8;i++)
        	{
        		temp_1789=i+1;
        		if(temp_1722)
        		{
        			unchecked{
        				temp_1714[temp_1789-1]=(byte)Program.Xbin.Long2Bin(temp_1709(temp_1714[temp_1789-1],temp_1715[0]))[7];
        			}
        		}else{
        			if((temp_1718+temp_1789)>temp_1716.Length)
        			{
        				return;
        			}
        			unchecked{
        				temp_1714[temp_1789-1]=(byte)Program.Xbin.Long2Bin(temp_1709(temp_1714[temp_1789-1],temp_1716[temp_1718+temp_1789-1]))[7];
        			}
        		}
        	}
        	temp_1708(temp_1714,temp_1721,temp_1787,ref temp_1788);
        	for(int i=0;i<temp_1788.Length;i++)
        	{
        		temp_1789=i+1;
        		if((temp_1717+temp_1789)>temp_1716.Length)
        		{
        			return;
        		}
        		temp_1716[temp_1717+temp_1789-1]=temp_1788[temp_1789-1];
        	}
        	for(int i=0;i<8;i++)
        	{
        		temp_1789=i+1;
        		if((temp_1717+temp_1789)>temp_1716.Length)
        		{
        			return;
        		}
        		unchecked{
        			temp_1716[temp_1717+temp_1789-1]=(byte)Program.Xbin.Long2Bin(temp_1709(temp_1716[temp_1717+temp_1789-1],temp_1715[temp_1789-1]))[7];
        		}
        	}
        	for(int i=0;i<temp_1714.Length;i++)
        	{
        		temp_1789=i+1;
        		if(temp_1789>temp_1715.Length)
        		{
        			return;
        		}
        		temp_1715[temp_1789-1]=temp_1714[temp_1789-1];
        	}
        	temp_1718=temp_1717;
        	temp_1717+=8;
        	temp_1719=0;
        	temp_1722=false;
        }
        public static void temp_1706(byte[] temp_1779,byte[] temp_1780,int temp_1781,bool temp_1782,ref byte[] temp_1783)
        {
        	int temp_1784=0;
        	int temp_1785=0;
        	int temp_1786=0;
        	temp_1722=true;
        	temp_1721=temp_1780;
        	temp_1719=1;
        	temp_1720=0;
        	temp_1717=0;
        	temp_1718=0;
        	temp_1784=temp_1779.Length;
        	temp_1719=(temp_1784+10)%8;
        	if(temp_1719!=0)
        	{
        		temp_1719=8-temp_1719;
        	}
        	temp_1716=new byte[temp_1784+temp_1719+9+1];
        	int tempet;
        	unchecked{
        		tempet=(int)timeobj.ElapsedTicks;
        	}
        	unchecked{
        		temp_1714[0]=(byte)Program.Xbin.Long2Bin(temp_1709(temp_1710(new Random(tempet).Next(1000,5000),248),temp_1719))[7];
        	}
        	for(int i=0;i<temp_1719;i++)
        	{
        		temp_1785=i+1;
        		unchecked{
        		tempet=(int)timeobj.ElapsedTicks;
        	    }
        		unchecked{
        			temp_1714[temp_1785]=(byte)Program.Xbin.Long2Bin(temp_1710(new Random(tempet).Next(1000,5000),255))[7];
        		}
        	}
        	for(int i=0;i<8;i++)
        	{
        		temp_1785=i+1;
        		temp_1715[temp_1785-1]=0;
        	}
        	temp_1719++;
        	temp_1720=1;
        	do{
        		if(temp_1719<8)
        		{
        			unchecked{
        		    tempet=(int)timeobj.ElapsedTicks;
        	        }
        			unchecked{
        				temp_1714[temp_1719]=(byte)Program.Xbin.Long2Bin(temp_1710(new Random(tempet).Next(1000,5000),255))[7];
        			}
        			temp_1719++;
        			temp_1720++;
        		}else{
        			temp_1707(temp_1782);
        		}
        	}while(temp_1720<3);
        	temp_1786=temp_1781;
        	while(temp_1784>0)
        	{
        		if(temp_1719<8)
        		{
        			temp_1714[temp_1719]=temp_1779[temp_1786-1];
        			temp_1719++;
        			temp_1784--;
        			temp_1786++;
        		}else{
        			temp_1707(temp_1782);
        		}
        	}
        	temp_1720=1;
        	while(temp_1720<8)
        	{
        		if(temp_1719<8)
        		{
        			temp_1714[temp_1719]=0;
        			temp_1720++;
        			temp_1719++;
        		}
        		if(temp_1719==8)
        		{
        			temp_1707(temp_1782);
        		}
        	}
        	temp_1783=temp_1716;
        }
        public static byte[] temp_1700(byte[] temp_1734,byte[] temp_1735)
        {
        	byte[] temp_1736=new byte[0];
        	/*int temp_1737=0;
        	String temp_1738="";*/
        	byte[] temp_1739=new byte[0];
        	byte[] temp_1740=new byte[0];
        	byte[] temp_1829=new byte[0];
        	lock(temp_1827)
        	{
        		temp_1699(ref temp_1735,ref temp_1740);
        		temp_1699(ref temp_1734,ref temp_1739);
        		temp_1706(temp_1739,temp_1740,1,true,ref temp_1736);
        		temp_1829=temp_1736;
        	}
        	return temp_1829;
        }
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			timeobj.Start();
			if(!ContainsArgs(args,"-nolog"))
			{
			try{
			File.Delete("CSQQLog.log");
			LogFile=File.Open("CSQQLog.log",FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.Read);
			}catch(Exception e){MessageBox.Show(e.ToString(),e.Message);Environment.Exit(e.HResult);}
			}
			Control.CheckForIllegalCrossThreadCalls=false;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);
			Application.Run(new MainForm());
		}
		
	}
}
