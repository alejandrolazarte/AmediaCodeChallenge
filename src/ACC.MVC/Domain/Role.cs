namespace ACC.MVC.Domain
{
    public class Role : EntityBase
    {
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
