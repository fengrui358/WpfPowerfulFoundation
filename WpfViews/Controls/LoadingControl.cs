using System.Windows;
using System.Windows.Controls;

namespace WpfViews.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfApp5"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfApp5;assembly=WpfApp5"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:LoadingControl/>
    ///
    /// </summary>
    public class LoadingControl : Control
    {
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
            "IsLoading", typeof(bool), typeof(LoadingControl), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            "Message", typeof(string), typeof(LoadingControl), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            "Progress", typeof(double?), typeof(LoadingControl), new PropertyMetadata(default(double?)));

        /// <summary>
        /// 加载显示的信息
        /// </summary>
        public string Message
        {
            get => (string) GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        /// <summary>
        /// 是否加载中
        /// </summary>
        public bool IsLoading
        {
            get => (bool) GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        /// <summary>
        /// 加载进度
        /// </summary>
        public double? Progress
        {
            get => (double?) GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        static LoadingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingControl), new FrameworkPropertyMetadata(typeof(LoadingControl)));
        }
    }
}
