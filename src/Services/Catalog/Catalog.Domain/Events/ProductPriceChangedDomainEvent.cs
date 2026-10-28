using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Events;
public class ProductPriceChangedDomainEvent : INotification
{
    public ProductPriceChangedDomainEvent(decimal newPrice, decimal oldPrice, CatalogItem catalogItem)
    {
        NewPrice = newPrice;
        OldPrice = oldPrice;
        CatalogItem = catalogItem;
    }

    public decimal NewPrice { get; private set; }
    public decimal OldPrice { get; private set; }

    public CatalogItem CatalogItem { get; private set; }
}