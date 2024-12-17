﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Cafe.ViewModels;

namespace Cafe.Views;

public partial class AuthorizationView : Window
{
    public AuthorizationView()
    {
        InitializeComponent();
        DataContext = new AuthorizationViewModel();
    }
}