﻿using PawPalsApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawPalsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaMenu : TabbedPage
    {
        public PaginaMenu()
        {
            InitializeComponent();
            ConnectionHelper.StartConnection();
        }
    }
}