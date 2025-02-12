﻿using System.Diagnostics;

namespace Arkivverket.Arkade.GUI.Util
{
    public static class ArkadeInstance
    {
        public static Process Process => Process.GetCurrentProcess();
        public static bool IsOnlyInstance => Process.GetProcessesByName(Process.ProcessName).Length == 1;
        public static bool IsClearedToShutDown { get; private set; }

        public static void ClearToShutDown()
        {
            IsClearedToShutDown = true;
        }
    }
}
