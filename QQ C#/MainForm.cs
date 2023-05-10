/*
 * 由SharpDevelop创建。
 * 用户： 吕易天
 * 日期: 2019/5/10
 * 时间: 21:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QQ_C_
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public Android sdk=new Android();
		public String LastText="";
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			Program.Log("Login Form Loaded!");
		}
		void Button1Click(object sender, EventArgs e)
		{
			sdk.Init(textBox1.Text,textBox2.Text);
			Login_State state=sdk.Fun_Login();
			if(state==Login_State.success)
			{
				MessageBox.Show("1");
			}else{
				MessageBox.Show(String.Concat(state));
				MessageBox.Show(sdk.last_error.ToString());
			}
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			try{
			textBox1.Text=String.Concat(Int64.Parse(textBox1.Text));
			LastText=textBox1.Text;
			}catch(Exception){if(textBox1.Text!=""){int temp=textBox1.SelectionStart;textBox1.Text=LastText;textBox1.SelectionStart=temp-1;}else{LastText=textBox1.Text;}}
		}
	}
}
