﻿#pragma checksum "..\..\..\views\SummaryPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "23157D844B485C3816E4F76DA047D8E3CDD077E9FBA634A8F6D01E562035B87F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekt_WPF.controls;
using Projekt_WPF.conversion2;
using Projekt_WPF.views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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


namespace Projekt_WPF.views {
    
    
    /// <summary>
    /// SummaryPage
    /// </summary>
    public partial class SummaryPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\views\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Projekt_WPF.views.SummaryPage summaryPagevar;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\views\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button print;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\views\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.FlowDocument summaryDocument;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\views\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run nazwaPodsumowania;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\views\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl outcome_list;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\views\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl income_List;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\views\SummaryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataVisualization.Charting.Chart incomeChart;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekt_WPF;component/views/summarypage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\views\SummaryPage.xaml"
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
            this.summaryPagevar = ((Projekt_WPF.views.SummaryPage)(target));
            
            #line 14 "..\..\..\views\SummaryPage.xaml"
            this.summaryPagevar.Loaded += new System.Windows.RoutedEventHandler(this.PageLoad);
            
            #line default
            #line hidden
            return;
            case 2:
            this.print = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.summaryDocument = ((System.Windows.Documents.FlowDocument)(target));
            return;
            case 4:
            this.nazwaPodsumowania = ((System.Windows.Documents.Run)(target));
            return;
            case 5:
            this.outcome_list = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 6:
            this.income_List = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 7:
            this.incomeChart = ((System.Windows.Controls.DataVisualization.Charting.Chart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
