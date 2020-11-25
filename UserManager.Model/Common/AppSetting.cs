namespace UserManager.Model.Common
{
    public class AppSetting
    {
        public string SecretKeyAuth { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ClientIdAuth { get; set; }
        public string MessageAuthSuccess { get; set; }
        public string MessageAuthNotValid { get; set; }
        public string MessageSuccessToken { get; set; }
        public string ServiceConnectionSuccessful { get; set; }
        public string ServiceConnectionUnsuccessful { get; set; }
        public string MessageLoginSucces { get; set; }
        public string MessageLoginUnsuccess { get; set; }
        public string MessageLoginUnsuccessAplication { get; set; }
        public string Separator { get; set; }
        public string SPGetuser { get; set; }
        public string SPGetAllUsers { get; set; }
        public string SPGetUpdateUsers { get; set; }
        public string SPGetAllRoles { get; set; }
        public string SPGetAllDocumentTypes { get; set; }
        public string SPInsertUser { get; set; }
        public string DbConnection { get; set; }
    }
}
