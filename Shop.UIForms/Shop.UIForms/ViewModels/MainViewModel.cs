﻿using Shop.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Shop.UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance;
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public TokenResponse Token { get; set; }
        public LoginViewModel Login { get; set; }

        public  ProductsViewModel Products { get; set; }

        public MainViewModel()
        {
            this.LoadMenus();
            instance = this;
        }

        private void LoadMenus()
        {
            var menus = new List<Menu>
    {
        new Menu
        {
            Icon = "ic_infolauncher",
            PageName = "AboutPage",
            Title = "About"
        },

        new Menu
        {
            Icon = "ic_setuplauncher",
            PageName = "SetupPage",
            Title = "Setup"
        },

        new Menu
        {
            Icon = "ic_exitlauncher",
            PageName = "LoginPage",
            Title = "Close session"
        }
    };

            this.Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }


        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }

    }
}
