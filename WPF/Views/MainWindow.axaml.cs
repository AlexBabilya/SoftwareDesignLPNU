using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Net.Http;
using WPF.ViewModels;
using WPF.Models;

namespace WPF.Views;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel viewModel;
    public MainWindow()
    {
        InitializeComponent();
        viewModel = new MainWindowViewModel(); 
        DataContext = viewModel.Authors;
    }
    
    private async void ProcessRequest(object sender, RoutedEventArgs e)
    {
        var id = IdTextBox.Text;
        var firstName = FirstNameTextBox.Text;
        var lastName = LastNameTextBox.Text;
        var birthdate = BirthdateDatePicker.SelectedDate; 
        var nationality = NationalityTextBox.Text;
        
        if (id == null)
            ((MainWindowViewModel)DataContext).AddAsync(firstName, lastName, birthdate, nationality);
        else 
            ((MainWindowViewModel)DataContext).UpdateAsync(id, firstName, lastName, birthdate, nationality);
        
        ClearTextBoxes();
    }

    private async void UpdateAuthor(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Author data)
        {
            IdTextBox.Text = data.id.ToString();
            FirstNameTextBox.Text = data.FirstName;
            LastNameTextBox.Text = data.LastName;
            BirthdateDatePicker.SelectedDate = data.Birthdate; 
            NationalityTextBox.Text = data.Nationality;
        }
    }

    private void ClearTextBoxes()
    {
        IdTextBox.Text = null;
        FirstNameTextBox.Text = "";
        LastNameTextBox.Text = "";
        BirthdateDatePicker.SelectedDate = null; 
        NationalityTextBox.Text = "";
    }

    private void DeleteAuthor(object sender, RoutedEventArgs args)
    {
        if (sender is Button button)
        {
            string id = button.Tag?.ToString();

            if (id != null)
            {
            ((MainWindowViewModel)DataContext).DeleteAsync(id);        
            }
        }
    }
}