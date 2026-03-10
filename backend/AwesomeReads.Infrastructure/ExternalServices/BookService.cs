using AwesomeReads.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;

namespace AwesomeReads.Infrastructure.ExternalServices
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpService)
        {
            _httpClient = httpService;
        }

        public async Task<BookServiceViewModel> ConsultBookByIsbnAsync(string isbn)
        {
            var response = await _httpClient.GetAsync($"https://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&format=json&jscmd=data");

            if(!response.IsSuccessStatusCode)
                throw new Exception($"Failed to fetch book data. Status code: {response.StatusCode}");


            var dict = await response.Content.ReadFromJsonAsync<Dictionary<string, OpenLibraryBookDataDto>>();

            var key = $"ISBN:{isbn}";
            dict!.TryGetValue(key, out var book);

            return new BookServiceViewModel{
                    Isbn = isbn,
                    Titulo = book?.Title ?? "Título não disponível",
                    DataPublicacao = DateTime.TryParse(book?.PublishDate, out var publishDate) ? publishDate : DateTime.MinValue,
                    Autores = book?.Authors?.Select(a => a.Name).ToList() ?? new List<string>(),
                    Editoras = book?.Publishers?.Select(p => p.Name).ToList() ?? new List<string>(),
                    Assuntos = book?.Subjects?.Select(s => s.Name).ToList() ?? new List<string>(),
                    UrlImagem = book?.Cover?.Medium ?? book?.Cover?.Small ?? book?.Cover?.Large ?? string.Empty

            };
        }
    }
    internal sealed class OpenLibraryBookDataDto
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("key")]
        public string? Key { get; set; } // ex: "/books/OL28279068M"

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("publish_date")]
        public string? PublishDate { get; set; }

        [JsonPropertyName("authors")]
        public List<OpenLibraryAuthorDto>? Authors { get; set; }

        [JsonPropertyName("publishers")]
        public List<OpenLibraryNameDto>? Publishers { get; set; }

        [JsonPropertyName("subjects")]
        public List<OpenLibrarySubjectDto>? Subjects { get; set; }

        [JsonPropertyName("cover")]
        public OpenLibraryCoverDto? Cover { get; set; }

        [JsonPropertyName("identifiers")]
        public OpenLibraryIdentifiersDto? Identifiers { get; set; } // opcional

        [JsonPropertyName("notes")]
        public string? Notes { get; set; } // opcional

        [JsonPropertyName("links")]
        public List<OpenLibraryLinkDto>? Links { get; set; } // opcional
    }

    internal sealed class OpenLibraryAuthorDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    internal sealed class OpenLibraryNameDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    internal sealed class OpenLibrarySubjectDto
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    internal sealed class OpenLibraryCoverDto
    {
        [JsonPropertyName("small")]
        public string? Small { get; set; }

        [JsonPropertyName("medium")]
        public string? Medium { get; set; }

        [JsonPropertyName("large")]
        public string? Large { get; set; }
    }

    internal sealed class OpenLibraryIdentifiersDto
    {
        [JsonPropertyName("isbn_10")]
        public List<string>? Isbn10 { get; set; }

        [JsonPropertyName("isbn_13")]
        public List<string>? Isbn13 { get; set; }

        [JsonPropertyName("openlibrary")]
        public List<string>? OpenLibrary { get; set; }
    }

    internal sealed class OpenLibraryLinkDto
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
