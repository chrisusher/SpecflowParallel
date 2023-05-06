using System.Reflection;

namespace SpecflowParallel.Helpers;

public static class TestRunHelper
{
    public static void SetupTestRun()
    {
        var testResultsDir = Path.Combine(Assembly.GetExecutingAssembly().Location, "../../../../TestResults");

        var directoryInfo = new DirectoryInfo(testResultsDir);

        if (!directoryInfo.Exists)
        {
            Directory.CreateDirectory(directoryInfo.FullName);
        }

        var testRunFolder = Path.Combine(directoryInfo.FullName, DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss"));

        if (!Directory.Exists(testRunFolder))
        {
            Directory.CreateDirectory(testRunFolder);
        }

        StaticData.TestRunDirectory = testRunFolder;
    }
}