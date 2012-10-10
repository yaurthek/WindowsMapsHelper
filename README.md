WindowsMapsHelper
=================

Windows 8 Maps app protocol helper

## How To Install

### NuGet
    PM> Install-Package WindowsMapsHelper


## Usage

### Open Maps app and display current user location  ###

    await WindowsMapsHelper.MapsHelper.ShowMapAsync();

### Display map centered on Downtown Toronto, with traffic info ###

    var options = new MapOptions
    {
        ZoomLevel = new MapZoomLevel(16),
        ShowTraffic = true,
        CenterPoint = new MapPosition(43.649126, -79.377885)
    };

    await WindowsMapsHelper.MapsHelper.ShowMapWithOptionsAsync(options);

### Display map with tea places around London, UK  ###

    await WindowsMapsHelper.MapsHelper.SearchAsync("tea", "London, United Kingdom", null);

### Show driving directions from Montreal to Ottawa ###

    var options = new MapOptions
    {
        ShowTraffic = true,
        ViewStyle = MapViewStyle.Aerial
    };

    await MapsHelper.SearchDirectionsAsync(new MapAddress("Montreal"), 
                                           new MapAddress("Ottawa"), options);

### Show driving directions from current location to Los Angeles airport ###

    await MapsHelper.SearchDirectionsAsync(null, 
                        new MapPosition(33.943538, -118.40812), null);
