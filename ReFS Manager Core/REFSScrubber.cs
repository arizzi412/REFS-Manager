
namespace ReFS_Manager_Core;

public static class REFSScrubber
{
    public static void ScrubVolume(VolumeName volumeName)
    {
        var fileId = GetFileIdOfRootOfVolume(volumeName);

        string command = $@"refsutil triage {volumeName} /s {fileId} /v";

        var results = PowershellRunner.RunCommand(command);

        Console.WriteLine(results.First());
    }

    private static int GetFileIdOfRootOfVolume(VolumeName volumeName)
    {
        string command = $@"fsutil file queryfileid {volumeName}";


        var results = PowershellRunner.RunCommand(command);

        return results.ConvertToFileId();
    }
}
