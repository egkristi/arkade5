﻿using System;
using System.Diagnostics;
using System.Windows;
using Arkivverket.Arkade.Core;
using Arkivverket.Arkade.UI.Properties;
using Arkivverket.Arkade.UI.Util;
using Arkivverket.Arkade.Util;
using Serilog;

namespace Arkivverket.Arkade.UI
{
    public partial class App : Application
    {
        private static ILogger Log;

        public App()
        {
            try
            {
                ArkadeProcessingArea.Establish(Settings.Default.ArkadeProcessingAreaLocation);
            }
            catch (Exception e)
            {
                Trace.WriteLine("Exception while establishing arkade processing area: " + e.Message);
            }

            LogConfiguration.ConfigureSeriLog();
            Log = Serilog.Log.ForContext<App>();
            // For some reason this will not work for exceptions thrown from inside the Views.
            AppDomain.CurrentDomain.UnhandledException += MyHandler;
        }

        public static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var e = (Exception) args.ExceptionObject;
            new DetailedExceptionMessage(e).ShowMessageBox();
            Log.Error("Unexpected exception", e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Log.Information("Arkade " + ArkadeVersion.Version + " started");

            base.OnStartup(e);
            var bs = new Bootstrapper();
            bs.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Log.Information("Arkade " + ArkadeVersion.Version + " stopping");

            if (!ArkadeProcessingAreaLocationSetting.IsApplied())
                ArkadeProcessingArea.Destroy();
            else
                ArkadeProcessingArea.CleanUp();

            base.OnExit(e);
        }
    }
}