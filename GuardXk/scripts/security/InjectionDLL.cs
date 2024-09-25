using System;
using System.Diagnostics;
using System.Linq;

namespace GuardXk.Security{
    public class InjectionDLL{
        public bool Check(){
            var trustedModules = new[] {
                "alpha xk.exe",
                "ntdll.dll",
                "kernel32.dll",
                "kernelbase.dll",
                "user32.dll",
                "kernelbase.dll"
            };
            var intrusionDetected = Process.GetCurrentProcess().Modules.Cast<ProcessModule>().Any(module => !trustedModules.Contains(module.ModuleName.ToLowerInvariant()));
            foreach(var item in Process.GetCurrentProcess().Modules.Cast<ProcessModule>())
                Console.WriteLine(item.ModuleName.ToLowerInvariant());

            if(!intrusionDetected)
                return true;
            return false;
        }
    }
}