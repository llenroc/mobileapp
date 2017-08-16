using System.Text;

namespace Toggl.Multivac.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendIfNotEmpty(this StringBuilder builder, string value)
        {
            if (!string.IsNullOrEmpty(value))
                builder.Append(value);
            return builder;
        }
    }
}
