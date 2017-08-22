using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Toggl.Foundation.DataSources;
using Toggl.Foundation.MvvmCross.Parameters;
using Toggl.Multivac;
using Toggl.Multivac.Extensions;

namespace Toggl.Foundation.MvvmCross.ViewModels
{
    [Preserve(AllMembers = true)]
    public sealed class StartTimeEntryViewModel : MvxViewModel<DateParameter>
    {
        private enum QueryType
        {
            TimeEntries,
            Projects,
            Tags
        }

        //Fields
        private readonly ITimeService timeService;
        private readonly ITogglDataSource dataSource;
        private readonly IMvxNavigationService navigationService;
        private readonly Subject<string> querySubject = new Subject<string>();

        private QueryType queryType;
        private IDisposable queryDisposable;
        private IDisposable elapsedTimeDisposable;

        //Properties
        public string RawTimeEntryText { get; set; } = "";

        public int CursorPosition { get; set; } = 0;

        public TimeSpan ElapsedTime { get; private set; } = TimeSpan.Zero;

        public bool IsBillable { get; private set; } = false;

        public bool IsEditingProjects { get; private set; } = false;

        public bool IsEditingTags { get; private set; } = false;

        public DateTimeOffset StartDate { get; private set; }

        public DateTimeOffset? EndDate { get; private set; }

        public MvxObservableCollection<ITimeEntrySuggestionViewModel> Suggestions { get; }
            = new MvxObservableCollection<ITimeEntrySuggestionViewModel>();

        public IMvxAsyncCommand BackCommand { get; }

        public IMvxAsyncCommand DoneCommand { get; }

        public IMvxCommand ToggleBillableCommand { get; }

        public StartTimeEntryViewModel(ITogglDataSource dataSource, ITimeService timeService, IMvxNavigationService navigationService)
        {
            Ensure.Argument.IsNotNull(dataSource, nameof(dataSource));
            Ensure.Argument.IsNotNull(timeService, nameof(timeService));
            Ensure.Argument.IsNotNull(navigationService, nameof(navigationService));

            this.dataSource = dataSource;
            this.timeService = timeService;
            this.navigationService = navigationService;

            BackCommand = new MvxAsyncCommand(back);
            DoneCommand = new MvxAsyncCommand(done);
            ToggleBillableCommand = new MvxCommand(toggleBillable);
        }

        public override async Task Initialize(DateParameter parameter)
        {
            await Initialize();

            StartDate = parameter.GetDate();

            elapsedTimeDisposable =
                timeService.CurrentDateTimeObservable.Subscribe(currentTime => ElapsedTime = currentTime - StartDate);
            
            queryDisposable = querySubject.AsObservable()                 .Where(query => query != null)                 .SelectMany(querySuggestions)                 .Subscribe(onSuggestions);
        }          private void OnRawTimeEntryTextChanged()         {
            if (RawTimeEntryText.Contains("@"))
                queryType = QueryType.Projects;
            else if (RawTimeEntryText.Contains("#"))
                queryType = QueryType.Tags;
            else
                queryType = QueryType.TimeEntries;
                         querySubject.OnNext(RawTimeEntryText.Replace("@", "").Replace("#", ""));         }

        private void toggleBillable() => IsBillable = !IsBillable;

        private Task back() => navigationService.Close(this);

        private async Task done()
        {
            await dataSource.TimeEntries.Start(StartDate, RawTimeEntryText, IsBillable);

            await navigationService.Close(this);
        }          private IObservable<IEnumerable<ITimeEntrySuggestionViewModel>> querySuggestions(string query)         {             if (query.Length == 0)
                Observable.Return(Enumerable.Empty<ITimeEntrySuggestionViewModel>()); 
            switch (queryType)
            {
                case QueryType.Tags:
                    return dataSource.Tags
                        .GetAll(t => t.Name.Contains(query))
                        .Select(tags => tags.Select(tag => new TagSuggestionViewModel(tag)));
                    
                case QueryType.Projects:
                    return dataSource.Projects
                        .GetAll(p => p.Name.Contains(query) || (p.Client != null && p.Client.Name.Contains(query)))
                        .Select(projects => projects.Select(project => new ProjectSuggestionViewModel(project)))
                        .Select(projects => projects.Any() ? ProjectSuggestionViewModel.PrepentEmptyProject(projects) : projects);

                default:
                    return dataSource.TimeEntries
                        .GetAll(te => te.Description.Contains(query) || (te.Project != null && te.Project.Name.Contains(query)))
                        .Select(timeEntries => timeEntries.Select(timeEntry => new TimeEntrySuggestionViewModel(timeEntry)));
            }         }          private void onSuggestions(IEnumerable<ITimeEntrySuggestionViewModel> suggestions)         {
            Suggestions.Clear();             Suggestions.AddRange(suggestions);         }
    }
}
