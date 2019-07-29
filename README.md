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

# APIS Implemented
- Order
- Product
- ProductVariant
- AppInstance
- Collection
- InventoryItem
