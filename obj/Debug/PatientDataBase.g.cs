﻿#pragma checksum "..\..\PatientDataBase.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C078E88654905E71E97EEE53575123BCD476AD65C005A09A683F8E5E4B59A5D3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CalendarSolution;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CalendarSolution {
    
    
    /// <summary>
    /// PatientDataBase
    /// </summary>
    public partial class PatientDataBase : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\PatientDataBase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label patientLabel;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\PatientDataBase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frame1;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\PatientDataBase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas graphCanvas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CalendarSolution;component/patientdatabase.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PatientDataBase.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.patientLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            
            #line 36 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenVital);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 37 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenHist);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 38 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenDemo);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 39 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenImmune);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 40 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenUrinalysis);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 41 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenLab);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 42 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Progress);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 44 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UploadImage);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 45 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenImage);
            
            #line default
            #line hidden
            return;
            case 11:
            this.frame1 = ((System.Windows.Controls.Frame)(target));
            return;
            case 12:
            this.graphCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 13:
            
            #line 52 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenGraph);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 54 "..\..\PatientDataBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.genFile);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

