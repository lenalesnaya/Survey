﻿using System;
using System.Threading.Tasks;
using ItechArt.Survey.DomainModel;
using ItechArt.Survey.Foundation.Counters.Abstractions;
using ItechArt.Survey.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ItechArt.Survey.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ICounterService _counterService;
    private readonly Common.ILogger _logger;


    public HomeController(
        ICounterService counterService,
        Common.ILogger logger)
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

        _logger.Information("Hello my new log, increment is happend");

        return View("HomePage", counterViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> ThrowException()
    {
        var counter = await _counterService.GetCounterAsync();
        var counterViewModel = GetCounterViewModel(counter, "Error!");

        try
        {
            throw new Exception();
        }
        catch (Exception exception)
        {
            _logger.Error("Error!", exception);
        }

        return View("HomePage", counterViewModel);
    }


    private static CounterViewModel GetCounterViewModel(Counter counter, string exception = null)
    {
        var counterViewModel = new CounterViewModel
        {
            Value = counter.Value,
            Exception = exception
        };

        return counterViewModel;
    }
}