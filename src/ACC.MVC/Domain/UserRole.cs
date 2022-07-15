namespace ACC.MVC.Domain
{
    public class UserRole : EntityBase
    {
        public long UserId { get; set; }

        public long RoleId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
