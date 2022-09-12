namespace Identity.Domain
{
    public class ApplicationRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}