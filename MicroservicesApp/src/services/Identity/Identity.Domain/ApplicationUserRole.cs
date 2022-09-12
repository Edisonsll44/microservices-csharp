namespace Identity.Domain
{
    public class ApplicationUserRole
    {
        public ApplicationRole Role { get; set; }
        public ApplicationUser User { get; set; }
    }
}
