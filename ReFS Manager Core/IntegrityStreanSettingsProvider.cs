using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReFSManagerCore.ReFSManager;

namespace ReFS_Manager_Core;

public static class IntegrityStreanSettingsProvider
{
    public static VolumeIntegrityStreamSettings GetIntegritySettingsInfo(VolumeName volume)
    {
        var obj = PowershellRunner.RunCommand($@"Get-FileIntegrity {volume}");

        var result = PowershellResultConverter.ConvertToVolumeIntegrityStreamSettings(obj);

        return result;
    }
}
