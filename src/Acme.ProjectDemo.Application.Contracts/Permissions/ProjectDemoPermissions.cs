namespace Acme.ProjectDemo.Permissions
{
    public static class ProjectDemoPermissions
    {
        public const string GroupName = "ProjectDemo";

        public static class CustomerDetail
        {
            public const string Default = GroupName + ".CustomerDetail";
            public const string Admin = Default + ".Admin";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}