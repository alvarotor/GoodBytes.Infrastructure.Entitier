﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoodBytes.Infrastructure.Entitier.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class EntitierStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EntitierStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GoodBytes.Infrastructure.Entitier.Resources.EntitierStrings", typeof(EntitierStrings).Assembly);
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
        ///   Looks up a localized string similar to Cant delete information that is used in another tables or save information that does not exists in another tables..
        /// </summary>
        public static string CantDeleteDataReferencedInTables {
            get {
                return ResourceManager.GetString("CantDeleteDataReferencedInTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Critical Error.
        /// </summary>
        public static string CriticalError {
            get {
                return ResourceManager.GetString("CriticalError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data Not Read. .
        /// </summary>
        public static string DataNotRead {
            get {
                return ResourceManager.GetString("DataNotRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Must provide name..
        /// </summary>
        public static string MustProvideName {
            get {
                return ResourceManager.GetString("MustProvideName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Must provide stored procedure name..
        /// </summary>
        public static string MustProvideSP {
            get {
                return ResourceManager.GetString("MustProvideSP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Must provide value..
        /// </summary>
        public static string MustProvideValue {
            get {
                return ResourceManager.GetString("MustProvideValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Must provide a variable type..
        /// </summary>
        public static string MustProvideVar {
            get {
                return ResourceManager.GetString("MustProvideVar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rows not affected. .
        /// </summary>
        public static string RowsNotAffected {
            get {
                return ResourceManager.GetString("RowsNotAffected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rows not founded. .
        /// </summary>
        public static string RowsNotFounded {
            get {
                return ResourceManager.GetString("RowsNotFounded", resourceCulture);
            }
        }
    }
}