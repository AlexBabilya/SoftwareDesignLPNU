using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WPF.Models;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json; 
using System.Text;
using System.Windows.Input;

namespace WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Author> Authors { get; }
        public string Greeting => "Welcome!";
        
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }

        public MainWindowViewModel()
        {
            Authors = new ObservableCollection<Author>();
            LoadAuthorsAsync();

            AddCommand = new RelayCommand<Author>(AddAsync);
            DeleteCommand = new RelayCommand<Author>(DeleteAsync);
            UpdateCommand = new RelayCommand<Author>(UpdateAsync);
        }

        private async void LoadAuthorsAsync()
        {
            try
            {
                string apiUrl = "http://localhost:5004/api/authors";

                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(apiUrl))
                {
                    response.EnsureSuccessStatusCode(); 

                    List<Author> authors = await response.Content.ReadAsAsync<List<Author>>();
                    foreach (var author in authors)
                    {
                        Authors.Add(author);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading authors: {ex.Message}");
            }
        }

        public async void DeleteAsync(object authorObject)
        {
            try
            {   
                if (authorObject is Author author)
                {
                    int id = author.id;  // Access the id property directly

                    string apiUrl = $"http://localhost:5004/api/authors/{id}";
                    Console.Write(apiUrl);
                    
                    using (HttpClient client = new HttpClient())
                    using (HttpResponseMessage response = await client.DeleteAsync(apiUrl))
                    {
                        response.EnsureSuccessStatusCode(); 

                        var authorToRemove = Authors.FirstOrDefault(a => a.id == id);
                        if (authorToRemove != null)
                        {
                            Authors.Remove(authorToRemove);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting author: {ex.Message}");
            }
        }

        public async void AddAsync(object authorObject)
        {
            try
            {   
                if (authorObject is Author author)
                {
                    string apiUrl = "http://localhost:5004/api/authors/";

                    // Assuming authorObject has properties like FirstName, LastName, Birthdate, and Nationality
                    var authorData = new
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        Birthdate = author.Birthdate,
                        Nationality = author.Nationality
                    };

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(authorData), Encoding.UTF8, "application/json");
                    
                    using (HttpClient client = new HttpClient())
                    using (HttpResponseMessage response = await client.PostAsync(apiUrl, jsonContent))
                    {
                        response.EnsureSuccessStatusCode();

                        var newAuthor = JsonConvert.DeserializeObject<Author>(await response.Content.ReadAsStringAsync());
                        Authors.Add(newAuthor);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding author: {ex.Message}");
            }
        }

        private T GetPropertyValue<T>(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            return property != null ? (T)property.GetValue(obj) : default;
        }

        public async void UpdateAsync(object authorObject)
        {
            try
            {
                if (authorObject is Author author)
                {
                    string apiUrl = $"http://localhost:5004/api/authors/{author.id}";

                    var updatedAuthorData = new
                    {
                        id = author.id,
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        Birthdate = author.Birthdate,
                        Nationality = author.Nationality
                    };

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(updatedAuthorData), Encoding.UTF8, "application/json");

                    using (HttpClient client = new HttpClient())
                    using (HttpResponseMessage response = await client.PutAsync(apiUrl, jsonContent))
                    {
                        response.EnsureSuccessStatusCode(); 

                        await response.Content.ReadAsStringAsync();
                    
                        var existingAuthor = Authors.FirstOrDefault(author => author.id == author.id);
                        if (existingAuthor != null)
                        {
                            int index = Authors.IndexOf(existingAuthor);
                            Authors[index] = author;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating author: {ex.Message}");
            }
        }
    }
}
