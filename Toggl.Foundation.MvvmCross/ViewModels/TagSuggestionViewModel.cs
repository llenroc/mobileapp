using MvvmCross.Core.ViewModels;
using Toggl.Foundation.MvvmCross.Helper;
using Toggl.PrimeRadiant.Models;

namespace Toggl.Foundation.MvvmCross.ViewModels
{
    public sealed class TagSuggestionViewModel : MvxNotifyPropertyChanged, ITimeEntrySuggestionViewModel
    {
        public long Id { get; }

        public string Description { get; } = "";

        public TagSuggestionViewModel(IDatabaseTag tag)
        {
            Id = tag.Id;
            Description = tag.Name;
        }
    }
}
