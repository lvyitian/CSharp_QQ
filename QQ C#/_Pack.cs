/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 2:03
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace QQ_C_
{
	/// <summary>
	/// Description of _Pack.
	/// </summary>
	public class _Pack
	{
		private byte[] m_bin=new byte[0];
		public _Pack()
		{
		}
		public void Empty()
		{
			m_bin=new byte[0];
		}
		public byte[] GetAll()
		{
			return m_bin;
		}
		public int Len()
		{
			return m_bin.Length;
		}
		public void SetBin(byte[] t)
		{
			Program.AppendToArray(ref m_bin,t);
		}
		public void SetByte(byte b)
		{
			Program.AppendToArray(ref m_bin,b);
		}
		public void setData(byte[] bin)
		{
			m_bin=bin;
		}
		public void SetHex(String t)
		{
			Program.AppendToArray(ref m_bin,Program.Xbin.Hex2Bin(t));
		}
		public void SetInt(int _int)
		{
			Program.AppendToArray(ref m_bin,Program.Xbin.Int2Bin(_int));
		}
		public void SetShort(short _short)
		{
			Program.AppendToArray(ref m_bin,Program.Xbin.Short2Bin(_short));
		}
		public void SetLong(long _long)
		{
			Program.AppendToArray(ref m_bin,Program.Xbin.Long2Bin(_long));
		}
		public void SetUint(int _uint)
		{
			SetInt(Math.Abs(_uint));
		}
		public void SetStr(String t)
		{
			Program.AppendToArray(ref m_bin,System.Text.Encoding.Default.GetBytes(t));
		}
		public void SetToken(byte[] t)
		{
			unchecked{
				SetShort((short)t.Length);
			}
			SetBin(t);
		}
	}
}
