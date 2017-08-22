using System;
using Foundation;
using UIKit;

namespace Toggl.Daneel.Views
{
    public partial class StartTimeEntryViewCell : UITableViewCell
    {
        private const float NoProjectDistance = 16;
        private const float HasProjectDistance = 8;

        public static readonly NSString Key = new NSString(nameof(StartTimeEntryViewCell));
        public static readonly UINib Nib;

        static StartTimeEntryViewCell()
        {
            Nib = UINib.FromName(nameof(StartTimeEntryViewCell), NSBundle.MainBundle);
        }

        protected StartTimeEntryViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
