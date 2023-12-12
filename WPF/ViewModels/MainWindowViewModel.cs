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

namespace WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Author> Authors { get; }
        public string Greeting => "Weasdlonia!";

        public MainWindowViewModel()
        {
            Authors = new ObservableCollection<Author>();
            LoadAuthorsAsync();
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

        public async void DeleteAsync(string id)
        {
            try
            {
                string apiUrl = $"http://localhost:5004/api/authors/{id}";

                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.DeleteAsync(apiUrl))
                {
                    response.EnsureSuccessStatusCode(); 

                    var authorToRemove = Authors.FirstOrDefault(author => author.id == int.Parse(id));
                    if (authorToRemove != null)
                    {
                        Authors.Remove(authorToRemove);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting author: {ex.Message}");
            }
        }

        public async void AddAsync(string firstName, string lastName, DateTimeOffset? birthdate, string nationality)
        {
            try
            {
                string apiUrl = "http://localhost:5004/api/authors/";

                var authorData = new
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Birthdate = birthdate,
                    Nationality = nationality
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding author: {ex.Message}");
            }
        }

        public async void UpdateAsync(string update_id, string firstName, string lastName, DateTimeOffset? birthdate, string nationality)
        {
            try
            {
                string apiUrl = $"http://localhost:5004/api/authors/{update_id}";

                var updatedAuthorData = new
                {
                    id = update_id,
                    FirstName = firstName,
                    LastName = lastName,
                    Birthdate = birthdate,
                    Nationality = nationality
                };

                var jsonContent = new StringContent(JsonConvert.SerializeObject(updatedAuthorData), Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.PutAsync(apiUrl, jsonContent))
                {
                    response.EnsureSuccessStatusCode(); 

                    await response.Content.ReadAsStringAsync();
                   
                    var existingAuthor = Authors.FirstOrDefault(author => author.id == int.Parse(update_id));
                    if (existingAuthor != null)
                    {
                        int index = Authors.IndexOf(existingAuthor);
                        Authors[index] = new Author(int.Parse(update_id), firstName, lastName, birthdate, nationality);
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
