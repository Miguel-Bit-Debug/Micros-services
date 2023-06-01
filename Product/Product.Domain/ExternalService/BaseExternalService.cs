﻿using Microsoft.Extensions.Logging;

namespace Product.Domain.ExternalService;

public abstract class BaseExternalService<T>
{
    public string BaseUrl { get; set; }
    protected readonly HttpClient _httpClient;
    protected readonly ILogger<T> _logger;
    public BaseExternalService(HttpClient httpClient,
                                  ILogger<T> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
}
