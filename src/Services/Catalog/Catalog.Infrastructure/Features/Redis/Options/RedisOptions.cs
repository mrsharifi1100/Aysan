using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Features.Redis.Options;
public class RedisOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public string InstanceName { get; set; } = string.Empty;
}


