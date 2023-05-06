using Medallion.Threading.FileSystem;

namespace SpecflowParallel.Helpers;

public class LockHelper
{
    private static DirectoryInfo LockDirectory => new(StaticData.TestRunDirectory);
    
    public static async Task<bool> LockAsync(string lockName)
    {
        try
        {
            var newLock = new FileDistributedLock(LockDirectory, lockName);

            await newLock.AcquireAsync(TimeSpan.FromSeconds(3));

            return true;
        }
        catch
        {
            return false;
        }
    }
}