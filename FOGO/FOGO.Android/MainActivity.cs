﻿using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Prism;
using Prism.Ioc;
using ImageCircle.Forms.Plugin.Droid;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;
using Lottie.Forms.Droid;
using FFImageLoading.Forms.Platform;
using PanCardView.Droid;
using IconEntry.FormsPlugin.Android;
using Sharpnado.Presentation.Forms.Droid;
using Plugin.CurrentActivity;

namespace FOGO.Droid
{
    [Activity(Label = "Xport", Icon = "@mipmap/futbol", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = FOGO.Droid.Resource.Layout.Tabbar;
            //ToolbarResource = FOGO.Droid.Resource.Layout.Toolbar;
            //SetTheme(FOGO.Droid.Resource.Style.MainTheme);
            
            base.OnCreate(savedInstanceState);                  
            Forms.SetFlags("CarouselView_Experimental");
            Forms.SetFlags("SwipeView_Experimental");

 

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            IconEntryRenderer.Init();
            CardsViewRenderer.Preserve();
            AnimationViewRenderer.Init();
            ImageCircleRenderer.Init();
            CachedImageRenderer.Init(true);
            SharpnadoInitializer.Initialize();
            CrossCurrentActivity.Current.Init(this, savedInstanceState);


            LoadApplication(new App(new AndroidInitialize()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }


        public class AndroidInitialize : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {

            }
        }
    }
}