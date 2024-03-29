﻿using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using FOGO.Models;
using FOGO.Services;
using FOGO.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FOGO.ViewModels
{
    public class MenuViewModel: BaseViewModel, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<string> onNavigate { get; set; }       
        public User User { get; set; } = new User();         
        ISqliteInterface sqlite;
        public MenuViewModel(INavigationService navigation, ISqliteInterface sqliteInterface, IPageDialogService pageDialog):base(pageDialog,navigation)
        {           
            onNavigate = new DelegateCommand<string>(Navigate);
            if (Device.RuntimePlatform == Device.UWP)
            {
                User.Name = "User";
            }
            else if(Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                sqlite = sqliteInterface;
                var profile = sqlite.GetConnection().Query<User>("select * from User");               
                User.Name = profile.First().Name;
            }
           
            
        }
        async void Navigate(string page)
        {
            await NavigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }      
    }
}
