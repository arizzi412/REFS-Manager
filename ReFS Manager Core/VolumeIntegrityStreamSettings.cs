using ReFS_Manager_Core;

namespace ReFSManagerCore;

public partial class ReFSManager
{
    public record VolumeIntegrityStreamSettings(VolumeName VolumeName, bool Enabled, bool Enforced);

}