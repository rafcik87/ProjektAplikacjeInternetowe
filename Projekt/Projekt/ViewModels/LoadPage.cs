﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Projekt.ViewModels
{
    public class LoadPage : ContentPage
    {
        public LoadPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Witaj w aplikacji" }
                }
            };
        }
    }
}