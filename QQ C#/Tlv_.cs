/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/11
 * 时间: 6:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Windows.Forms;

namespace QQ_C_
{
	/// <summary>
	/// Description of Tlv_.
	/// </summary>
	public class Tlv_
	{
		public Tlv_()
		{
		}
		public byte[] tlv_pack(String cmd,byte[] bin)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex(cmd);
			unchecked{
			pack.SetShort((short)bin.Length);
			}
			pack.SetBin(bin);
			return pack.GetAll();
		}
		public byte[] tlv18(byte[] user)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00 01");
			pack.SetHex("00 00 06 00");
			pack.SetHex("00 00 00 10");
			pack.SetHex("00 00 00 00");
			pack.SetBin(user);
			pack.SetHex("00 00");
			pack.SetHex("00 00");
			return tlv_pack("00 18",pack.GetAll());
		}
		public byte[] tlv1(byte[] user,byte[] time)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00 01");
			pack.SetBin(Program.Xbin.GetRandomBin(4));
			pack.SetBin(user);
			pack.SetBin(time);
			pack.SetHex("00 00 00 00");
			pack.SetHex("00 00");
			return tlv_pack("00 01",pack.GetAll());
		}
		public byte[] tlv2(String code,byte[] VieryToken1)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetInt(code.Length);
			pack.SetBin(System.Text.Encoding.Default.GetBytes(code));
			unchecked{
			pack.SetShort((short)VieryToken1.Length);	
			}
			pack.SetBin(VieryToken1);
			return tlv_pack("00 02",pack.GetAll());
		}
		public byte[] tlv106(byte[] user,byte[] md5pass,byte[] md52pass,byte[] _TGTKey,byte[] imei_,byte[] time,int appId)
		{
			_Pack pack=new _Pack();
			pack.SetHex("00 03");
			pack.SetBin(Program.Xbin.GetRandomBin(4));
			pack.SetHex("00 00 00 05");
			pack.SetHex("00 00 00 10");
			pack.SetHex("00 00 00 00");
			pack.SetHex("00 00 00 00");
			pack.SetBin(user);
			pack.SetBin(time);
			pack.SetHex("00 00 00 00 01");
			pack.SetBin(md5pass);
			pack.SetBin(_TGTKey);
			pack.SetHex("00 00 00 00");
			pack.SetHex("01");
			pack.SetBin(imei_);
			pack.SetInt(appId);
			pack.SetHex("00 00 00 01");
			pack.SetHex("00 00");
			return tlv_pack("01 06",Program.Hash.QQTEA(pack.GetAll(),md52pass));
		}
		public byte[] tlv116()
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00");
			pack.SetHex("00 00 7F 7C");
			pack.SetHex("00 01 04 00");
			pack.SetHex("00");
			return tlv_pack("01 16",pack.GetAll());
		}
		public byte[] tlv100(int appId)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00 01");
			pack.SetHex("00 00 00 05");
			pack.SetHex("00 00 00 10");
			pack.SetInt(appId);
			pack.SetHex("00 00 00 00");
			pack.SetHex("00 0E 10 E0");
			return tlv_pack("01 00",pack.GetAll());
		}
		public byte[] tlv104(byte[] VieryToken2)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetBin(VieryToken2);
			return tlv_pack("01 04",pack.GetAll());
		}
		public byte[] tlv107()
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00 00");
			pack.SetHex("00");
			pack.SetHex("00 00");
			pack.SetHex("01");
			return tlv_pack("01 07",pack.GetAll());
		}
		public byte[] tlv108(byte[] _ksid)
		{
			_ksid=new byte[0];
			return tlv_pack("01 08",_ksid);
		}
		public byte[] tlv144(byte[] TGTKey,byte[] tlv109,byte[] tlv124,byte[] tlv128,byte[] tlv16e)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetShort(4);
			pack.SetBin(tlv109);
			pack.SetBin(tlv124);
			pack.SetBin(tlv128);
			pack.SetBin(tlv16e);
			return tlv_pack("01 44",Program.Hash.QQTEA(pack.GetAll(),TGTKey));
		}
		public byte[] tlv109(byte[] imei_)
		{
			return tlv_pack("01 09",imei_);
		}
		public byte[] tlv124(String os_type,String os_version,int _network_type,String _apn)
		{
			_Pack pack=new _Pack();
			unchecked{
			pack.SetShort((short)os_type.Length);
			}
			pack.SetStr(os_type);
			unchecked{
				pack.SetShort((short)os_version.Length);
			}
			pack.SetStr(os_version);
			unchecked{
			pack.SetShort((short)_network_type);	
			}
			pack.SetHex("00 00");
			pack.SetHex("00 00");
			unchecked{
				pack.SetShort((short)_apn.Length);
			}
			pack.SetStr(_apn);
			return tlv_pack("01 24",pack.GetAll());
		}
		public byte[] tlv128(String _device,byte[] imei_)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00 00");
			pack.SetHex("00");
			pack.SetHex("01");
			pack.SetHex("01");
			pack.SetHex("01 00 02 00");
			unchecked{
				pack.SetShort((short)_device.Length);
			}
			pack.SetStr(_device);
			unchecked{
				pack.SetShort((short)imei_.Length);
			}
			pack.SetBin(imei_);
			pack.SetHex("00 00");
			return tlv_pack("01 28",pack.GetAll());
		}
		public byte[] tlv16e(String _device)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetStr(_device);
			return tlv_pack("01 6E",pack.GetAll());
		}
		public byte[] tlv142(String _apk_id)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetInt(Program.StringToBytes(_apk_id).Length);
			pack.SetBin(Program.StringToBytes(_apk_id));
			return tlv_pack("01 42",pack.GetAll());
		}
		public byte[] tlv154(int _sso_seq)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetInt(_sso_seq);
			return tlv_pack("01 54",pack.GetAll());
		}
		public byte[] tlv145(byte[] imei_)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetBin(imei_);
			return tlv_pack("01 45",pack.GetAll());
		}
		public byte[] tlv141(int _network_type,String _apn)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00 01");
			pack.SetHex("00 00");
			unchecked{
			pack.SetShort((short)_network_type);
			}
			unchecked{
				pack.SetShort((short)_apn.Length);
			}
			pack.SetStr(_apn);
			return tlv_pack("01 41",pack.GetAll());
		}
		public byte[] tlv8()
		{
			_Pack pack=new _Pack();
			pack.SetHex("00 00");
			pack.SetHex("00 00 08 04");
			pack.SetHex("00 00");
			return tlv_pack("00 08",pack.GetAll());
		}
		public byte[] tlv16b()
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00 01");
			pack.SetHex("00 0B");
			pack.SetHex("67 61 6D 65 2E 71 71 2E 63 6F 6D");
			return tlv_pack("01 6B",pack.GetAll());
		}
		public byte[] tlv147(String _apk_v,byte[] _apk_sig)
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00 00 00 10");
			unchecked{
				pack.SetShort((short)_apk_v.Length);
			}
			pack.SetStr(_apk_v);
			unchecked{
				pack.SetShort((short)_apk_sig.Length);
			}
			pack.SetBin(_apk_sig);
			return tlv_pack("01 47",pack.GetAll());
		}
		public byte[] tlv177()
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("01");
			pack.SetHex("53 FB 17 9B");
			pack.SetHex("00 07");
			pack.SetHex("35 2E 32 2E 33 2E 30");
			return tlv_pack("01 77",pack.GetAll());
		}
		public byte[] tlv114_get0058(byte[] bin)
		{
			_Unpack unPack=new _Unpack();
			int len=0;
			unPack.SetData(bin);
			unPack.GetBin(6);
			len=unPack.GetShort();
			if(len!=88)
			{
				Program.Log("error tlv_114_get0058 len!=0058");
			}
			return unPack.GetBin(len);
		}
		public byte[] tlv187()
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("F8 FF 12 23 6E 0D AF 24 97 CE 7E D6 A0 7B DD 68");
			return tlv_pack("01 87",pack.GetAll());
		}
		public byte[] tlv188()
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("4D BF 65 33 D9 08 C2 73 63 6D E5 CD AE 83 C0 43");
			return tlv_pack("01 88",pack.GetAll());
		}
		public byte[] tlv191()
		{
			_Pack pack=new _Pack();
			pack.Empty();
			pack.SetHex("00");
			return tlv_pack("01 91",pack.GetAll());
		}
	}
}
