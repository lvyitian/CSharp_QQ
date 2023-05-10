/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 6:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace QQ_C_
{
	/// <summary>
	/// Description of _Hash.
	/// </summary>
	public class _Hash
	{
		private readonly object threadlock=new object();
		public _Hash()
		{
		}
		public byte[] QQTEA(byte[] content,byte[] pass)
		{
			byte[] temp_1691=new byte[0];
			lock(threadlock)
			{
				temp_1691=Program.temp_1700(content,pass);
			}
			return temp_1691;
		}
		public byte[] UNQQTEA(byte[] content,byte[] pass)
		{
			byte[] temp_1697=new byte[0];
			lock(threadlock)
			{
				temp_1697=Program.temp_1698(content,pass);
			}
			return temp_1697;
		}
	}
}
