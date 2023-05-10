/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 2:25
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace QQ_C_
{
	/// <summary>
	/// Description of Type_514.
	/// </summary>
	public struct Type_514 : IEquatable<Type_514>
	{
		public long member_523; // this is just an example member, replace it with your own struct members!
		
		#region Equals and GetHashCode implementation
		// The code in this region is useful if you want to use this structure in collections.
		// If you don't need it, you can just remove the region and the ": IEquatable<Type_514>" declaration.
		
		public override bool Equals(object obj)
		{
			if (obj is Type_514)
				return Equals((Type_514)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(Type_514 other)
		{
			// add comparisions for all members here
			return this.member_523 == other.member_523;
		}
		
		public override int GetHashCode()
		{
			// combine the hash codes of all members here (e.g. with XOR operator ^)
			return member_523.GetHashCode();
		}
		
		public static bool operator ==(Type_514 left, Type_514 right)
		{
			return left.Equals(right);
		}
		
		public static bool operator !=(Type_514 left, Type_514 right)
		{
			return !left.Equals(right);
		}
		#endregion
	}
}
