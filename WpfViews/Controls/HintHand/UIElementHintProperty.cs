using System;
using System.Windows;
using System.Windows.Documents;

namespace WpfViews.Controls.HintHand
{
    /// <summary>
    /// 提示元素附加属性
    /// </summary>
    public class UIElementHintProperty
    {
        public static readonly DependencyProperty ShowHintProperty =
            DependencyProperty.RegisterAttached("ShowHint", typeof(bool), typeof(UIElementHintProperty),
                new PropertyMetadata(false, OnShowHintChanged));

        public static bool GetShowHint(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return (bool)element.GetValue(ShowHintProperty);
        }

        public static void SetShowHint(UIElement element, bool value)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.SetValue(ShowHintProperty, value);
        }

        public static readonly DependencyProperty HintMessageProperty =
            DependencyProperty.RegisterAttached("HintMessage", typeof(string), typeof(UIElementHintProperty),
                new PropertyMetadata(null));

        public static string GetHintMessage(UIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return (string)element.GetValue(HintMessageProperty);
        }

        public static void SetHintMessage(UIElement element, string value)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.SetValue(HintMessageProperty, value);
        }

        private static void OnShowHintChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is UIElement element)
            {
                var showHint = (bool)e.NewValue;

                var adornerLayer = AdornerLayer.GetAdornerLayer(element);
                var adorners = adornerLayer?.GetAdorners(element);

                if (adornerLayer != null)
                {
                    if (adorners != null)
                    {
                        foreach (var adorner in adorners)
                        {
                            adornerLayer.Remove(adorner);

                            if (adorner is HintAdorner hintAdorner)
                            {
                                hintAdorner.DisconnectChild();
                            }
                        }
                    }

                    if (showHint)
                    {
                        var hintHand = new WpfViews.Controls.HintHand.HintHand
                            {HintMessage = (string) element.GetValue(UIElementHintProperty.HintMessageProperty)};

                        adornerLayer.Add(new HintAdorner(hintHand, (FrameworkElement)element));
                    }
                }
            }
        }
    }
}
