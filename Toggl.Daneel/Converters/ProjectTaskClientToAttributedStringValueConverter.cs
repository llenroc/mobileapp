using System;
using System.Globalization;
using System.Text;
using Foundation;
using MvvmCross.Platform.Converters;
using MvvmCross.Plugins.Color.iOS;
using Toggl.Foundation.MvvmCross.Helper;
using UIKit;
using static Toggl.Multivac.Extensions.StringBuilderExtensions;

namespace Toggl.Daneel.Converters
{
    public class ProjectTaskClientToAttributedStringValueConverter
        : MvxValueConverter<(string project, string task, string client), NSAttributedString>
    {
        protected override NSAttributedString Convert((string project, string task, string client) value, Type targetType, object parameter, CultureInfo culture)
        {
            var builder = new StringBuilder();
            builder.AppendIfNotEmpty(value.project)
                   .AppendIfNotEmpty($": { value.task }")
                   .AppendIfNotEmpty($" { value.client }");

            var attributedString = new NSMutableAttributedString(builder.ToString());
            var colorRange = new NSRange(attributedString.Length - value.client.Length, value.client.Length);
            var attributes = new UIStringAttributes { ForegroundColor = Color.EditTimeEntry.ClientText.ToNativeColor() };
            attributedString.AddAttributes(attributes, colorRange);
            return attributedString;
        }
    }
}
