using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using WindowsMapsHelper;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public async void ButtonMapTapped(object sender, TappedRoutedEventArgs e)
        {
            await WindowsMapsHelper.MapsHelper.ShowMapAsync();
        }
        
        public async void ButtonMapOptionsTapped(object sender, TappedRoutedEventArgs e)
        {
            var options = new MapOptions
            {
                ZoomLevel = new MapZoomLevel(16),
                ShowTraffic = true,
                CenterPoint = new MapPosition(43.649126, -79.377885)
            };

            await WindowsMapsHelper.MapsHelper.ShowMapWithOptionsAsync(options);
        }

        public async void ButtonSearchTapped(object sender, TappedRoutedEventArgs e)
        {
            await WindowsMapsHelper.MapsHelper.SearchAsync("tea", "London, United Kingdom", null);
        }

        public async void ButtonSearchRouteTapped(object sender, TappedRoutedEventArgs e)
        {
            var options = new MapOptions
            {
                ShowTraffic = true,
                ViewStyle = MapViewStyle.Aerial
            };

            await MapsHelper.SearchDirectionsAsync(new MapAddress("Montreal"), new MapAddress("Ottawa"), options);
        }

        public async void ButtonSearchRouteToTapped(object sender, TappedRoutedEventArgs e)
        {
            await MapsHelper.SearchDirectionsAsync(null, new MapPosition(33.943538, -118.40812), null);
        }

    }
}
