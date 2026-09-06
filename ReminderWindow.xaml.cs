using System.Windows;
using System.Windows.Media.Animation;
namespace LichNhac;
public partial class ReminderWindow : Window
{
 private readonly int _seconds;
 public ReminderWindow(string character, string face, string color, string message, int seconds) { InitializeComponent(); Character.Text = character; Face.Text = face; var c = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(color); Face.Foreground = new System.Windows.Media.SolidColorBrush(c); Message.Text = message; _seconds = seconds; }
 private async void OnLoaded(object sender, RoutedEventArgs e) { var area = SystemParameters.WorkArea; Left = area.Left + 18; Top = area.Bottom - Height - 18; BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(360))); await Task.Delay(_seconds * 1000); CloseAnimated(); }
 private void Close_Click(object sender, RoutedEventArgs e) => CloseAnimated();
 private void CloseAnimated() { var animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(180)); animation.Completed += (_, _) => Close(); BeginAnimation(OpacityProperty, animation); }
}
