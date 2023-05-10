/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/10
 * 时间: 21:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace QQ_C_
{
	/// <summary>
	/// Description of Android.
	/// </summary>
	public class Android
	{
		public QQ_Info qq=new QQ_Info();
		public QQ_Global _global=new QQ_Global();
		public int RequestId=0;
		public Socket tcp=null;
		public Exception last_error=new Exception("No Exception(Success)");
		public Tlv_ tlv=new Tlv_();
		public int pc_sub_cmd=0;
		public Android()
		{
		}
		public void Init(String user,String pass)
		{
			qq.Account=user;
			long luin=0;
			int iuin=0;
			luin=long.Parse(user);
			if(luin>2147483647)
			{
				qq.user=Program.getBytesRight(Program.Xbin.Long2Bin(luin),4);
			}else{
				unchecked{
					iuin=(int)luin;
				}
				qq.user=Program.Xbin.Int2Bin(iuin);
			}
			qq.QQ=long.Parse(user);
			qq.caption=System.Text.Encoding.Default.GetBytes(user);
			qq.pass=pass;
			qq.md5=MD5.Create().ComputeHash(System.Text.Encoding.Default.GetBytes(pass));
			byte[] temp=qq.md5;
			Program.AppendToArray(ref temp,new byte[]{0,0,0,0});
			Program.AppendToArray(ref temp,qq.user);
			qq.md52=MD5.Create().ComputeHash(temp);
			qq._ksid=Program.Xbin.Hex2Bin("93 AC 68 93 96 D5 7E 5F 94 96 B8 15 36 AA FE 91".Replace(" ",""));
			_global.imei="866819027236658";
			_global.ver=System.Text.Encoding.Default.GetBytes("5.8.0.157158");
			_global.appId=537042771;
			_global.pc_ver="1F 41";
			_global.os_type="android";
			_global.os_version="4.4.4";
			_global._network_type=2;
			_global._apn="wifi";
			_global.device="vivo X5Max+";
			_global._apk_id="com.tencent.mobileqq";
			_global._apk_v="5.8.0.157158";
			_global._apk_sig=Program.Xbin.Hex2Bin("A6 B7 45 BF 24 A2 C2 77 52 77 16 F6 F3 6E B6 8D".Replace(" ",""));
			_global.imei_=Program.Xbin.Hex2Bin("38 36 36 38 31 39 30 32 37 32 33 36 36 35 38".Replace(" ",""));
			RequestId=10000;
			qq.Token002C=new byte[0];
			qq.Token004C=new byte[0];
			qq.Token0058=new byte[0];
			qq.key=new byte[16];
		}
		public byte[] Pack_Login()
		{
			_Pack pack=new _Pack();
			byte[] bin=new byte[0];
			byte[] tmp=new byte[0];
			byte[] wupBuffer=new byte[0];
			byte[] tlv109=new byte[0];
			byte[] tlv124=new byte[0];
			byte[] tlv128=new byte[0];
			byte[] tlv16e=new byte[0];
			qq.shareKey=Program.Xbin.Hex2Bin("957C3AAFBF6FAF1D2C2F19A5EA04E51C".Replace(" ",""));
			qq.pub_key=Program.Xbin.Hex2Bin("02244B79F2239755E73C73FF583D4EC5625C19BF8095446DE1".Replace(" ",""));
			qq.TGTKey=Program.Xbin.GetRandomBin(16);
			qq.time=Program.Xbin.Flip(Program.getBytesRight(Program.Xbin.Long2Bin(Program.Other.TimeStamp()),4));
			qq.randKey=Program.Xbin.GetRandomBin(16);
			if(Program.LogFile!=null)
			{
				Program.Log(System.Text.Encoding.Default.GetBytes("TGTKey "+Program.Xbin.Bin2Hex(qq.TGTKey)));
				Program.Log(System.Text.Encoding.Default.GetBytes("randKey "+Program.Xbin.Bin2Hex(qq.randKey)));
			}
			pack.Empty();
			pack.SetHex("00 09");
			pack.SetShort(19);
			pack.SetBin(tlv.tlv18(qq.user));
			qq.time=Program.Xbin.Hex2Bin("5C D8 2A CE");
			pack.SetBin(tlv.tlv1(qq.user,qq.time));
			Clipboard.SetText(Program.Xbin.Bin2Hex(pack.GetAll()));
			MessageBox.Show(Program.Xbin.Bin2Hex(pack.GetAll()));
			pack.SetBin(tlv.tlv106(qq.user,qq.md5,qq.md52,qq.TGTKey,_global.imei_,qq.time,_global.appId));
			pack.SetBin(tlv.tlv116());
			pack.SetBin(tlv.tlv100(_global.appId));
			pack.SetBin(tlv.tlv107());
			pack.SetBin(tlv.tlv108(qq._ksid));
			tlv109=tlv.tlv109(_global.imei_);
			tlv124=tlv.tlv124(_global.os_type,_global.os_version,_global._network_type,_global._apn);
			tlv128=tlv.tlv128(_global.device,_global.imei_);
			tlv16e=tlv.tlv16e(_global.device);
			pack.SetBin(tlv.tlv144(qq.TGTKey,tlv109,tlv124,tlv128,tlv16e));
			pack.SetBin(tlv.tlv142(_global._apk_id));
			pack.SetBin(tlv.tlv145(_global.imei_));
			pack.SetBin(tlv.tlv154(RequestId));
			pack.SetBin(tlv.tlv141(_global._network_type,_global._apn));
			pack.SetBin(tlv.tlv8());
			pack.SetBin(tlv.tlv16b());
			pack.SetBin(tlv.tlv147(_global._apk_v,_global._apk_sig));
			pack.SetBin(tlv.tlv177());
			pack.SetBin(tlv.tlv187());
			pack.SetBin(tlv.tlv188());
			pack.SetBin(tlv.tlv191());
			wupBuffer=pack.GetAll();
			wupBuffer=Pack_Pc("08 10",Program.Hash.QQTEA(wupBuffer,qq.shareKey),qq.randKey,qq.pub_key);
			return Make_login_sendSsoMsg("wtlogin.login",wupBuffer,new byte[0],_global.imei,qq._ksid,_global.ver,true);
		}
		public byte[] Make_login_sendSsoMsg(String serviceCmd,byte[] wupBuffer,byte[] ext_bin,String imei,byte[] ksid,byte[] ver,bool isLogin)
		{
			_Pack pack=new _Pack();
			byte[] msgCookies=new byte[0];
			byte[] tmp=new byte[0];
			msgCookies=Program.Xbin.Hex2Bin("B6 CC 78 FC".Replace(" ",""));
			pack.Empty();
			pack.SetInt(RequestId);
			pack.SetInt(_global.appId);
			pack.SetInt(_global.appId);
			pack.SetHex("01 00 00 00 00 00 00 00 00 00 00 00");
			pack.SetInt(ext_bin.Length+4);
			pack.SetBin(ext_bin);
			pack.SetInt(serviceCmd.Length+4);
			pack.SetBin(Program.StringToBytes(serviceCmd));
			pack.SetInt(msgCookies.Length+4);
			pack.SetBin(msgCookies);
			pack.SetInt(imei.Length+4);
			pack.SetBin(Program.StringToBytes(imei));
			pack.SetInt(ksid.Length+4);
			pack.SetBin(ksid);
			unchecked{
				pack.SetShort((short)(ver.Length+2));
			}
			pack.SetBin(ver);
			tmp=pack.GetAll();
			pack.Empty();
			pack.SetInt(tmp.Length+4);
			pack.SetBin(tmp);
			tmp=pack.GetAll();
			pack.Empty();
			pack.SetBin(tmp);
			pack.SetInt(wupBuffer.Length+4);
			pack.SetBin(wupBuffer);
			return Pack(Program.Hash.QQTEA(pack.GetAll(),qq.key),isLogin?0:1);
		}
		public byte[] Pack(byte[] bin,int type)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			if(type==0)
			{
				pack.SetHex("00 00 00 08 02 00 00 00 04");
			}else{
				if(type==1)
				{
					pack.SetHex("00 00 00 08 01 00 00");
					unchecked{
						pack.SetShort((short)(qq.Token002C.Length+4));
					}
					pack.SetBin(qq.Token002C);
				}else{
					pack.SetHex("00 00 00 09 01");
					pack.SetInt(RequestId);
				}
			}
			pack.SetHex("00 00 00");
			unchecked{
				pack.SetShort((short)(qq.caption.Length+4));
			}
			pack.SetBin(qq.caption);
			pack.SetBin(bin);
			bin=pack.GetAll();
			pack.Empty();
			pack.SetInt(bin.Length+4);
			pack.SetBin(bin);
			bin=pack.GetAll();
			return bin;
		}
		public int getSubCmd()
		{
			if(pc_sub_cmd>2147483647)
			{
				pc_sub_cmd=0;
			}
			pc_sub_cmd++;
			return pc_sub_cmd;
		}
		public byte[] Pack_Pc(String cmd,byte[] bin,byte[] ext_key=null,byte[] ext_bin=null)
		{
			_Pack pack=new _Pack();
			bool ext_bin_null=false;
			byte[] tmp=new byte[0];
			pack.Empty();
			pack.SetHex(_global.pc_ver);
			pack.SetHex(cmd);
			unchecked{
				pack.SetShort((short)getSubCmd());
			}
			pack.SetBin(qq.user);
			pack.SetHex("03 07 00 00 00 00 02 00 00 00 00 00 00 00 00");
			if(ext_bin!=null && ext_bin.Length>0)
			{
				ext_bin_null=false;
				pack.SetHex("01 01");
			}else{
				ext_bin_null=true;
				pack.SetHex("01 02");
			}
			pack.SetBin(ext_key);
			pack.SetHex("01 02");
			unchecked{
				pack.SetShort((short)ext_bin.Length);
			}
			if(ext_bin_null)
			{
				pack.SetHex("00 00");
			}else{
				pack.SetBin(ext_bin);
			}
			pack.SetBin(bin);
			pack.SetHex("03");
			tmp=pack.GetAll();
			pack.Empty();
			pack.SetHex("02");
			unchecked{
				pack.SetShort((short)(tmp.Length+3));
			}
			pack.SetBin(tmp);
			tmp=pack.GetAll();
			return tmp;
		}
		public void increase_ssoSeq()
		{
			if(RequestId>2147483647)
			{
				RequestId=10000;
			}
			RequestId++;
		}
		public byte[] Fun_send(byte[] bin,int receivewait=0,int sendwait=3000,bool read=true)
		{
			increase_ssoSeq();
			tcp.Blocking=true;
			tcp.SendTimeout=sendwait;
			tcp.Send(bin);
			Program.Log("Send Packet: "+Program.Xbin.Bin2Hex(bin));
			if(read)
			{
				byte[] result=new byte[0];
				do{
			byte[] temp=new byte[1];
			tcp.ReceiveTimeout=receivewait;
			int available=0;
			try{
				available=tcp.Receive(temp);
			}catch(Exception){available=0;}
			temp=Program.getBytesLeft(temp,available);
			Program.AppendToArray(ref result,temp);
				}while(tcp.Available!=0);
			return result;
			}else{
				return new byte[0];
			}
		}
		public byte[] Un_pack(byte[] bin,bool _bool=false)
		{
			int pos1=0;
			pos1=Program.ByteIndexOf(bin,qq.caption);
			bin=Program.getBytesRight(bin,bin.Length-pos1-qq.caption.Length+1);
			if(_bool)
			{
				pos1=Program.ByteIndexOf(bin,qq.caption);
				bin=Program.getBytesRight(bin,bin.Length-pos1-qq.caption.Length+1);
			}
			return bin;
		}
		public byte[] Un_Pack_Login_Pc(byte[] bin)
		{
			_Unpack unPack=new _Unpack();
			int len=0;
			int result=0;
			unPack.SetData(bin);
			len=unPack.GetInt();
			bin=unPack.GetAll();
			unPack.SetData(bin);
			unPack.GetByte();
			len=unPack.GetShort();
			unPack.GetBin(10);
			unPack.GetBin(2);
			result=unPack.GetByte();
			bin=unPack.GetBin(len-16-1);
			bin=Program.Hash.UNQQTEA(bin,qq.shareKey);
			if(result!=0)
			{
				if(result==2)
				{
					//Un_Pack_VieryImage(bin);
					last_error=new Exception("需要输入验证码!");
					qq.loginState=Login_State.verify;
					return new byte[0];
				}
				//Un_Pack_ErrMsg(bin);
				bin=new byte[0];
				qq.loginState=Login_State.logining;
			}
			return bin;
		}
		public void tlv_get(String tlv_cmd,byte[] bin)
		{
			_Unpack unPack=new _Unpack();
			int len=0;
			short face=0;
			byte age=new byte();
			byte gander=new byte();
			int i=0;
			int flag=0;
			int time=0;
			String ip="";
			unPack.SetData(bin);
			if(tlv_cmd=="01 6A")
			{
				
			}else if(tlv_cmd=="01 06")
			{
				
			}else if(tlv_cmd=="01 0C")
			{
				
			}else if(tlv_cmd=="01 0A")
			{
				qq.Token004C=bin;
			}else if(tlv_cmd=="01 0D")
			{
				
			}else if(tlv_cmd=="01 14")
			{
				qq.Token0058=tlv.tlv114_get0058(bin);
			}else if(tlv_cmd =="01 0E")
			{
				qq.mST1Key=bin;
			}else if(tlv_cmd=="01 03")
			{
				qq.stweb=Program.Xbin.Bin2Hex(bin,true).Replace(" ","");
			}else if(tlv_cmd=="01 1F")
			{
				
			}else if(tlv_cmd=="01 38")
			{
				len=unPack.GetInt();
				for(int i2=0;i<len;i2++)
				{
					i=i2+1;
					flag=unPack.GetShort();
					time=unPack.GetInt();
					unPack.GetInt();
				}
			}else if(tlv_cmd=="01 1A")
			{
				face=unPack.GetShort();
				age=unPack.GetByte();
				gander=unPack.GetByte();
				len=unPack.GetByte();
				byte[] temp=unPack.GetBin(len);
				Program.AppendToArray(ref temp,new byte[]{0});
				qq.nick=System.Text.Encoding.UTF8.GetString(temp);
				Program.Log("昵称: "+qq.nick+" face: "+face+" age: "+age+" gander: "+gander);
			}else if(tlv_cmd=="01 20")
			{
				qq.skey=bin;
			}else if(tlv_cmd=="01 36")
			{
				qq.vkey=bin;
			}else if(tlv_cmd=="01 1A")
			{
				
			}else if(tlv_cmd=="01 20")
			{
				
			}else if(tlv_cmd=="01 36")
			{
				
			}else if(tlv_cmd=="03 05")
			{
				qq.sessionKey=bin;
			}else if(tlv_cmd=="01 43")
			{
				qq.Token002C=bin;
			}else if(tlv_cmd=="01 64")
			{
				qq.sid=bin;
			}else if(tlv_cmd=="01 18")
			{
				
			}else if(tlv_cmd=="01 63")
			{
				
			}else if(tlv_cmd=="01 30")
			{
				unPack.GetShort();
				time=unPack.GetInt();
				ip=Program.Xbin.ToIP(unPack.GetBin(4));
			}else if(tlv_cmd=="01 05")
			{
				len=unPack.GetShort();
				qq.VieryToken1=unPack.GetBin(len);
				len=unPack.GetShort();
				qq.Viery=unPack.GetBin(len);
			}else if(tlv_cmd=="01 04")
			{
				qq.VieryToken2=bin;
			}else if(tlv_cmd=="01 65")
			{
				
			}else if(tlv_cmd=="01 08")
			{
				
			}else if(tlv_cmd=="01 6D")
			{
				qq.superkey=bin;
			}else if(tlv_cmd=="01 6C")
			{
				qq.pskey=bin;
			}else{
				Program.Log("Unknown tlv_cmd: "+tlv_cmd+" data: "+Program.Xbin.Bin2Hex(bin,true));
			}
		}
		public void Un_Tlv(byte[] bin)
		{
			_Unpack unPack=new _Unpack();
			int tlv_count=0;
			byte[] tlv_cmd=new byte[0];
			int tlv_len=0;
			unPack.SetData(bin);
			tlv_count=unPack.GetShort();
			for(int i=0;i<tlv_count;i++)
			{
				tlv_cmd=unPack.GetBin(2);
				tlv_len=unPack.GetShort();
				tlv_get(Program.DeleteLastSpace(Program.Xbin.Bin2Hex(tlv_cmd,true)),unPack.GetBin(tlv_len));
			}
		}
		public bool Un_Pack_Login(byte[] bin)
		{
			int len=0;
			_Unpack unPack=new _Unpack();
			byte[] _0030=new byte[0];
			bin=Un_Pack_Login_Pc(bin);
			if(bin.Length==0)
			{
				return false;
			}
			unPack.SetData(bin);
			unPack.GetShort();
			unPack.GetByte();
			unPack.GetInt();
			len=unPack.GetShort();
			bin=unPack.GetBin(len);
			bin=Program.Hash.UNQQTEA(bin,qq.TGTKey);
			Un_Tlv(bin);
			qq.key=qq.sessionKey;
			Program.Log("sessionKey: "+Program.Xbin.Bin2Hex(qq.sessionKey));
			Program.Log("skey: "+Program.BytesToString(qq.skey));
			Program.Log("sid: "+Program.BytesToString(qq.sid));
			Program.Log("stweb: "+qq.stweb.Replace(" ",""));
			Program.Log("vkey: "+Program.BytesToString(qq.vkey));
			qq.loginState=Login_State.success;
			return true;
		}
		public void Fun_recv(byte[] data)
		{
			byte[] bin=new byte[0];
			//bool _bool=false;
			byte[] test=new byte[0];
			_Unpack unPack=new _Unpack();
			int sso_seq=0;
			int len=0;
			String serviceCmd="";
			int head_len=0;
			byte[] body_bin=new byte[0];
			if(data.Length==0)
			{
				return;
			}
			//System.Windows.Forms.Clipboard.SetText(Program.Xbin.Bin2Hex(bin));
			//System.Windows.Forms.MessageBox.Show("ok1");
			bin=Un_pack(data);
			////System.Windows.Forms.Clipboard.SetText(Program.Xbin.Bin2Hex(bin));
			System.Windows.Forms.MessageBox.Show("ok2");
			bin=Program.Hash.UNQQTEA(bin,qq.key);
			//System.Windows.Forms.Clipboard.SetText(Program.Xbin.Bin2Hex(bin));
			//System.Windows.Forms.MessageBox.Show("ok3");
			len=bin.Length;
			unPack.SetData(bin);
			head_len=unPack.GetInt();
			//System.Windows.Forms.MessageBox.Show(head_len+"");
			bin=unPack.GetBin(head_len-4);
			body_bin=unPack.GetAll();
			unPack.SetData(bin);
			sso_seq=unPack.GetInt();
			if(unPack.GetBin(4)==new byte[]{0,0,0,0})
			{
				unPack.GetBin(4);
			}else{
				unPack.GetBin(unPack.GetInt()-4);
			}
			serviceCmd=String.Concat(unPack.GetBin(unPack.GetInt()-4));
			MessageBox.Show(serviceCmd);
			if(serviceCmd=="wtlogin.login")
			{
				Un_Pack_Login(body_bin);
			}else{
				//Fun_Msg_Handle(sso_seq,serviceCmd,body_bin);
			}
		}
		public Login_State Fun_Login()
		{
			byte[] bin=new byte[0];
			if(tcp!=null && tcp.Connected)
				tcp.Disconnect(true);
			if(tcp==null)
				tcp=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
			qq.loginState=Login_State.logining;
			try{
			tcp.Connect(new IPEndPoint(Dns.GetHostAddresses("msfwifi.3g.qq.com")[0],8080));
			}catch(Exception e){last_error=new Exception("无法连接服务器!",e);return qq.loginState;}
			bin=Fun_send(Pack_Login(),3000);
			if(bin.Length==0)
			{
				last_error=new Exception("登录返回包为空!");
				return qq.loginState;
			}
			Fun_recv(bin);
			return qq.loginState;
		}
	}
}
