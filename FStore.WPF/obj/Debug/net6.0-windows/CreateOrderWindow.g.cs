﻿#pragma checksum "..\..\..\CreateOrderWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EBC88E200CFF16608C9AC75AF45091D4113588B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FStore.SalesWPFApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FStore.SalesWPFApp {
    
    
    /// <summary>
    /// CreateOrderWindow
    /// </summary>
    public partial class CreateOrderWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbProducts;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQuantity;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDiscount;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddOrderDetail;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridOrderDetails;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateOrder;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\CreateOrderWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FStore.SalesWPFApp;component/createorderwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateOrderWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbProducts = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.txtQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtDiscount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnAddOrderDetail = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\CreateOrderWindow.xaml"
            this.btnAddOrderDetail.Click += new System.Windows.RoutedEventHandler(this.btnAddOrderDetail_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataGridOrderDetails = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnCreateOrder = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\CreateOrderWindow.xaml"
            this.btnCreateOrder.Click += new System.Windows.RoutedEventHandler(this.btnCreateOrder_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\CreateOrderWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

