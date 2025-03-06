namespace GMS2025.Business.Providers
{
    public static class StaticServiceProvider
    {
        public static IServiceProvider Instance { get; private set; }

        public static void Configure(IServiceProvider serviceProvider)
        {
            Instance = serviceProvider;
        }

        public static T GetService<T>() => Instance.GetService<T>();
    }
}