namespace MyDoc.Middleware
{
    public class ApplicationProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetApplicationName()
        {
            var dbName = _httpContextAccessor.HttpContext?
                .Request
                .Headers["X-Application-Name"]
                .ToString();

            if (string.IsNullOrWhiteSpace(dbName))
            {
                throw new Exception("X-Application-Name header is missing");
            }

            return dbName;
        }
    }
}
