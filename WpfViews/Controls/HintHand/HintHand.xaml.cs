using System.Windows;
using System.Windows.Media.Animation;
using FrHello.NetLib.Core.Mvx;

namespace WpfViews.Controls.HintHand
{
    /// <summary>
    /// HintHand.xaml 的交互逻辑
    /// </summary>
    public partial class HintHand
    {
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
                    "IsActive", typeof(bool), typeof(HintHand),
                    new FrameworkPropertyMetadata(default(bool), OnIsActiveChanged));

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }

        public static readonly DependencyProperty HintMessageProperty = DependencyProperty.Register(
            "HintMessage", typeof(string), typeof(HintHand), new PropertyMetadata(default(string)));

        public string HintMessage
        {
            get => (string)GetValue(HintMessageProperty);
            set => SetValue(HintMessageProperty, value);
        }

        public HintHand()
        {
            IsHitTestVisible = false;
            InitializeComponent();
        }

        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UiDispatcherHelper.Invoke(() =>
            {
                var hintHand = (HintHand)d;
                var storyBoard = (Storyboard)hintHand.Resources["HintHandStoryboard"];

                if ((bool)e.NewValue)
                {
                    storyBoard.Begin(hintHand, true);
                }
                else
                {
                    storyBoard.Stop(hintHand);
                }
            });
        }
    }
}
