﻿#pragma checksum "C:\Users\hbeau\SourceCodes\Super-Connecting\Platform\Windows\UI\Pages\MainPages\AddDevicePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "49C8EF5ED2BC8D9087C7619FD81FB6C08FF3A3F4D478583FDC667A23E320FC3A"
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
    partial class AddDevicePage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
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
            case 2: // UI\Pages\MainPages\AddDevicePage.xaml line 37
                {
                    this.Message = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.InfoBar>(target);
                }
                break;
            case 3: // UI\Pages\MainPages\AddDevicePage.xaml line 48
                {
                    this.sendBu = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.sendBu).Click += this.Button_Click;
                }
                break;
            case 4: // UI\Pages\MainPages\AddDevicePage.xaml line 52
                {
                    this.sending = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ProgressRing>(target);
                }
                break;
            case 5: // UI\Pages\MainPages\AddDevicePage.xaml line 54
                {
                    this.finished = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.FontIcon>(target);
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

