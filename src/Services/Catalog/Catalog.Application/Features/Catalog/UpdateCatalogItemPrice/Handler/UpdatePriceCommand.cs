using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Features.Catalog.UpdateCatalogItemPrice.Handler;
public class UpdatePriceCommand : IRequest
{
    public string? Name { get; set; }
    public int Id { get; set; }
    public decimal Price { get; set; }
}