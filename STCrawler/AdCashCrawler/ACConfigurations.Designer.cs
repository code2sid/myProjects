﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdCashCrawler {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class ACConfigurations : global::System.Configuration.ApplicationSettingsBase {
        
        private static ACConfigurations defaultInstance = ((ACConfigurations)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ACConfigurations())));
        
        public static ACConfigurations Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://adscash.in/userpanel/browsing_page_updated.php")]
        public string AC_URL {
            get {
                return ((string)(this["AC_URL"]));
            }
            set {
                this["AC_URL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("34119123~378984")]
        public string AC_UsernamePassword {
            get {
                return ((string)(this["AC_UsernamePassword"]));
            }
            set {
                this["AC_UsernamePassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ur AdCash Code")]
        public string Code {
            get {
                return ((string)(this["Code"]));
            }
            set {
                this["Code"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sid")]
        public string theme {
            get {
                return ((string)(this["theme"]));
            }
            set {
                this["theme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string placeholder {
            get {
                return ((string)(this["placeholder"]));
            }
            set {
                this["placeholder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public string ClosePopupsAfter {
            get {
                return ((string)(this["ClosePopupsAfter"]));
            }
            set {
                this["ClosePopupsAfter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2,4,6,8")]
        public string ScheduledHour {
            get {
                return ((string)(this["ScheduledHour"]));
            }
            set {
                this["ScheduledHour"] = value;
            }
        }
    }
}
