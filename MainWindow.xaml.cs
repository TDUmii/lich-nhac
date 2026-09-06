using System.Media;
using System.Windows;
using System.Windows.Media;
namespace LichNhac;
public partial class MainWindow : Window
{
 public MainWindow() => InitializeComponent();
 private void Customize_Click(object sender, RoutedEventArgs e) { CharacterName.Text = CharacterName.Text.StartsWith("Mochi") ? "Luna • Cáo đêm" : "Mochi • Mèo mây"; CharacterFace.Text = CharacterFace.Text == "◕‿◕" ? "◠ᴥ◠" : "◕‿◕"; }
 private void Test_Click(object sender, RoutedEventArgs e) { var seconds = int.TryParse(DurationBox.Text, out var value) ? Math.Clamp(value, 3, 120) : 8; DurationBox.Text = seconds.ToString(); new ReminderWindow("Mochi", "14:30 • Họp nhóm thiết kế", seconds).Show(); if (SoundToggle.IsChecked == true) SystemSounds.Asterisk.Play(); }
 private void Connect_Click(object sender, RoutedEventArgs e) { ConnectionStatus.Text = "Đã kết nối • Google Calendar (demo OAuth)"; ConnectionStatus.Foreground = new SolidColorBrush(Color.FromRgb(5,150,105)); ConnectButton.Content = "Đã kết nối"; }
}
