
# Water Jug Challenge



## API Reference

#### Get solution

```http
  GET /api/steps/${x}/${y}/${z}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `x`      | `integer` | **Optional**. X-gallon jug. |
| `y`      | `integer` | **Optional**. Y-gallon jug. |
| `z`      | `integer` | **Optional**. measure Z gallons of water. |

NOTE: Although the parameters are optional, if they are not placed, the response will be that there is **No solution**.


## Appendix

I used the [Microsoft documentation](https://docs.microsoft.com/es-mx/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api) as a reference. I did not use Net Core since the version installed on my computer is Visual Studio 2017.

