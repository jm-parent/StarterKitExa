using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterKitApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InteractiveSample : ContentView
    {
        public static readonly BindableProperty CSharpCodeProperty = BindableProperty.Create(nameof(CSharpCode), typeof(string), typeof(InteractiveSample), string.Empty);
        public static readonly BindableProperty XamlCodeProperty = BindableProperty.Create(nameof(XamlCode), typeof(string), typeof(InteractiveSample), string.Empty);


        public static readonly BindableProperty IsXamlTabVisibleProperty = BindableProperty.Create(nameof(IsXamlTabVisible), typeof(bool), typeof(InteractiveSample), true);
        public static readonly BindableProperty IsCSharpTabVisibleProperty = BindableProperty.Create(nameof(IsCSharpTabVisible), typeof(bool), typeof(InteractiveSample), true);



        public bool IsXamlTabVisible
        {
            get => (bool)GetValue(IsXamlTabVisibleProperty);
            set => SetValue(IsXamlTabVisibleProperty, value);
        }
        public bool IsCSharpTabVisible
        {
            get => (bool)GetValue(IsCSharpTabVisibleProperty);
            set => SetValue(IsCSharpTabVisibleProperty, value);
        }

        public string CSharpCode
        {
            get => (string)GetValue(CSharpCodeProperty);
            set => SetValue(CSharpCodeProperty, value);
        }

        public string XamlCode
        {
            get => (string)GetValue(XamlCodeProperty);
            set => SetValue(XamlCodeProperty, value);
        }
        public InteractiveSample()
        {
            InitializeComponent();
        }
    }
}