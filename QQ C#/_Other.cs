/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 2:24
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Runtime.InteropServices;

namespace QQ_C_
{
	/// <summary>
	/// Description of _Other.
	/// </summary>
	public class _Other
	{
		public _Other()
		{
		}
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="GetSystemTimeAsFileTime")]
		public extern static int GetSystemTimeAsFileTime_525(ref Type_514 temp_531);
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="FileTimeToLocalFileTime")]
		public extern static bool FileTimeToLocalFileTime_526(ref Type_514 temp_532,ref Type_514 temp_533);
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="FileTimeToSystemTime")]
		public extern static bool FileTimeToSystemTime_527(ref Type_514 temp_534,ref Type_513 temp_535);
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="CreateWaitableTimerA")]
		public extern static int CreateWaitableTimerA_1626(int temp_1630,bool temp_1631,int temp_1632);
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="SetWaitableTimer")]
		public extern static bool SetWaitableTimer_1635(int temp_1638,ref Type_1653 temp_1639,int temp_1640,int temp_1641,int temp_1642,bool temp_1643);
		[DllImport("user32.dll",SetLastError=true,EntryPoint="MsgWaitForMultipleObjects")]
		public extern static int MsgWaitForMultipleObjects(int nCount,int pHandles,bool fWaitAll,int dwMilliseconds,int dwWakeMask);
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="CloseHandle")]
		public extern static bool CloseHandle(int hObject);
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="SystemTimeToFileTime")]
		public extern static bool SystemTimeToFileTime_528(ref Type_513 temp_536,ref Type_514 temp_537);
		[DllImport("kernel32.dll",SetLastError=true,EntryPoint="LocalFileTimeToFileTime")]
		public extern static bool LocalFileTimeToFileTime_530(ref Type_514 temp_539,ref Type_514 temp_540);
		public long TimeStamp(bool million=false)
		{
			long temp_552=0;
			Type_514 temp_553=new Type_514();
			GetSystemTimeAsFileTime_525(ref temp_553);
			temp_552=FileTimeToUnixTime(temp_553.member_523);
			if(million)
			{
				temp_552/=10000;
			}else{
				temp_552/=10000000;
			}
			return temp_552;
		}
		public long FileTimeToUnixTime(long temp_575)
		{
			long temp_576=0;
			temp_576=temp_575-(long)(1.16444736e+017);
			return temp_576;
		}
		public DateTime UnixTimeToTime(long unix,bool local=true)
		{
			Type_513 temp_556=new Type_513();
			DateTime temp_557=new DateTime();
			bool temp_558=false;
			temp_558=local;
			temp_556=UnixTimeToSystemTime(unix,temp_558);
			temp_557=new DateTime(temp_556.member_515,temp_556.member_516,temp_556.member_518,temp_556.member_519,temp_556.member_520,temp_556.member_521);
			return temp_557;
		}
		public Type_513 UnixTimeToSystemTime(long temp_559,bool temp_560=true)
		{
			Type_514 temp_561=new Type_514();
			Type_513 temp_562=new Type_513();
			temp_561.member_523=UnixTimeToFileTime(temp_559);
			if(temp_560)
			{
				FileTimeToLocalFileTime_526(ref temp_561,ref temp_561);
			}
			FileTimeToSystemTime_527(ref temp_561,ref temp_562);
			return temp_562;
		}
		public long UnixTimeToFileTime(long temp_571)
		{
			long temp_572=0;
			int temp_573=0;
			int temp_574=0;
			temp_573=getIntCount(temp_571);
			temp_574=1;
			for(int i=0;i<17-temp_573;i++)
			{
				temp_574*=10;
			}
			temp_572=temp_571*temp_574+(long)(1.16444736e+017);
			return temp_572;
		}
		public int getIntCount(long temp_577)
		{
			int temp_578=0;
			long temp_579=0;
			temp_579=temp_577;
			temp_578=1;
			do
			{
				temp_579/=10;
				if(temp_579>=1)
				{
					temp_578++;
				}else{
					break;
				}
			}while(temp_579>=1);
			return temp_578;
		}
		public bool Wait(int time=-1,int min=0)
		{
			int temp_1617=0;
			Type_1653 temp_1618=new Type_1653();
			if(time<0)
			{
				min=2147483647;
			}else if(min==0)
			{
				min=1;
			}else if(min==1)
			{
				min=1000;
			}else if(min==2)
			{
				min=1000*60;
			}else if(min==3)
			{
				min=1000*60*60;
			}else{
				min=1;
			}
			if(time<0)
			{
				temp_1618.member_1654=-2147483647;
			}else{
			    temp_1618.member_1654=-10*time*1000*min;
			}
			temp_1617=CreateWaitableTimerA_1626(0,false,0);
			SetWaitableTimer_1635(temp_1617,ref temp_1618,0,0,0,false);
			while(MsgWaitForMultipleObjects(1,temp_1617,false,-1,255)!=0)
			{
				Program.FastHandleEvents();
			}
			CloseHandle(temp_1617);
			return true;
		}
		public String FormatTime(DateTime Time)
		{
			return Time.ToString();
		}
		public long TimeToTimeStamp(DateTime temp_563,bool temp_564=default(bool))
		{
			Type_513 temp_565=new Type_513();
			long temp_566=0;
			unchecked{
			temp_565.member_515=(short)temp_563.Year;
			temp_565.member_516=(short)temp_563.Month;
			temp_565.member_518=(short)temp_563.Day;
			temp_565.member_519=(short)temp_563.Hour;
			temp_565.member_520=(short)temp_563.Minute;
			temp_565.member_521=(short)temp_563.Second;
			temp_565.member_517=(short)temp_563.DayOfWeek;
			}
			temp_566=SystemTimeToTimeStamp(temp_565,temp_564);
			return temp_566;
		}
		public long SystemTimeToTimeStamp(Type_513 temp_567,bool temp_568=default(bool))
		{
			Type_514 temp_569=new Type_514();
			long temp_570=0;
			SystemTimeToFileTime_528(ref temp_567,ref temp_569);
			LocalFileTimeToFileTime_530(ref temp_569,ref temp_569);
			temp_570=FileTimeToUnixTime(temp_569.member_523);
			if(temp_568)
			{
				temp_570/=10000;
			}else{
				temp_570/=10000000;
			}
			return temp_570;
		}
	}
}
