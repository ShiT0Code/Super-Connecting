﻿#pragma checksum "C:\Users\hbeau\SourceCodes\Super-Connecting\Platform\Windows\UI\Pages\MainPages\SettingsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EEF53B0C6778BDC7552ED11A9B288F88BD5B5C344FCD6B29131CEFD398AF5113"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperConnecting_Windows.UI.Pages.MainPages
{
    partial class SettingsPage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // UI\Pages\MainPages\SettingsPage.xaml line 17
                {
                    global::Microsoft.UI.Xaml.Controls.SelectorBar element2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.SelectorBar>(target);
                    ((global::Microsoft.UI.Xaml.Controls.SelectorBar)element2).SelectionChanged += this.SelectorBar_SelectionChanged;
                }
                break;
            case 3: // UI\Pages\MainPages\SettingsPage.xaml line 25
                {
                    this.SettingFrame = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2409")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

