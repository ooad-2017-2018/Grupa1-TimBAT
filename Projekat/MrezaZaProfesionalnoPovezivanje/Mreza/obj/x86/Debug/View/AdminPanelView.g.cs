﻿#pragma checksum "D:\Adnan\Google Drive\ETF\Cetvrti semestar\OOAD\Grupa1-TimBAT\Projekat\MrezaZaProfesionalnoPovezivanje\Mreza\View\AdminPanelView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BF20EF7081F00F709BFB55394DB450C7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mreza.View
{
    partial class AdminPanel : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.AdminPanel1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                }
                break;
            case 2:
                {
                    this.Pretraga = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    #line 100 "..\..\..\View\AdminPanelView.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.Pretraga).TextChanged += this.Pretraga_TextChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.AutoriProjekta = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 101 "..\..\..\View\AdminPanelView.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.AutoriProjekta).SelectionChanged += this.AutoriProjekta_SelectionChanged;
                    #line default
                }
                break;
            case 4:
                {
                    this.Projekti = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 5:
                {
                    this.korisnik = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    #line 52 "..\..\..\View\AdminPanelView.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.korisnik).TextChanged += this.korisnik_TextChanged;
                    #line default
                }
                break;
            case 6:
                {
                    this.korisnici = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

