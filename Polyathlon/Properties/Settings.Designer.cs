﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Polyathlon.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.2.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("admin")]
        public string UserName {
            get {
                return ((string)(this["UserName"]));
            }
            set {
                this["UserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("rsucouch")]
        public string Password {
            get {
                return ((string)(this["Password"]));
            }
            set {
                this["Password"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("127.0.01")]
        public string HostName {
            get {
                return ((string)(this["HostName"]));
            }
            set {
                this["HostName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5984")]
        public string Port {
            get {
                return ((string)(this["Port"]));
            }
            set {
                this["Port"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://127.0.0.1:5984/")]
        public string ModuleBaseName {
            get {
                return ((string)(this["ModuleBaseName"]));
            }
            set {
                this["ModuleBaseName"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>All Customers</Name>
    <FilterCriteria />
  </FilterInfo>
  <FilterInfo>
    <Name>My Account</Name>
    <FilterCriteria>[HomeOffice.State] = ##Enum#DevExpress.DevAV.StateEnum,CA#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>John's Account</Name>
    <FilterCriteria>[HomeOffice.State] = ##Enum#DevExpress.DevAV.StateEnum,WA#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Top Stores</Name>
    <FilterCriteria>[AnnualRevenue] &gt;= 90000000000.0m</FilterCriteria>
  </FilterInfo>
</ArrayOfFilterInfo>")]
        public global::Polyathlon.ViewModels.FilterInfoList RegionCustomFilters {
            get {
                return ((global::Polyathlon.ViewModels.FilterInfoList)(this["RegionCustomFilters"]));
            }
            set {
                this["RegionCustomFilters"] = value;
            }
        }
    }
}
