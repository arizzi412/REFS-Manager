using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace ReFS_Manager_Core;

 public static class PowershellRunner
{
    /// <summary>
    /// Returns null if anything goes wrong.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public static Collection<PSObject> RunCommand(string command)
    {
        using PowerShell ps = PowerShell.Create();
        // Pipe the output to Out-String to get formatted output
        ps.AddScript($"{command} | Out-String");

        var results = ps.Invoke();

        if (ps.HadErrors)
        {
            throw new Exception($"Error in powershell result: {string.Join("\n", ps.Streams.Error)}");
        }

        return results;

    }
}
