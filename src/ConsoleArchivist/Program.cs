﻿using ConsoleArchivist.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using ConsoleArchivist.Database;
using Microsoft.EntityFrameworkCore;

namespace ConsoleArchivist;

public class Program
{
    static async Task Main(string[] args)
    {

        //Configure a Generic Host
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(app =>
            {
                app.AddUserSecrets("55dcc747-60cd-49e2-9cc0-666934af5dee");
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ArchivistDbContext>(options =>
                {
                    var folder = Environment.SpecialFolder.LocalApplicationData;
                    var path = Environment.GetFolderPath(folder);
                    var dbPath = Path.Join(path, "translations.db");
                    options.UseSqlite($"Data Source={dbPath}");
                });

                services.AddHttpClient();

                services.AddHttpClient("GitHubHTTPClient", client =>
                {
                    var owner = context.Configuration.GetSection("GitHubConfiguration:Owner").Value;
                    var repo = context.Configuration.GetSection("GitHubConfiguration:Repo").Value;

                    var token = context.Configuration.GetSection("GitHubConfiguration:Token").Value;

                    client.BaseAddress = new Uri($"https://api.github.com/repos/{owner}/{repo}/contents");
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("GPTPtolemyVArchivist", "1.0"));
                });

                services.AddScoped<IGitHubService, GitHubService>();

                services.AddScoped<Startup>();


            })
            .Build();

        var startUp = host.Services.GetRequiredService<Startup>();

        await startUp.Run();
    }
}