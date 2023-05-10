/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 4:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace QQ_C_
{
	/// <summary>
	/// Description of MSG.
	/// </summary>
	public struct MSG : IEquatable<MSG>
	{
		public int hwnd; // this is just an example member, replace it with your own struct members!
		public int message;
		public int wParam;
		public int lParam;
		public int time;
		public Coordinate pt;
		
		#region Equals and GetHashCode implementation
		// The code in this region is useful if you want to use this structure in collections.
		// If you don't need it, you can just remove the region and the ": IEquatable<MSG>" declaration.
		
		public override bool Equals(object obj)
		{
			if (obj is MSG)
				return Equals((MSG)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(MSG other)
		{
			// add comparisions for all members here
			return this.hwnd == other.hwnd && this.lParam==other.lParam && this.message==other.message && this.pt==other.pt && this.time==other.time && this.wParam==other.wParam;
		}
		
		public override int GetHashCode()
		{
			// combine the hash codes of all members here (e.g. with XOR operator ^)
			return hwnd.GetHashCode() + message.GetHashCode() + wParam.GetHashCode() + lParam.GetHashCode() + time.GetHashCode() + pt.GetHashCode();
		}
		
		public static bool operator ==(MSG left, MSG right)
		{
			return left.Equals(right);
		}
		
		public static bool operator !=(MSG left, MSG right)
		{
			return !left.Equals(right);
		}
		#endregion
	}
}
