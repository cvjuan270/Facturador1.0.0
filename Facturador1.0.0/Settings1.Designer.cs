﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Facturador1._0._0 {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
    internal sealed partial class Settings1 : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings1 defaultInstance = ((Settings1)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings1())));
        
        public static Settings1 Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("data source = WIN-N0KOJNSL9KV; initial catalog = FACTURADOR01; user id = sa; pass" +
            "word = Dv123456789")]
        public string Cade_Conexion {
            get {
                return ((string)(this["Cade_Conexion"]));
            }
            set {
                this["Cade_Conexion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:9000/")]
        public string RutaSFS {
            get {
                return ((string)(this["RutaSFS"]));
            }
            set {
                this["RutaSFS"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("d:\\\\SFS_v1.2\\sunat_archivos\\sfs\\DATA\\")]
        public string DirectorioDATA {
            get {
                return ((string)(this["DirectorioDATA"]));
            }
            set {
                this["DirectorioDATA"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20558326256")]
        public string RUC {
            get {
                return ((string)(this["RUC"]));
            }
            set {
                this["RUC"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F001")]
        public string SerieFactura {
            get {
                return ((string)(this["SerieFactura"]));
            }
            set {
                this["SerieFactura"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("d:\\\\SFS_v1.2\\sunat_archivos\\sfs\\REPO\\")]
        public string DirectorioREPO {
            get {
                return ((string)(this["DirectorioREPO"]));
            }
            set {
                this["DirectorioREPO"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Microsoft Print to PDF")]
        public string NombreIMPRESORA {
            get {
                return ((string)(this["NombreIMPRESORA"]));
            }
            set {
                this["NombreIMPRESORA"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("segurimax_80@hotmail.com")]
        public string Correo {
            get {
                return ((string)(this["Correo"]));
            }
            set {
                this["Correo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("j21np33l")]
        public string PassCorreo {
            get {
                return ((string)(this["PassCorreo"]));
            }
            set {
                this["PassCorreo"] = value;
            }
        }
    }
}
