namespace EMR.API.Models.External
{
    public class PasswordResetHashedModel
    {
        public string Tc { get; set; }
        public string Code { get; set; }
        public string Hash { get; set; }
        public string Password { get; set; }
        public string Uid { get; set; }
        public string NewHash { get; set; }
    }
}