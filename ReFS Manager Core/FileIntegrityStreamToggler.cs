namespace ReFS_Manager_Core;

public static class FileIntegrityStreamToggler
{
    public static void EnableFileIntegrityStreamsForVolume(VolumeName volume)
    {
        var command = $@"Set-FileIntegrity {volume} -Enable $True";
        PowershellRunner.RunCommand(command);
    }

    public static void DisableFileIntegrityStreamsForVolume(VolumeName volume)
    {
        var command = $@"Set-FileIntegrity {volume} -Enable $False";
        PowershellRunner.RunCommand(command);
    }
}
