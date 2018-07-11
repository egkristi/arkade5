﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Koden er generert av et verktøy.
//     Kjøretidsversjon:4.0.30319.42000
//
//     Endringer i denne filen kan føre til feil virkemåte, og vil gå tapt hvis
//     koden genereres på nytt.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace Arkivverket.Arkade.ExternalModels.Info {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="www.arkivverket.no/standarder/info")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="www.arkivverket.no/standarder/info", IsNullable=false)]
    public partial class info {
        
        private infoAktor aktorField;
        
        private infoUttrekk uttrekkField;
        
        private infoSystem systemField;
        
        private infoFil[] sjekksummerField;
        
        private infoIntegritetsInfo integritetsInfoField;
        
        private string[] krypteringField;
        
        private string[] kommentarField;
        
        private string pakkeIDField;
        
        /// <remarks/>
        public infoAktor aktor {
            get {
                return this.aktorField;
            }
            set {
                this.aktorField = value;
            }
        }
        
        /// <remarks/>
        public infoUttrekk uttrekk {
            get {
                return this.uttrekkField;
            }
            set {
                this.uttrekkField = value;
            }
        }
        
        /// <remarks/>
        public infoSystem system {
            get {
                return this.systemField;
            }
            set {
                this.systemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("fil", IsNullable=false)]
        public infoFil[] sjekksummer {
            get {
                return this.sjekksummerField;
            }
            set {
                this.sjekksummerField = value;
            }
        }
        
        /// <remarks/>
        public infoIntegritetsInfo integritetsInfo {
            get {
                return this.integritetsInfoField;
            }
            set {
                this.integritetsInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("nokkel", IsNullable=false)]
        public string[] kryptering {
            get {
                return this.krypteringField;
            }
            set {
                this.krypteringField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("kommentar")]
        public string[] kommentar {
            get {
                return this.kommentarField;
            }
            set {
                this.kommentarField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pakkeID {
            get {
                return this.pakkeIDField;
            }
            set {
                this.pakkeIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="www.arkivverket.no/standarder/info")]
    public partial class infoAktor {
        
        private infoAktorAktorType aktorTypeField;
        
        /// <remarks/>
        public infoAktorAktorType aktorType {
            get {
                return this.aktorTypeField;
            }
            set {
                this.aktorTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="www.arkivverket.no/standarder/info")]
    public partial class infoAktorAktorType {
        
        private infoAktorAktorTypeRolle rolleField;
        
        private kontaktPerson kontaktpersonField;
        
        /// <remarks/>
        public infoAktorAktorTypeRolle rolle {
            get {
                return this.rolleField;
            }
            set {
                this.rolleField = value;
            }
        }
        
        /// <remarks/>
        public kontaktPerson kontaktperson {
            get {
                return this.kontaktpersonField;
            }
            set {
                this.kontaktpersonField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="www.arkivverket.no/standarder/info")]
    public partial class infoAktorAktorTypeRolle {
        
        private string navnField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string navn {
            get {
                return this.navnField;
            }
            set {
                this.navnField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="www.arkivverket.no/standarder/info")]
    public partial class kontaktPerson {
        
        private string telefonField;
        
        private string ePostField;
        
        private string navnField;
        
        /// <remarks/>
        public string telefon {
            get {
                return this.telefonField;
            }
            set {
                this.telefonField = value;
            }
        }
        
        /// <remarks/>
        public string ePost {
            get {
                return this.ePostField;
            }
            set {
                this.ePostField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string navn {
            get {
                return this.navnField;
            }
            set {
                this.navnField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="www.arkivverket.no/standarder/info")]
    public partial class infoUttrekk {
        
        private type typeField;
        
        private object typeVersjonField;
        
        /// <remarks/>
        public type type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public object typeVersjon {
            get {
                return this.typeVersjonField;
            }
            set {
                this.typeVersjonField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="www.arkivverket.no/standarder/info")]
    public enum type {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Noark 3")]
        Noark3,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Noark 4")]
        Noark4,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Noark 5")]
        Noark5,
        
        /// <remarks/>
        Fagsystem,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="www.arkivverket.no/standarder/info")]
    public partial class infoSystem {
        
        private type systemTypeField;
        
        private string systemNavnField;
        
        private string versjonField;
        
        /// <remarks/>
        public type systemType {
            get {
                return this.systemTypeField;
            }
            set {
                this.systemTypeField = value;
            }
        }
        
        /// <remarks/>
        public string systemNavn {
            get {
                return this.systemNavnField;
            }
            set {
                this.systemNavnField = value;
            }
        }
        
        /// <remarks/>
        public string versjon {
            get {
                return this.versjonField;
            }
            set {
                this.versjonField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="www.arkivverket.no/standarder/info")]
    public partial class infoFil {
        
        private string sjekksumField;
        
        private string algoritmeField;
        
        private string filnavnField;
        
        /// <remarks/>
        public string sjekksum {
            get {
                return this.sjekksumField;
            }
            set {
                this.sjekksumField = value;
            }
        }
        
        /// <remarks/>
        public string algoritme {
            get {
                return this.algoritmeField;
            }
            set {
                this.algoritmeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string filnavn {
            get {
                return this.filnavnField;
            }
            set {
                this.filnavnField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="www.arkivverket.no/standarder/info")]
    public partial class infoIntegritetsInfo {
        
        private string konverteringsHistorikkField;
        
        private string kommentarField;
        
        public infoIntegritetsInfo() {
            this.kommentarField = "";
        }
        
        /// <remarks/>
        public string konverteringsHistorikk {
            get {
                return this.konverteringsHistorikkField;
            }
            set {
                this.konverteringsHistorikkField = value;
            }
        }
        
        /// <remarks/>
        public string kommentar {
            get {
                return this.kommentarField;
            }
            set {
                this.kommentarField = value;
            }
        }
    }
}
