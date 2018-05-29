using System.Windows;
using Core.ViewModels;
using FrHello.NetLib.Core.Wpf;
using WpfViews.Windows;

namespace WpfPowerfulFoundation
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            MvxHelper.Init<MainWindowView, FirstViewModel>();
        }
    }
}
