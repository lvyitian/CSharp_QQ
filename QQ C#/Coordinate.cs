/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 4:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace QQ_C_
{
	/// <summary>
	/// Description of Coordinate.
	/// </summary>
	public struct Coordinate : IEquatable<Coordinate>
	{
		public int x; // this is just an example member, replace it with your own struct members!
		public int y;
		
		#region Equals and GetHashCode implementation
		// The code in this region is useful if you want to use this structure in collections.
		// If you don't need it, you can just remove the region and the ": IEquatable<Coordinate>" declaration.
		
		public override bool Equals(object obj)
		{
			if (obj is Coordinate)
				return Equals((Coordinate)obj); // use Equals method below
			else
				return false;
		}
		
		public bool Equals(Coordinate other)
		{
			// add comparisions for all members here
			return this.x == other.x && this.y==other.y;
		}
		
		public override int GetHashCode()
		{
			// combine the hash codes of all members here (e.g. with XOR operator ^)
			return x.GetHashCode() + y.GetHashCode();
		}
		
		public static bool operator ==(Coordinate left, Coordinate right)
		{
			return left.Equals(right);
		}
		
		public static bool operator !=(Coordinate left, Coordinate right)
		{
			return !left.Equals(right);
		}
		#endregion
	}
}
