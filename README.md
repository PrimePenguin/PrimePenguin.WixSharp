# PrimePenguin.WixSharp

# Using WixSharp

**Note**: All instances of `shopAccessToken` in the examples below **do not refer to your WixSharp API key**.
An access token is the token returned after authenticating and authorizing a WixSharp app installation with a
real WixSharp store.

```cs
var service = new OrderService(shopAccessToken);
```


# APIS Implemented
- Product
- ProductVariant
- Collection
- Order
- InventoryItem
