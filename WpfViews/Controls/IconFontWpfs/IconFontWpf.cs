using System.Windows;
using FrHello.NetLib.Core.Wpf.Controls.IconFontWpf;

namespace WpfViews.Controls.IconFontWpfs
{
    public class IconFontWpf : IconFontControl<IconFontKind>
    {
        static IconFontWpf()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconFontWpf),
                new FrameworkPropertyMetadata(typeof(IconFontWpf)));
        }

        public IconFontWpf() : base(IconFontDataFactory.Create)
        {
        }
    }
}