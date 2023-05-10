/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 2:50
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace QQ_C_
{
	/// <summary>
	/// Description of Type_513.
	/// </summary>
	public struct Type_513 : IEquatable<Type_513>
	{
		public short member_515; // this is just an example member, replace it with your own struct members!
		public short member_516;
		public short member_517;
		public short member_518;
		public short member_519;
		public short member_520;
		public short member_521;
		public short member_522;
		
		#region Equals and GetHashCode implementation
		// The code in this region is useful if you want to use this structure in collections.
		// If you don't need it, you can just remove the region and the ": IEquatable<Type_513>" declaration.
		
		public override bool Equals(object obj)
		{
			if (obj is Type_513)
				return Equals((Type_513)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(Type_513 other)
		{
			// add comparisions for all members here
			return this.member_515 == other.member_515 && this.member_516==other.member_516 && this.member_517==other.member_517 && this.member_518==other.member_518 && this.member_519==other.member_519 && this.member_520==other.member_520 && this.member_521==other.member_521 && this.member_522==other.member_522;
		}
		
		public override int GetHashCode()
		{
			// combine the hash codes of all members here (e.g. with XOR operator ^)
			return member_515.GetHashCode() + member_516.GetHashCode() + member_517.GetHashCode() + member_518.GetHashCode() + member_519.GetHashCode() + member_520.GetHashCode() + member_521.GetHashCode() + member_522.GetHashCode();
		}
		
		public static bool operator ==(Type_513 left, Type_513 right)
		{
			return left.Equals(right);
		}
		
		public static bool operator !=(Type_513 left, Type_513 right)
		{
			return !left.Equals(right);
		}
		#endregion
	}
}
