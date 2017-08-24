﻿﻿using Toggl.Multivac.Models;

namespace Toggl.Foundation.Models
{
    internal partial class Client
    {
        private Client(IClient entity, bool isDirty)
        {
            Id = entity.Id;
            WorkspaceId = entity.WorkspaceId;
            Name = entity.Name;
            At = entity.At;
            ServerDeletedAt = entity.ServerDeletedAt;
            IsDirty = isDirty;
        }

        public static Client Clean(IClient entity)
            => new Client(entity, false);

        public static Client Dirty(IClient entity)
            => new Client(entity, true);
    }

    internal partial class Project
    {
        private Project(IProject entity, bool isDirty)
        {
            Id = entity.Id;
            WorkspaceId = entity.WorkspaceId;
            ClientId = entity.ClientId;
            Name = entity.Name;
            IsPrivate = entity.IsPrivate;
            Active = entity.Active;
            At = entity.At;
            ServerDeletedAt = entity.ServerDeletedAt;
            Color = entity.Color;
            Billable = entity.Billable;
            Template = entity.Template;
            AutoEstimates = entity.AutoEstimates;
            EstimatedHours = entity.EstimatedHours;
            Rate = entity.Rate;
            Currency = entity.Currency;
            ActualHours = entity.ActualHours;
            IsDirty = isDirty;
        }

        public static Project Clean(IProject entity)
            => new Project(entity, false);

        public static Project Dirty(IProject entity)
            => new Project(entity, true);
    }

    internal partial class Tag
    {
        private Tag(ITag entity, bool isDirty)
        {
            Id = entity.Id;
            WorkspaceId = entity.WorkspaceId;
            Name = entity.Name;
            At = entity.At;
            IsDirty = isDirty;
        }

        public static Tag Clean(ITag entity)
            => new Tag(entity, false);

        public static Tag Dirty(ITag entity)
            => new Tag(entity, true);
    }

    internal partial class Task
    {
        private Task(ITask entity, bool isDirty)
        {
            Id = entity.Id;
            Name = entity.Name;
            ProjectId = entity.ProjectId;
            WorkspaceId = entity.WorkspaceId;
            UserId = entity.UserId;
            EstimatedSeconds = entity.EstimatedSeconds;
            Active = entity.Active;
            At = entity.At;
            TrackedSeconds = entity.TrackedSeconds;
            IsDirty = isDirty;
        }

        public static Task Clean(ITask entity)
            => new Task(entity, false);

        public static Task Dirty(ITask entity)
            => new Task(entity, true);
    }

    internal partial class TimeEntry
    {
        private TimeEntry(ITimeEntry entity, bool isDirty, bool isDeleted = false)
        {
            Id = entity.Id;
            WorkspaceId = entity.WorkspaceId;
            ProjectId = entity.ProjectId;
            TaskId = entity.TaskId;
            Billable = entity.Billable;
            Start = entity.Start;
            Stop = entity.Stop;
            Description = entity.Description;
            TagNames = entity.TagNames;
            TagIds = entity.TagIds;
            At = entity.At;
            ServerDeletedAt = entity.ServerDeletedAt;
            UserId = entity.UserId;
            CreatedWith = entity.CreatedWith;
            IsDirty = isDirty;
            IsDeleted = isDeleted;
        }

        public static TimeEntry Clean(ITimeEntry entity)
            => new TimeEntry(entity, false);

        public static TimeEntry Dirty(ITimeEntry entity)
            => new TimeEntry(entity, true);

        public static TimeEntry CleanDeleted(ITimeEntry entity)
            => new TimeEntry(entity, false, true);

        public static TimeEntry DirtyDeleted(ITimeEntry entity)
            => new TimeEntry(entity, true, true);
    }

    internal partial class User
    {
        private User(IUser entity, bool isDirty)
        {
            Id = entity.Id;
            ApiToken = entity.ApiToken;
            DefaultWorkspaceId = entity.DefaultWorkspaceId;
            Email = entity.Email;
            Fullname = entity.Fullname;
            TimeOfDayFormat = entity.TimeOfDayFormat;
            DateFormat = entity.DateFormat;
            StoreStartAndStopTime = entity.StoreStartAndStopTime;
            BeginningOfWeek = entity.BeginningOfWeek;
            Language = entity.Language;
            ImageUrl = entity.ImageUrl;
            SidebarPiechart = entity.SidebarPiechart;
            At = entity.At;
            Retention = entity.Retention;
            RecordTimeline = entity.RecordTimeline;
            RenderTimeline = entity.RenderTimeline;
            TimelineEnabled = entity.TimelineEnabled;
            TimelineExperiment = entity.TimelineExperiment;
            IsDirty = isDirty;
        }

        public static User Clean(IUser entity)
            => new User(entity, false);

        public static User Dirty(IUser entity)
            => new User(entity, true);
    }

    internal partial class Workspace
    {
        private Workspace(IWorkspace entity, bool isDirty)
        {
            Id = entity.Id;
            Name = entity.Name;
            Admin = entity.Admin;
            SuspendedAt = entity.SuspendedAt;
            ServerDeletedAt = entity.ServerDeletedAt;
            DefaultHourlyRate = entity.DefaultHourlyRate;
            DefaultCurrency = entity.DefaultCurrency;
            OnlyAdminsMayCreateProjects = entity.OnlyAdminsMayCreateProjects;
            OnlyAdminsSeeBillableRates = entity.OnlyAdminsSeeBillableRates;
            OnlyAdminsSeeTeamDashboard = entity.OnlyAdminsSeeTeamDashboard;
            ProjectsBillableByDefault = entity.ProjectsBillableByDefault;
            Rounding = entity.Rounding;
            RoundingMinutes = entity.RoundingMinutes;
            At = entity.At;
            LogoUrl = entity.LogoUrl;
            IsDirty = isDirty;
        }

        public static Workspace Clean(IWorkspace entity)
            => new Workspace(entity, false);

        public static Workspace Dirty(IWorkspace entity)
            => new Workspace(entity, true);
    }
}