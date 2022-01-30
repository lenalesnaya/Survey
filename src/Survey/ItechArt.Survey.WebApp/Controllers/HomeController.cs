﻿using System.Threading.Tasks;
using ItechArt.Survey.DomainModel;
using ItechArt.Survey.Foundation.Counters.Abstractions;
using ItechArt.Survey.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ItechArt.Survey.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ICounterService _counterService;
    private readonly Common.ILogger _logger;


    public HomeController(ICounterService counterService, Common.ILogger logger)
    {
        _counterService = counterService;
        _logger = logger;
    }


    [HttpGet]
    public async Task<IActionResult> HomePage()
    {
        var counter = await _counterService.GetCounterAsync();
        var counterViewModel = GetCounterViewModel(counter);

        return View(counterViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> IncrementCounter()
    {
        var counter = await _counterService.IncrementCounterAsync();
        var counterViewModel = GetCounterViewModel(counter);

        _logger.Write(LogLevel.Information, "Increment is happened");

        return View("HomePage", counterViewModel);
    }


    private static CounterViewModel GetCounterViewModel(Counter counter)
    {
        var counterViewModel = new CounterViewModel
        {
            Value = counter.Value
        };

        return counterViewModel;
    }
}