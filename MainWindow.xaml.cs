using System.Media;
using System.Windows;
using System.Windows.Media;
namespace LichNhac;
public partial class MainWindow : Window
{
 private string _face = "◕‿◕"; private string _color = "#2563EB"; private string _character = "Mochi";
 public MainWindow() => InitializeComponent();
 private void CharacterPicker_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e) { if (CharacterPicker.SelectedItem is not System.Windows.Controls.ComboBoxItem item) return; switch (item.Tag?.ToString()) { case "luna": (_character, _face, _color) = ("Luna", "◠ᴥ◠", "#7C3AED"); break; case "bobo": (_character, _face, _color) = ("Bobo", "•ᴥ•", "#D97706"); break; case "mam": (_character, _face, _color) = ("Mầm", "˶ᵔ ᵕ ᵔ˶", "#059669"); break; default: (_character, _face, _color) = ("Mochi", "◕‿◕", "#2563EB"); break; } CharacterName.Text = $"{_character} • {item.Content?.ToString()?.Split('•').Last()?.Trim()}"; CharacterFace.Text = _face; CharacterFace.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_color)); CharacterCard.Background = new SolidColorBrush(Color.FromArgb(28, ((Color)ColorConverter.ConvertFromString(_color)).R, ((Color)ColorConverter.ConvertFromString(_color)).G, ((Color)ColorConverter.ConvertFromString(_color)).B)); }
 private void Test_Click(object sender, RoutedEventArgs e) { var seconds = int.TryParse(DurationBox.Text, out var value) ? Math.Clamp(value, 3, 120) : 8; DurationBox.Text = seconds.ToString(); new ReminderWindow(_character, _face, _color, "14:30 • Họp nhóm thiết kế", seconds).Show(); if (SoundToggle.IsChecked == true) SystemSounds.Asterisk.Play(); }
 private void Connect_Click(object sender, RoutedEventArgs e) { ConnectionStatus.Text = "Đã kết nối • Google Calendar (demo OAuth)"; ConnectionStatus.Foreground = new SolidColorBrush(Color.FromRgb(5,150,105)); ConnectButton.Content = "Đã kết nối"; }
}
