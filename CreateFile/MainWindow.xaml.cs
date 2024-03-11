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
            // 获取文本框中输入的名字
            string name = textBox.Text;

            // 判断名字是否为空或无效
            if (string.IsNullOrEmpty(name) || name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                // 显示错误信息
                MessageBox.Show("请输入有效的名字", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // 获取程序所在目录的完整路径
                string programPath = Environment.CurrentDirectory;

                // 拼接文件夹的完整路径
                string folderPath = Path.Combine(programPath, name);

                // 判断文件夹是否已经存在
                if (Directory.Exists(folderPath))
                {
                    // 显示提示信息
                    MessageBox.Show("该文件夹已经存在", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // 尝试创建文件夹
                    try
                    {
                        // 调用 Directory.CreateDirectory 方法创建文件夹
                        Directory.CreateDirectory(folderPath);

                        // 显示成功信息
                        MessageBox.Show("文件夹创建成功", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        // 显示异常信息
                        MessageBox.Show(ex.Message, "异常", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
