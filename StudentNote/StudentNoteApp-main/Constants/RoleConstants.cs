namespace StudentNoteApp.Constants;

public static class RoleConstants
{
    public const string Admin = "Admin";
    public const string Teacher = "Teacher";
    public const string ReportViewer = "ReportViewer";
    public const string ContentManager = "ContentManager";

    public static readonly string[] AllRoles = new[]
    {
        Admin,
        Teacher,
        ReportViewer,
        ContentManager
    };

    public static class Permissions
    {
        public static class Students
        {
            public const string View = "Students.View";
            public const string Create = "Students.Create";
            public const string Edit = "Students.Edit";
            public const string Delete = "Students.Delete";
            public const string Manage = "Students.Manage";
        }

        public static class Subjects
        {
            public const string View = "Subjects.View";
            public const string Create = "Subjects.Create";
            public const string Edit = "Subjects.Edit";
            public const string Delete = "Subjects.Delete";
        }

        public static class Notes
        {
            public const string View = "Notes.View";
            public const string Create = "Notes.Create";
            public const string Edit = "Notes.Edit";
            public const string Delete = "Notes.Delete";
        }

        public static class Reports
        {
            public const string View = "Reports.View";
            public const string Generate = "Reports.Generate";
            public const string Export = "Reports.Export";
        }
    }

    public static class DefaultPermissions
    {
        public static readonly Dictionary<string, string[]> RolePermissions = new()
        {
            {
                Admin, new[]
                {
                    Permissions.Students.View,
                    Permissions.Students.Create,
                    Permissions.Students.Edit,
                    Permissions.Students.Delete,
                    Permissions.Subjects.View,
                    Permissions.Subjects.Create,
                    Permissions.Subjects.Edit,
                    Permissions.Subjects.Delete,
                    Permissions.Notes.View,
                    Permissions.Notes.Create,
                    Permissions.Notes.Edit,
                    Permissions.Notes.Delete,
                    Permissions.Reports.View,
                    Permissions.Reports.Generate,
                    Permissions.Reports.Export
                }
            },
            {
                Teacher, new[]
                {
                    Permissions.Students.View,
                    Permissions.Notes.View,
                    Permissions.Notes.Create,
                    Permissions.Notes.Edit
                }
            },
            {
                ReportViewer, new[]
                {
                    Permissions.Students.View,
                    Permissions.Notes.View,
                    Permissions.Reports.View,
                    Permissions.Reports.Export
                }
            },
            {
                ContentManager, new[]
                {
                    Permissions.Students.View,
                    Permissions.Students.Edit,
                    Permissions.Subjects.View,
                    Permissions.Subjects.Edit,
                    Permissions.Notes.View,
                    Permissions.Notes.Edit
                }
            }
        };
    }
}