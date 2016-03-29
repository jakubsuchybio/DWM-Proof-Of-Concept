using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWMUtils;

namespace WinFormsSample
{
	public partial class Form1 : Form
	{
		IntPtr DWMHandle;

		public Form1()
		{
			InitializeComponent();
			var windows = Utils.LoadWindows();
			comboBox.Items.AddRange( windows.Select( x => $"{x.Key};{x.Value}" ).ToArray() );
			DWMHandle = IntPtr.Zero;
		}

		void comboBox_SelectedIndexChanged( object sender, EventArgs e )
		{
			var cb = sender as ComboBox;
			var handle = new IntPtr(int.Parse(cb.SelectedItem.ToString().Split(';')[0]));
			var rect = new Rect(0,0,this.Width,this.Height);
			DWMHandle = Utils.CreateThumbnail( this.Handle, handle, DWMHandle, rect );
		}
	}
}
