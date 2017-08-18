using System;
using System.Globalization;
using System.Text;
using CoreGraphics;
using Foundation;
using MvvmCross.Platform.Converters;
using MvvmCross.Plugins.Color.iOS;
using Toggl.Foundation.MvvmCross.Helper;
using Toggl.Multivac;
using UIKit;
using static Toggl.Multivac.Extensions.StringBuilderExtensions;

namespace Toggl.Daneel.Converters
{
    public class ProjectTaskClientToAttributedStringValueConverter
        : MvxValueConverter<(string project, string task, string client), NSAttributedString>
    {
        private readonly UIFont font;

        public ProjectTaskClientToAttributedStringValueConverter(UIFont font)
        {
            Ensure.Argument.IsNotNull(font, nameof(font));

            this.font = font;
        }


        protected override NSAttributedString Convert((string project, string task, string client) value, Type targetType, object parameter, CultureInfo culture)
        {
            var builder = new StringBuilder();
            builder.AppendIfNotEmpty($" { value.project }")
                   .AppendIfNotEmpty($": { value.task }")
                   .AppendIfNotEmpty($" { value.client }");

            var dot = new NSTextAttachment
            {
                Image = UIImage.FromBundle("icProjectDot")
            };

            verticallyCenterProjectDot(dot);

            var attributedString = new NSMutableAttributedString(NSAttributedString.FromAttachment(dot));
            attributedString.Append(new NSAttributedString(builder.ToString()));

            var colorRange = new NSRange(attributedString.Length - value.client.Length, value.client.Length);
            var attributes = new UIStringAttributes { ForegroundColor = Color.EditTimeEntry.ClientText.ToNativeColor() };
            attributedString.AddAttributes(attributes, colorRange);

            return attributedString;
        }

        private void verticallyCenterProjectDot(NSTextAttachment dot)
        {
            var imageSize = dot.Image.Size;
            var y = (font.CapHeight - imageSize.Height) / 2;
            dot.Bounds = new CGRect(0, y, imageSize.Width, imageSize.Height);
        }
    }
}
