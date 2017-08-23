using System;
using System.Globalization;
using System.Text;
using CoreGraphics;
using Foundation;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Color;
using MvvmCross.Plugins.Color.iOS;
using Toggl.Foundation.MvvmCross.Helper;
using Toggl.Multivac;
using UIKit;

namespace Toggl.Daneel.Converters
{
    public class ProjectTaskClientToAttributedStringValueConverter
        : MvxValueConverter<(string project, string task, string client, string color), NSAttributedString>
    {
        private readonly UIFont font;
        private readonly MvxRGBValueConverter colorConverter = new MvxRGBValueConverter();

        public ProjectTaskClientToAttributedStringValueConverter(UIFont font)
        {
            Ensure.Argument.IsNotNull(font, nameof(font));

            this.font = font;
        }

        protected override NSAttributedString Convert((string project, string task, string client, string color) value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = buildString(value.project, value.task, value.client);

            var image = UIImage.FromBundle("icProjectDot").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            var dot = new NSTextAttachment { Image = image };
            //There neeeds to be a space before the dot, otherwise the colors don't work
            var attributedString = new NSMutableAttributedString(" ");
            attributedString.Append(NSAttributedString.FromAttachment(dot));
            attributedString.Append(new NSAttributedString(text));

            verticallyCenterProjectDot(dot);
           
            if (!string.IsNullOrEmpty(value.color))
                setProjectDotColor(attributedString, value.color);
            
            if (!string.IsNullOrEmpty(value.client))
                setClientTextColor(attributedString, value.client);
            
            return attributedString;
        }

        private string buildString(string project, string task, string client)
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(project))
                builder.Append($" {project}");
            
            if (!string.IsNullOrEmpty(task))
                builder.Append($": {task}");
            
            if (!string.IsNullOrEmpty(client))
                builder.Append($" {client}");

            return builder.ToString();
        }

        private void verticallyCenterProjectDot(NSTextAttachment dot)
        {
            var imageSize = dot.Image.Size;
            var y = (font.CapHeight - imageSize.Height) / 2;
            dot.Bounds = new CGRect(0, y, imageSize.Width, imageSize.Height);
        }

        private void setProjectDotColor(NSMutableAttributedString text, string hexColor)
        {
            var range = new NSRange(0, 1);
            var color = (UIColor)colorConverter.Convert(hexColor, typeof(MvxColor), null, CultureInfo.CurrentCulture);
            var attributes = new UIStringAttributes { ForegroundColor = color };
            text.AddAttributes(attributes, range);
        }

        private void setClientTextColor(NSMutableAttributedString text, string client)
        {
            var range = new NSRange(text.Length - client.Length, client.Length);
            var attributes = new UIStringAttributes { ForegroundColor = Color.EditTimeEntry.ClientText.ToNativeColor() };
            text.AddAttributes(attributes, range);
        }
    }
}
