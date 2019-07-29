# WixSharp: A .NET library for Wix.

WixSharp is a .NET library that enables you to authenticate and make API calls to WixSharp. It's great for 
building custom WixSharp Apps using C# and .NET. You can quickly and easily get up and running with WixSharp
using this library.

# Installation

WixSharp is [available on NuGet](https://www.nuget.org/packages/WixSharp/). Use the package manager
console in Visual Studio to install it:

```
Install-Package WixSharp
```

If you're using .NET Core, you can use the `dotnet` command from your favorite shell:

```
dotnet add package WixSharp
```

# Using WixSharp

**Note**: All instances of `shopAccessToken` in the examples below **do not refer to your WixSharp API key**.
An access token is the token returned after authenticating and authorizing a WixSharp app installation with a
real WixSharp store.

```cs
var service = new OrderService(shopAccessToken);
```

# APIS Implemented
- Order
- Product
- ProductVariant
- AppInstance
- Collection
- InventoryItem
