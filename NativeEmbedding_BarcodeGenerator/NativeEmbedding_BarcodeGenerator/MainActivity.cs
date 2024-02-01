using Microsoft.Maui.Embedding;
using Android.App;
using Android.OS;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Barcode;

namespace NativeEmbedding_BarcodeGenerator
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MauiContext? _mauiContext;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
            builder.ConfigureSyncfusionCore();
            MauiApp mauiApp = builder.Build();
            _mauiContext = new MauiContext(mauiApp.Services, this);

            Grid grid = new Grid();
            SfBarcodeGenerator barcode = new SfBarcodeGenerator();
            barcode.Value = "https://www.syncfusion.com/";
            barcode.HeightRequest = 200;
            barcode.WidthRequest = 200;
            barcode.Symbology = new QRCode();
            grid.Children.Add(barcode);
            Android.Views.View view = grid.ToPlatform(_mauiContext);

            // Set our view from the "main" layout resource
            SetContentView(view);
        }
    }
}