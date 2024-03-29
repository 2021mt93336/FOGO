﻿using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using FOGO.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOGO.ViewModels
{
    public class ChampionsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;       
        public IList<League> Leagues { get; set; } = new ObservableCollection<League>();            
        public IList<Seasons> Seasons { get; set; } = new ObservableCollection<Seasons>();
        public bool Status { get; set; }
        public bool Loading { get; set; }
        Competitions League { get; set; } = new Competitions();         
        public string Crest { get; set; }
        public Links Links { get; set; } = new Links();
        INavigationService navigation;
        IApiServices apiServices;
        public DelegateCommand GetLeaguesCommand { get; set; }
        League Leaguess;
        public League LeagueSelected //Select element in picker//
        {
            get
            {
                return Leaguess;
            }
            set
            {
                Leaguess = value;
                if (Leaguess != null)
                {                   
                    GetLeaguesChampions(Leaguess.Id);
                }
            }
        }

        public ChampionsViewModel(IApiServices api, INavigationService navigationService)
        {
            navigation = navigationService;            
            apiServices = api;
            GetLeaguesCommand = new DelegateCommand(async () => await GetLeagues());
            GetLeaguesCommand.Execute();
        }
        async Task GetLeagues()
        {
            try
            {
                RestService.For<IApiServices>(Links.url);
                var response1 = await apiServices.GetLeagues();
                League = response1;
                var show = League.competitions.Where(elemento => elemento.Id == 2002 || elemento.Id == 2021);
                this.Leagues = show.ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error en el metodo Leagues: {e.Message}");
            }
        }
        async void GetLeaguesChampions(int param)
        {
            try
            {
                Loading = true;
                Status = false;
                RestService.For<IApiServices>(Links.url);
                var response1 = await apiServices.GetLeagues(param);               
                var show = response1;                
                this.Seasons = show.seasons;
                Loading = false;
                Status = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error en el metodo LeaguesChampions: {e.Message}");
                Loading = true;
                Status = false;
            }
        }
    }
}
