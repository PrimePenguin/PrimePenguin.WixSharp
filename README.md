# WixSharp: A .NET library for Wix.

[![NuGet](https://img.shields.io/nuget/v/PrimePenguin.WixSharp.svg?maxAge=3600)](https://www.nuget.org/packages/PrimePenguin.WixSharp/)
[![Build status](https://ci.appveyor.com/api/projects/status/a8finqe6syq9v825?svg=true)](https://ci.appveyor.com/project/ajayak/primepenguin-wixsharp)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg?maxAge=3600)](https://raw.githubusercontent.com/PrimePenguin/PrimePenguin.WixSharp/master/LICENSE)

WixSharp is a .NET library that enables you to authenticate and make API calls to WixSharp. It's great for 
building custom WixSharp Apps using C# and .NET. You can quickly and easily get up and running with WixSharp
using this library.

# Installation

WixSharp is [available on NuGet](https://www.nuget.org/packages/WixSharp/). Use the package manager
console in Visual Studio to install it:

```
Install-Package PrimePenguin.WixSharp
```

If you're using .NET Core, you can use the `dotnet` command from your favorite shell:

```
dotnet add package PrimePenguin.WixSharp
```

# Using WixSharp

**Note**: All instances of `shopAccessToken` in the examples below **do not refer to your WixSharp API key**.
An access token is the token returned after authenticating and authorizing a WixSharp app installation with a
real WixSharp store.

```cs
var service = new OrderService(shopAccessToken);
```

## Authentication

New Wix apps authenticate with OAuth 2 (client credentials). Create a token for an app instance (a site that
installed your app) and pass it to any service. Tokens are valid for 4 hours.

```cs
var token = await OAuth2Service.CreateAccessTokenAsync(appId, appSecret, instanceId);
var orders = new EcomOrderService(token.AccessToken);
```

The `instanceId` is sent in the App Instance Installed webhook and in every webhook payload (`WixHookPayload.InstanceId`).
`AuthorizationService` still supports the legacy authorization code / refresh token flow ("custom authentication"),
which Wix no longer offers to new apps.

## Wix Stores Catalog V1 and V3

Wix Stores has two catalog versions that aren't compatible with each other. New sites use Catalog V3, and Wix is
moving existing sites from V1 to V3. Apps must support both, so check the site's version first:

```cs
var version = await new CatalogVersionService(shopAccessToken).GetCatalogVersionAsync();

if (version.IsV3Catalog)
{
    var products = await new ProductV3Service(shopAccessToken).QueryProductsAsync(new CursorQuery
    {
        CursorPaging = new CursorPagingOptions { Limit = 100 }
    });
}
else if (version.IsV1Catalog)
{
    var products = await new ProductService(shopAccessToken).GetProductsAsync(new ProductRootQuery());
}
```

| Catalog V1 (`WixSharp.Services.*`) | Catalog V3 (`WixSharp.Services.CatalogV3`) |
|---|---|
| `ProductService` | `ProductV3Service` (products, products with inventory, bulk and "by filter" operations, read-only variants) |
| `InventoryItemService` | `InventoryItemV3Service` |
| - | `StoresLocationService` (inventory locations) |
| `CollectionService` | `CategoryService` |

The V3 services cover every endpoint of the Wix Products V3, Inventory Items V3, Stores Locations V3 and Categories APIs.

"By filter" bulk operations run as asynchronous jobs. They return a job ID that you can track with `AsyncJobService`:

```cs
var jobId = await new ProductV3Service(shopAccessToken).BulkAdjustProductVariantsByFilterAsync(
    new VariantPriceAdjustment { ActualPrice = new AdjustValue { Percentage = 10 } },
    new JObject { ["visible"] = true });

var job = await new AsyncJobService(shopAccessToken).GetAsyncJobAsync(jobId);
// job.Status: INITIALIZED, PROCESSING, FINISHED or FAILED
```

The new entities in `WixSharp.Entities.CatalogV3` and `WixSharp.Entities.Ecom` use Wix's type names, and some of those
names also exist in the V1 entities in `WixSharp.Entities` (for example `Product` or `Fulfillment`). In files that use
both, alias one of the namespaces. The shared types in `WixSharp.Entities.Common` (`CursorQuery`, `CursorPagingOptions`, ...)
never clash.

```cs
using V3 = WixSharp.Entities.CatalogV3;
```

## eCommerce orders

Orders work the same way for V1 and V3 sites. The services in `WixSharp.Services.Ecom` cover the eCommerce Orders,
Order Fulfillments and Order Transactions APIs:

```cs
var orderService = new EcomOrderService(shopAccessToken);
var result = await orderService.SearchOrdersAsync(new CursorSearch
{
    Filter = new JObject { ["paymentStatus"] = OrderPaymentStatuses.Paid },
    CursorPaging = new CursorPagingOptions { Limit = 50 }
});

await new OrderFulfillmentService(shopAccessToken).CreateFulfillmentAsync(orderId, new Fulfillment
{
    LineItems = new List<FulfillmentLineItem> { new FulfillmentLineItem { Id = lineItemId, Quantity = 1 } },
    TrackingInfo = new FulfillmentTrackingInfo { TrackingNumber = "1Z999", ShippingProvider = "ups" }
});
```

## Webhooks

Sites on Catalog V3 send V3 events instead of V1 events, so subscribe to both. The newer events
(`WixHookEventType.ProductV3Updated`, `EcomOrderCreated`, ...) are domain events; parse them with `WixDomainEvent`:

```cs
var payload = AuthorizationHelper.GetRequestPayload(requestBody, publicKey);

if (payload.EventType == WixHookEventType.ProductV3Updated)
{
    var product = WixDomainEvent.Parse(payload.Data).GetEntity<V3.Product>();
}
```

# APIS Implemented
- Authentication: OAuth 2 (`OAuth2Service`), legacy custom authentication (`AuthorizationService`)
- AppInstance
- Catalog version
- Catalog V1: Product, ProductVariant, Collection, InventoryItem
- Catalog V3: Product, read-only variants, InventoryItem, Stores location, Category
- Async jobs
- eCommerce: Order, Order fulfillments, Order transactions
