using System.Management.Automation;
using static ReFSManagerCore.ReFSManager;

namespace ReFS_Manager_Core
{
    internal static class PowershellResultConverter
    {
        public static VolumeIntegrityStreamSettings ConvertToVolumeIntegrityStreamSettings(this ICollection<PSObject> powershellObject)
        {
            var firstValue = powershellObject.First();

            var test = firstValue.ToString().Split('\n')[3].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            string? volumeName = test[0] ?? throw new InvalidCastException("Couldn't convert powershell results.");

            bool enabled = Convert.ToBoolean(test[1]);
            bool enforced = Convert.ToBoolean(test[2]);
            return new(new(volumeName), enabled, enforced);
        }

        public static int ConvertToFileId(this ICollection<PSObject> powershellObject)
        {
            var asString = powershellObject.First().ToString();
            var split = asString.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            string fileIdInHexaDecimal = split[3];
            var first64Bits = fileIdInHexaDecimal.Skip(2).Take(16).ToArray(); // removes 0x from beginning, but is not necessary.
            return Convert.ToInt32(new string(first64Bits), 16);
        }
    }
}
