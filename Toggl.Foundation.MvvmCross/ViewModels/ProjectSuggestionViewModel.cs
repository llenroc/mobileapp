using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using Toggl.Foundation.MvvmCross.Helper;
using Toggl.PrimeRadiant.Models;

namespace Toggl.Foundation.MvvmCross.ViewModels
{
    public sealed class ProjectSuggestionViewModel : MvxNotifyPropertyChanged, ITimeEntrySuggestionViewModel
    {
        private static ProjectSuggestionViewModel NoProject = new ProjectSuggestionViewModel();

        public long Id { get; }

        public int NumberOfTasks { get; } = 0;

        public string ProjectName { get; } = "";

        public string ClientName { get; } = "";

        public string ProjectColor { get; }

        private ProjectSuggestionViewModel()
        {
            ProjectColor = "#CECECE";
            ProjectName = Resources.NoProject;
        }

        public ProjectSuggestionViewModel(IDatabaseProject project)
        {
            Id = project.Id;
            ProjectName = project.Name;
            ProjectColor = project.Color;

            if (project.Client == null) return;

            ClientName = project.Client.Name;
        }

        internal static IEnumerable<ProjectSuggestionViewModel> PrepentEmptyProject(IEnumerable<ProjectSuggestionViewModel> projects)
        {
            yield return NoProject;
            foreach (var project in projects)
                yield return project;
        }
    }
}
