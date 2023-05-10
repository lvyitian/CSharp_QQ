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
	public struct Type_1653 : IEquatable<Type_1653>
	{
		public long member_1654; // this is just an example member, replace it with your own struct members!
		
		#region Equals and GetHashCode implementation
		// The code in this region is useful if you want to use this structure in collections.
		// If you don't need it, you can just remove the region and the ": IEquatable<Type_514>" declaration.
		
		public override bool Equals(object obj)
		{
			if (obj is Type_1653)
				return Equals((Type_1653)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(Type_1653 other)
		{
			// add comparisions for all members here
			return this.member_1654 == other.member_1654;
		}
		
		public override int GetHashCode()
		{
			// combine the hash codes of all members here (e.g. with XOR operator ^)
			return member_1654.GetHashCode();
		}
		
		public static bool operator ==(Type_1653 left, Type_1653 right)
		{
			return left.Equals(right);
		}
		
		public static bool operator !=(Type_1653 left, Type_1653 right)
		{
			return !left.Equals(right);
		}
		#endregion
	}
}
