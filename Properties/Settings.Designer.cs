﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrawlSoundConverter.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("./smashbros_sound.brsar")]
        public string DefaultBrsarFilePath {
            get {
                return ((string)(this["DefaultBrsarFilePath"]));
            }
            set {
                this["DefaultBrsarFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int DefaultSAWNDExportNameScheme {
            get {
                return ((int)(this["DefaultSAWNDExportNameScheme"]));
            }
            set {
                this["DefaultSAWNDExportNameScheme"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DefaultMultiWAVExportCreateGroupDirectory {
            get {
                return ((bool)(this["DefaultMultiWAVExportCreateGroupDirectory"]));
            }
            set {
                this["DefaultMultiWAVExportCreateGroupDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnableFullLengthNames {
            get {
                return ((bool)(this["EnableFullLengthNames"]));
            }
            set {
                this["EnableFullLengthNames"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int ConvertToMono {
            get {
                return ((int)(this["ConvertToMono"]));
            }
            set {
                this["ConvertToMono"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>TABS</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection TabSettings {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["TabSettings"]));
            }
            set {
                this["TabSettings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int MatchSampleRate {
            get {
                return ((int)(this["MatchSampleRate"]));
            }
            set {
                this["MatchSampleRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("44100")]
        public int MaximumSampleRate {
            get {
                return ((int)(this["MaximumSampleRate"]));
            }
            set {
                this["MaximumSampleRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("950000")]
        public int GroupSizeWarningThreshold {
            get {
                return ((int)(this["GroupSizeWarningThreshold"]));
            }
            set {
                this["GroupSizeWarningThreshold"] = value;
            }
        }
    }
}
