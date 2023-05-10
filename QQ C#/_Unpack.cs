/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 12:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace QQ_C_
{
	/// <summary>
	/// Description of _Unpack.
	/// </summary>
	public class _Unpack
	{
		private byte[] m_bin=new byte[0];
		public _Unpack()
		{
		}
		public byte[] GetAll(bool ignore=default(bool))
		{
			return m_bin;
		}
		public String GetAll_Hex()
		{
			return Program.Xbin.Bin2Hex(m_bin);
		}
		public byte[] GetBin(int len)
		{
			byte[] temp_479=new byte[0];
			temp_479=Program.getBytesLeft(m_bin,len);
			m_bin=Program.getBytesRight(m_bin,m_bin.Length-len);
			return temp_479;
		}
		public byte GetByte()
		{
			byte[] temp_480=new byte[0];
			temp_480=Program.getBytesLeft(m_bin,1);
			m_bin=Program.getBytesRight(m_bin,m_bin.Length-1);
			return (byte)Program.Xbin.Bin2Byte(temp_480);
		}
		public int GetInt()
		{
			byte[] temp_499=new byte[0];
			temp_499=Program.getBytesLeft(m_bin,4);
			m_bin=Program.getBytesRight(m_bin,m_bin.Length-4);
			return Program.Xbin.Bin2Int(temp_499);
		}
		public long GetLong()
		{
			byte[] temp_1498=new byte[0];
			temp_1498=Program.getBytesLeft(m_bin,8);
			m_bin=Program.getBytesRight(m_bin,m_bin.Length-8);
			return Program.Xbin.Bin2Long(temp_1498);
		}
		public short GetShort()
		{
			byte[] temp_501=new byte[0];
			temp_501=Program.getBytesLeft(m_bin,2);
			m_bin=Program.getBytesRight(m_bin,m_bin.Length-2);
			return Program.Xbin.Bin2Short(temp_501);
		}
		public byte[] GetToken()
		{
			int temp_503=0;
			temp_503=GetShort();
			return GetBin(temp_503);
		}
		public int Len()
		{
			return m_bin.Length;
		}
		public void SetData(byte[] b)
		{
			m_bin=b;
		}
		public void SetData_Hex(String hex)
		{
			m_bin=Program.Xbin.Hex2Bin(hex);
		}
		public void searchBin(byte[] b)
		{
			int temp_1833=0;
			Program.Log(Program.Xbin.BinToString(m_bin));
			temp_1833=Program.ByteIndexOf(m_bin,b,1);
			if(temp_1833!=-1)
			{
				m_bin=Program.getBytesRight(m_bin,m_bin.Length-temp_1833);
			}
		}
	}
}
