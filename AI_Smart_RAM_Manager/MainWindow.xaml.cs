using System;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace AI_Smart_RAM_Manager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private MediaPlayer myMediaPlayer = new MediaPlayer();
        public MainWindow()
		{
			InitializeComponent();
			ListPrograms();
        }

		private void reloadButtonClick(object sender, RoutedEventArgs e)
		{
			ListPrograms();
		}

		private void killButtonClick(object sender, RoutedEventArgs e) 
		{
			if (programsList.SelectedItem != null)
			{
				Process selectedProcess = (Process)programsList.SelectedItem;

				try
				{
					selectedProcess.Kill();
					programsList.Items.Remove(selectedProcess);
					MessageBox.Show($"Program '{selectedProcess.ProcessName}' kapatıldı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Program kapatılamadı: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

			else
			{
				MessageBox.Show("Lütfen bir program seçin.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		private void ListPrograms()
		{
			programsList.Items.Clear();

			Process[] runningExecutables = Process.GetProcesses();

			foreach (Process process in runningExecutables) 
			{
				if(!string.IsNullOrEmpty(process.MainWindowTitle))
				{
					programsList.Items.Add(process);
				}
			}
		}
    }
}