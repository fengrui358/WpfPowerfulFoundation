using System.Collections.Generic;

namespace WpfViews.Controls.IconFontWpfs
{
    public static class IconFontDataFactory
    {
        public static IDictionary<IconFontKind, string> Create()
        {
            return new Dictionary<IconFontKind, string>()
            {
                {
                    IconFontKind.None,
                    ""
                },
                {
                    IconFontKind.Gear,
                    "\u3433"
                }
            };
        }
    }
}