//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arkivverket.Arkade.Core.Resources {
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
    internal class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Arkivverket.Arkade.Core.Resources.ExceptionMessages", typeof(ExceptionMessages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TestRun for the test {0} with ID {1} was not added to test suite. Probable cause: Another test has already been added with the same ID.
        /// </summary>
        internal static string AddTestRunToTestSuite {
            get {
                return ResourceManager.GetString("AddTestRunToTestSuite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Prosessområde er ikke satt..
        /// </summary>
        internal static string ArkadeProcessAreaNotSet {
            get {
                return ResourceManager.GetString("ArkadeProcessAreaNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Arkade klarte ikke å finne informasjon om {0} i {1}.
        /// </summary>
        internal static string FileDescriptionParseError {
            get {
                return ResourceManager.GetString("FileDescriptionParseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finner ikke filen: {0}.
        /// </summary>
        internal static string FileNotFound {
            get {
                return ResourceManager.GetString("FileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Kunne ikke lese inn filen: {0}.
        /// </summary>
        internal static string FileNotRead {
            get {
                return ResourceManager.GetString("FileNotRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Kunne ikke kombinere {0} og {1}.
        /// </summary>
        internal static string PathCombine {
            get {
                return ResourceManager.GetString("PathCombine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Arkade klarte ikke å tolke informasjon om periodeskille i {0}.
        /// </summary>
        internal static string PeriodSeparationParseError {
            get {
                return ResourceManager.GetString("PeriodSeparationParseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown package type: {0}.
        /// </summary>
        internal static string UnknownPackageType {
            get {
                return ResourceManager.GetString("UnknownPackageType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Linje {0}: {1}.
        /// </summary>
        internal static string XmlValidationErrorMessage {
            get {
                return ResourceManager.GetString("XmlValidationErrorMessage", resourceCulture);
            }
        }
    }
}
