/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/10
 * 时间: 21:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace QQ_C_
{
	/// <summary>
	/// Description of _Bin.
	/// </summary>
	public class _Bin
	{
		public _Bin()
		{
		}
		/// <summary>
		/// 取出想要的内容
		/// </summary>
		/// <param name="origin">完整内容</param>
		/// <param name="result">可空，当“循环读取”为真时，不可为空.返回结果的数组.</param>
		/// <param name="left">左边文本</param>
		/// <param name="right">右边文本</param>
		/// <param name="all">可空，默认为假，为真时“左边文本”“右边文本”“结果数组”不能为空</param>
		/// <returns>想要的内容</returns>
		public byte[] MidBin(byte[] origin,ref byte[][] result,byte[] left=null,byte[] right=null,bool all=false)
		{
			int temp_295=0;
			int temp_296=0;
			byte[] temp_297=new byte[0];
			int temp_298=0;
			int temp_299=0;
			temp_296=origin.Length;
			if(all)
			{
				if(left.Length==0 || right.Length==0)
				{
					return new byte[0];
				}else{
					result=new byte[0][];
					temp_298=Program.ByteIndexOf(origin,left);
					while(temp_298!=-1)
					{
						temp_295=temp_298+1;
						temp_299=Program.ByteIndexOf(origin,right,temp_298);
						Program.BytesArrayAppend(ref result,Program.getBytesMiddle(origin,temp_298+left.Length,Program.ByteIndexOf(origin,left,temp_295)));
						temp_298=Program.ByteIndexOf(origin,left,temp_295);
					}
					if(result.Length>1)
					{
						return result[0];
					}else{
						return new byte[0];
					}
				}
			}else{
				if(right.Length==0)
				{
					if(Program.ByteIndexOf(origin,left)>-1)
					{
						temp_295=Program.ByteIndexOf(origin,left)+left.Length;
						temp_297=Program.getBytesMiddle(origin,temp_295,temp_296);
						return temp_297;
					}else{
						return new byte[0];
					}
				}else{
					if(left.Length==0)
					{
						if(Program.ByteIndexOf(origin,right)>-1)
						{
							temp_295=Program.ByteIndexOf(origin,right)-1;
							temp_297=Program.getBytesLeft(origin,temp_295);
							return temp_297;
						}else{
							return new byte[0];
						}
					}else{
						if(left.Length==0 && right.Length==0)
						{
							return new byte[0];
						}else{
							if(Program.ByteIndexOf(origin,left)>-1)
							{
								temp_295=Program.ByteIndexOf(origin,left)+left.Length;
								temp_297=Program.getBytesMiddle(origin,temp_295,temp_296);
								temp_296=temp_297.Length;
								temp_295=Program.ByteIndexOf(temp_297,right)-1;
								temp_297=Program.getBytesMiddle(temp_297,1,temp_295);
								return temp_297;
							}else{
								return new byte[0];
							}
						}
					}
				}
			}
		}
		/// <summary>
		/// 反转字节集
		/// </summary>
		/// <param name="bin">原字节集</param>
		/// <returns>反转后字节集</returns>
		public byte[] Flip(byte[] bin)
		{
			byte[] result=new byte[bin.Length];
			for(int i=0;i<bin.Length;i++)
			{
				result[bin.Length-i-1]=bin[i];
			}
			return result;
		}
		public int Bin2Int(byte[] bytes)
		{
			return (int) ((int)((bytes[0] & 0xFF)<<24)
			              | (int)((bytes[1] & 0xFF)<<16)
			              | (int)((bytes[2] & 0xFF)<<8)
			              | (int)((bytes[3] & 0xFF)));
		}
		public byte[] Int2Bin(int integer)
		{
			byte[] result=new byte[4];
			result[0] =  (byte) (int)((integer>>24) & 0xFF);
			result[1] =  (byte) (int)((integer>>16) & 0xFF);
			result[2] =  (byte) (int)((integer>>8) & 0xFF);
			result[3] =  (byte) (int)(integer & 0xFF);
            return result;
		}
		public byte[] Long2Bin(long value)
		{
			byte[] result=new byte[8];
			result[0]=(byte)(long)((value>>56)&0xFFL);
			result[1]=(byte)(long)((value>>48)&0xFFL);
			result[2]=(byte)(long)((value>>40)&0xFFL);
			result[3]=(byte)(long)((value>>32)&0xFFL);
			result[4]=(byte)(long)((value>>24)&0xFFL);
			result[5]=(byte)(long)((value>>16)&0xFFL);
			result[6]=(byte)(long)((value>>8)&0xFFL);
			result[7]=(byte)(long)(value&0xFFL);
			return result;
		}
		public long Bin2Long(byte[] bytes)
		{
			return (long) ((long)((bytes[0] & 0xFFL)<<56)
			               | (long)((bytes[1] & 0xFFL)<<48)
			               | (long)((bytes[2] & 0xFFL)<<40)
			               | (long)((bytes[3] & 0xFFL)<<32)
			               | (long)((bytes[4] & 0xFFL)<<24)
			               | (long)((bytes[5] & 0xFFL)<<16)
			               | (long)((bytes[6] & 0xFFL)<<8)
			               | (long)((bytes[7] & 0xFFL)));
		}
		public byte[] Short2Bin(short value)
		{
			byte[] result=new byte[2];
			result[0]=(byte)(short)((value>>8)&(short)0xFF);
			result[1]=(byte)(short)(value&(short)0xFF);
			return result;
		}
		public short Bin2Short(byte[] bytes)
		{
			return (short)((short)((bytes[0] & (short)0xFF)<<8)
			               | (short)((bytes[1] & (short)0xFF)));
		}
		public int Bin2Byte(byte[] bytes)
		{
			return (int)bytes[0];
		}
		public byte[] Byte2Bin(byte value)
		{
			return new byte[]{value};
		}
		public String BinToString(byte[] bytes)
		{
			String result="";
			for(int i=0;i<bytes.Length;i++)
			{
				result+=String.Concat(bytes[i]);
				if(i!=bytes.Length-1)
				{
					result+=",";
				}
			}
			return result;
		}
		public String ToIP(byte[] bytes)
		{
			String result="";
			for(int i=0;i<4;i++)
			{
				result+=String.Concat((int)bytes[i]);
				if(i!=3)
					result+=".";
			}
			return result;
		}
		public String Bin2Hex(byte[] bytes,bool realmode=false)
		{
			int temp_259=0;
			int temp_260=0;
			String temp_261="";
			String temp_262="";
			temp_259=bytes.Length;
			for(int i=0;i<temp_259;i++)
			{
				temp_260=i+1;
				temp_262=String.Format("{0:X}",bytes[temp_260-1]);
				if(temp_262.Length < 2)
				{
					temp_262="0"+temp_262;
				}
				temp_261+=temp_262;
				if(i!=temp_259-1)
						temp_261+=" ";
			}
			if(!realmode)
				temp_261+=" ";
			return temp_261;
		}
		public byte[] Hex2Bin2(String hex)
		{
			return Hex2Bin(hex);
		}
		public byte[] Hex2Bin(String hex)
		{
			String[] temp_264=new string[0];
			int temp_265=0;
			String temp_266="";
			int temp_267=0;
			byte[] temp_268=new byte[0];
			if(hex.Replace(" ","").Length%2!=0)
				throw new Exception("Invalid Hex String!");
			temp_264=hex.Split(' ');
			if(temp_264.Length==1)
			{
				hex=hex.Replace(" ","");
				for(int i=hex.Length-2;i>0;i-=2)
				{
					hex=hex.Insert(i," ");
				}
				temp_264=hex.Split(' ');
			}
			for(int i=0;i<temp_264.Length;i++)
			{
				temp_265=i+1;
				temp_266=temp_264[temp_265-1];
				temp_267=System.Int32.Parse(temp_266,System.Globalization.NumberStyles.HexNumber);
				Program.AppendToArray(ref temp_268,(byte)temp_267);
			}
			return temp_268;
		}
		public byte[] GetRandomBin(int len)
		{
			byte[] result=new byte[len];
			for(int i=0;i<len;i++)
			{
				int seed;
				unchecked{
				seed=(int)Program.timeobj.ElapsedTicks;
				}
				result[i]=(byte)new Random(seed).Next(0,255);
			}
			return result;
		}
	}
}
