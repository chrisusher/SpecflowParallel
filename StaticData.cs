using Microsoft.Extensions.Configuration;

namespace SpecflowParallel;

public static class StaticData
{
    public static IConfiguration Configuration { get; set; }
    public static TestConfig TestConfig { get; set; }
    public static string TestRunDirectory { get; set; }
}