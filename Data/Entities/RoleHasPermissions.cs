namespace Data.Entities
{
    public partial class Permission
    {
        public class RoleHasPermissions
        {
            public int RoleId { get; set; }

            public int PermissionId { get; set; }
        }
    }
}
