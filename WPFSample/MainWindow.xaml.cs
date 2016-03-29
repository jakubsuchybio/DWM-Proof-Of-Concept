using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DWMUtils;

namespace WPFSample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		IntPtr DWMHandle;

		public MainWindow()
		{
			InitializeComponent();
			var windows = Utils.LoadWindows();
			comboBox.ItemsSource = windows.Select( x => $"{x.Key};{x.Value}" ).ToArray();
		}

		void comboBox_SelectionChanged( object sender, SelectionChangedEventArgs e )
		{
			var cb = sender as ComboBox;
			var thisHandle = new WindowInteropHelper( this ).Handle;
			var handle = new IntPtr(int.Parse(cb.SelectedItem.ToString().Split(';')[0]));
			var rect = new DWMUtils.Rect(0,0,(int)this.Width,(int)this.Height);
			DWMHandle = Utils.CreateThumbnail( thisHandle, handle, DWMHandle, rect );
		}
	}
}
