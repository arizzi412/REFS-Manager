namespace ReFS_Manager_Core;

public static class REFSVolumeProvider
{
    /// <summary>
    /// Retrieves a list of all volumes on the system formatted with ReFS.
    /// </summary>
    /// <returns>A List of Volume objects representing the ReFS volumes found.</returns>
    /// <remarks>
    /// This method queries all logical drives, checks if they are ready and
    /// if their file system format is "ReFS".
    /// It handles potential exceptions during drive property access gracefully
    /// by skipping drives that cause issues (e.g., unready drives).
    /// </remarks>
    public static List<VolumeName> GetREFSVolumes()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        return [.. allDrives.Where(x => x.IsReady && string.Equals(x.DriveFormat, "ReFS", StringComparison.OrdinalIgnoreCase)).Select(x => new VolumeName(x.Name))];

    }


}