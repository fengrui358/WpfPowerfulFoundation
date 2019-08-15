using System.Collections;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfViews.Controls.HintHand
{
    public class HintAdorner : Adorner
    {
        private readonly FrameworkElement _child;

        public HintAdorner(HintHand adornerHintElement, FrameworkElement adornedElement) : base(adornedElement)
        {
            adornerHintElement.IsActive = true;
            _child = adornerHintElement;

            AddLogicalChild(_child);
            AddVisualChild(_child);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _child.Measure(constraint);
            return _child.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var desiredSizeWidth = _child.DesiredSize.Width;
            var desiredSizeHeight = _child.DesiredSize.Height + 5;

            //放在目标元素上面
            _child.Arrange(new Rect(AdornedElement.RenderSize.Width / 2 - desiredSizeWidth / 2,
                0 - desiredSizeHeight, desiredSizeWidth, desiredSizeHeight));

            return finalSize;
        }

        protected override int VisualChildrenCount { get; } = 1;

        protected override Visual GetVisualChild(int index)
        {
            return _child;
        }

        protected override IEnumerator LogicalChildren
        {
            get
            {
                var list = new ArrayList { _child };
                return list.GetEnumerator();
            }
        }

        public void DisconnectChild()
        {
            RemoveLogicalChild(_child);
            RemoveVisualChild(_child);
        }
    }
}
