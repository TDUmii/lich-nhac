using System.Media; using System.Windows; using System.Windows.Media; using System.Windows.Media.Imaging;
namespace LichNhac;
public partial class MainWindow : Window
{
 private string _asset = "mochi"; private string _character = "Mochi";
 public MainWindow() { InitializeComponent(); SetCharacter("mochi", "Mochi", "Mèo mây", "#2563EB"); }
 private void CharacterPicker_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e) { if (CharacterPicker.SelectedItem is not System.Windows.Controls.ComboBoxItem item) return; var tag = item.Tag?.ToString() ?? "mochi"; var parts = item.Content?.ToString()?.Split('•') ?? ["Mochi", "Mèo mây"]; var colors = new Dictionary<string,string> { ["mochi"]="#2563EB", ["luna"]="#7C3AED", ["bobo"]="#D97706", ["mam"]="#059669" }; SetCharacter(tag, parts[0].Trim(), parts.Length > 1 ? parts[1].Trim() : "", colors[tag]); }
 private void SetCharacter(string asset, string name, string type, string color) { _asset = asset; _character = name; CharacterName.Text = $"{name} • {type}"; CharacterImage.Source = new BitmapImage(new Uri($"pack://application:,,,/assets/{asset}.png")); var c = (Color)ColorConverter.ConvertFromString(color); CharacterCard.Background = new SolidColorBrush(Color.FromArgb(28, c.R, c.G, c.B)); }
 private void Test_Click(object sender, RoutedEventArgs e) { var seconds = int.TryParse(DurationBox.Text, out var value) ? Math.Clamp(value, 3, 120) : 8; DurationBox.Text = seconds.ToString(); new ReminderWindow(_character, _asset, "14:30 • Họp nhóm thiết kế", seconds).Show(); if (SoundToggle.IsChecked == true) SystemSounds.Asterisk.Play(); }
 private void Connect_Click(object sender, RoutedEventArgs e) { ConnectionStatus.Text = "Đã kết nối • Google Calendar (demo OAuth)"; ConnectionStatus.Foreground = new SolidColorBrush(Color.FromRgb(5,150,105)); ConnectButton.Content = "Đã kết nối"; }
}
