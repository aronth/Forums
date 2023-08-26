public class Routes
{
    public const string Version = "v1";
    public const string Base = "api/" + Version + "/";

    public static class Auth
    {
        public const string Base = Routes.Base + "auth/";
        public const string Login = Base + "login";
        public const string Register = Base + "register";
    }

    public static class Threads
    {
        public const string Base = Routes.Base + "threads/";
        public const string Get = Base + "{id}";
        public const string Create = Base;
    }
}