using System.Windows;
using System.Windows.Media;
using System.Media;
namespace LichNhac;
public partial class MainWindow : Window
{
 public MainWindow() => InitializeComponent();
 private void Customize_Click(object sender, RoutedEventArgs e) { CharacterName.Text = CharacterName.Text.StartsWith("Mochi") ? "Luna • Cáo đêm" : "Mochi • Mèo mây"; CharacterFace.Text = CharacterFace.Text == "◕‿◕" ? "◠ᴥ◠" : "◕‿◕"; }
 private void Test_Click(object sender, RoutedEventArgs e) { MessageBox.Show("Mochi nhắc bạn:\n\n14:30 • Họp nhóm thiết kế", "Lịch Nhắc", MessageBoxButton.OK, MessageBoxImage.Information); if (SoundToggle.IsChecked == true) SystemSounds.Asterisk.Play(); }
 private void Connect_Click(object sender, RoutedEventArgs e) { ConnectionStatus.Text = "Đã kết nối • Google Calendar (demo OAuth)"; ConnectionStatus.Foreground = new SolidColorBrush(Color.FromRgb(5,150,105)); ConnectButton.Content = "Đã kết nối"; }
}
