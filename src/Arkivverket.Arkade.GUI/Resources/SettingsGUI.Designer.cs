﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arkivverket.Arkade.GUI.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SettingsGUI {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SettingsGUI() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Arkivverket.Arkade.GUI.Resources.SettingsGUI", typeof(SettingsGUI).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lagre.
        /// </summary>
        public static string ArkadeProcessingAreaLocation_ApplyButtonText {
            get {
                return ResourceManager.GetString("ArkadeProcessingAreaLocation_ApplyButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avbryt.
        /// </summary>
        public static string ArkadeProcessingAreaLocation_CancelButtonText {
            get {
                return ResourceManager.GetString("ArkadeProcessingAreaLocation_CancelButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Endre ....
        /// </summary>
        public static string ArkadeProcessingAreaLocation_EditButtonText {
            get {
                return ResourceManager.GetString("ArkadeProcessingAreaLocation_EditButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Arkades prosesseringsområde.
        /// </summary>
        public static string ArkadeProcessingAreaLocation_Header {
            get {
                return ResourceManager.GetString("ArkadeProcessingAreaLocation_Header", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Arkades prosesseringsområde er en katalog &quot;Arkade&quot; der midlertidige filer blir plassert under prosessering av arkivutrekk og der hvor system- og feillogger lagres. Du må velge en egnet plassering for denne katalogen..
        /// </summary>
        public static string ArkadeProcessingAreaLocation_Info {
            get {
                return ResourceManager.GetString("ArkadeProcessingAreaLocation_Info", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NB! Prosesseringsområdet vil potensielt inneholde sensitive data og store datamengder..
        /// </summary>
        public static string ArkadeProcessingAreaLocation_Warning {
            get {
                return ResourceManager.GetString("ArkadeProcessingAreaLocation_Warning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vennligst avslutt andre instanser av Arkade før du endrer plassering av prosesseringområdet..
        /// </summary>
        public static string OtherInstancesRunningOnProcessingAreaChangeMessage {
            get {
                return ResourceManager.GetString("OtherInstancesRunningOnProcessingAreaChangeMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vennligst velg et prosesseringsområde som er tilgjengelig for Arkade.
        /// </summary>
        public static string UndefinedArkadeProcessingAreaLocationDialogMessage {
            get {
                return ResourceManager.GetString("UndefinedArkadeProcessingAreaLocationDialogMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Gyldig prosesseringsområde mangler.
        /// </summary>
        public static string UndefinedArkadeProcessingAreaLocationDialogTitle {
            get {
                return ResourceManager.GetString("UndefinedArkadeProcessingAreaLocationDialogTitle", resourceCulture);
            }
        }
    }
}