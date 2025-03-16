namespace Data.Entities
{
    public partial class Roles
    {
        public object Permissions { get; internal set; }

        public class UserHasRoles
        {
            public int UserId { get; set; }

            public int RoleId { get; set; }
        }
    }
}
