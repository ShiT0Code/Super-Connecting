﻿#pragma checksum "C:\Users\hbeau\SourceCodes\Super-Connecting\Platform\Windows\UI\Windows\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "363A4E9ED0584797DE2649165752BE9B761F4D921F43D5C8A749464C8ED6E7EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperConnecting_Windows.UI.Windows
{
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2408")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // UI\Windows\MainWindow.xaml line 22
                {
                    this.TitBar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 3: // UI\Windows\MainWindow.xaml line 24
                {
                    this.Nav = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.NavigationView>(target);
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.Nav).SelectionChanged += this.Nav_SelectionChanged;
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.Nav).Loaded += this.Nav_Loaded;
                    ((global::Microsoft.UI.Xaml.Controls.NavigationView)this.Nav).BackRequested += this.Nav_BackRequested;
                }
                break;
            case 4: // UI\Windows\MainWindow.xaml line 45
                {
                    this.mainFrame = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2408")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

