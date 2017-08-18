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
using static Toggl.Multivac.Extensions.StringBuilderExtensions;

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
            var builder = new StringBuilder();
            builder.AppendIfNotEmpty($" { value.project }")
                   .AppendIfNotEmpty($": { value.task }")
                   .AppendIfNotEmpty($" { value.client }");

            var image = UIImage.FromBundle("icProjectDot").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            var dot = new NSTextAttachment
            {
                Image = image
            };
            var attributedString = new NSMutableAttributedString(" ");
            attributedString.Append(NSAttributedString.FromAttachment(dot));
            attributedString.Append(new NSAttributedString(builder.ToString()));

            verticallyCenterProjectDot(dot);
            setProjectDotColor(attributedString, value.color);
            setClientTextColor(attributedString, value.client);
            
            return attributedString;
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
