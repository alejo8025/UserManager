using Microsoft.OpenApi.Models;

namespace UserManager.Web
{
    internal class Info : OpenApiInfo
    {
        public new string Title { get; set; }
        public new string Version { get; set; }
        public new string Description { get; set; }
        public new string TermsOfService { get; set; }
    }
}