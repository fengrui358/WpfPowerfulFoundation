using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        /// 构造
        /// </summary>
        public App()
        {
            MvxHelper.CaptureGlobalExceptions();
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceAssembliesPathList = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*Service.dll",
                SearchOption.TopDirectoryOnly);
            var serviceAssemblies = new List<Assembly>();
            if (serviceAssembliesPathList.Any())
            {
                foreach (var path in serviceAssembliesPathList)
                {
                    serviceAssemblies.Add(Assembly.LoadFile(path));
                }
            }

            MvxHelper.Init<MainWindowView, FirstViewModel>(serviceAssemblies: serviceAssemblies.ToArray());
        }
    }
}
