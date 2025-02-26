namespace HiveBoxApi.Services;
public class AppVersionService : IAppVersionService
{
    private readonly IConfiguration configuration;

    public AppVersionService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public string GetAppVersion()
    {
        return configuration["AppVersion"];
    }
}