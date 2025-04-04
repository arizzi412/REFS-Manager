using ReFS_Manager_Core;
using ReFSManagerCore;
using System.Management.Automation;
using System.Threading.Channels;



var volumes = REFSVolumeProvider.GetREFSVolumes();

var volumeName = volumes.First();

Console.WriteLine(IntegrityStreanSettingsProvider.GetIntegritySettingsInfo(volumeName));

//Console.WriteLine("Disabling");
//FileIntegrityStreamToggler.DisableFileIntegrityStreamsForVolume(a);

//Console.WriteLine(IntegrityStreanSettingsProvider.GetIntegritySettingsInfo(a));


//Console.WriteLine("Enabling");
//FileIntegrityStreamToggler.EnableFileIntegrityStreamsForVolume(a);

//Console.WriteLine(IntegrityStreanSettingsProvider.GetIntegritySettingsInfo(a));

REFSScrubber.ScrubVolume(volumeName);