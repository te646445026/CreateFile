using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace CreateFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // 获取用户输入的所有文件夹名称
            string[] folderNames = textBox.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // 获取程序所在目录的完整路径
            string programPath = Environment.CurrentDirectory;

            foreach (var name in folderNames)
            {
                // 检查名称是否有效
                if (string.IsNullOrEmpty(name) || name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    MessageBox.Show($"无效的文件夹名称: {name}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    continue;
                }

                // 拼接文件夹的完整路径
                string folderPath = Path.Combine(programPath, name.Trim());

                // 创建文件夹
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    MessageBox.Show($"文件夹 '{name}' 创建成功！", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"文件夹 '{name}' 已存在。", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
} 
