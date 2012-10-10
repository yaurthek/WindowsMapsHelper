using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;

namespace WindowsMapsHelper
{
    public static class MapsHelper
    {
        private static readonly string _protocolUrl = "bingmaps:";

        /// <summary>
        /// Shows map and users location 
        /// </summary>
        public static IAsyncOperation<bool> ShowMapAsync()
        {
            return AsyncInfo.Run(token => ShowMapAsyncInternal());
        }

        private async static Task<bool> ShowMapAsyncInternal()
        {
            return await LaunchMapApp(String.Empty);
        }

        /// <summary>
        /// Shows map configured according to the provided options
        /// </summary>
        public static IAsyncOperation<bool> ShowMapWithOptionsAsync(MapOptions options)
        {
            return AsyncInfo.Run(token => ShowMapWithOptionsAsyncInternal(options));
        }

        private async static Task<bool> ShowMapWithOptionsAsyncInternal(MapOptions options)
        {
            if (options == null)
            {
                return await ShowMapAsync();
            }

            return await LaunchMapApp(OptionsToString(options));
        }

        /// <summary>
        /// Searches provided term in desired area
        /// </summary>
        public static IAsyncOperation<bool> SearchAsync(string termToSearch, string whereToSearch, MapOptions options)
        {
            return AsyncInfo.Run(token => SearchAsyncInternal(termToSearch, whereToSearch, options));
        }

        private async static Task<bool> SearchAsyncInternal(string termToSearch, string whereToSearch, MapOptions options)
        {
            var sb = new StringBuilder();

            if (options != null)
            {
                sb.Append(OptionsToString(options));
            }

            if (!String.IsNullOrWhiteSpace(termToSearch))
            {
                sb.AppendFormat("&q={0}", termToSearch);
            }

            if (!String.IsNullOrWhiteSpace(whereToSearch))
            {
                sb.AppendFormat("&where={0}", whereToSearch);
            }

            return await LaunchMapApp(sb.ToString());
        }

        /// <summary>
        /// Searches driving directions for provided points
        /// </summary>
        public static IAsyncOperation<bool> SearchDirectionsAsync(IMapPoint startPoint, IMapPoint endPoint, MapOptions options)
        {
            return AsyncInfo.Run(token => SearchDirectionsAsyncInternal(startPoint, endPoint, options));
        }

        private async static Task<bool> SearchDirectionsAsyncInternal(IMapPoint startPoint, IMapPoint endPoint, MapOptions options)
        {
            var startPointStr = startPoint == null ? String.Empty : startPoint.ToString();
            var endPointStr = endPoint == null ? String.Empty : endPoint.ToString();

            var sb = new StringBuilder();

            if (options != null)
            {
                sb.Append(OptionsToString(options));
            }

            if (!String.IsNullOrWhiteSpace(startPointStr) || !String.IsNullOrWhiteSpace(endPointStr))
            {
                sb.AppendFormat("&rtp={0}~{1}", startPointStr, endPointStr);
            }

            return await LaunchMapApp(sb.ToString());
        }

        private async static Task<bool> LaunchMapApp(string parameters)
        {
            var trimmedParams = parameters.Trim(new[] { '&' });
            var uri = String.IsNullOrWhiteSpace(trimmedParams) ? 
                        new Uri(_protocolUrl) : 
                        new Uri(String.Concat(_protocolUrl, "?", trimmedParams));

            return await Launcher.LaunchUriAsync(uri);
        }

        private static string OptionsToString(MapOptions options)
        { 
            var sb = new StringBuilder();
            
            if (options.CenterPoint != null)
            {
                sb.AppendFormat("cp={0}", options.CenterPoint.ToPointString());
            }

            if (options.ZoomLevel != null)
            {
                sb.AppendFormat("&lvl={0:0.00}", options.ZoomLevel.ZoomLevel);
            }

            if (options.BoundingBox != null && 
                options.BoundingBox.LowerLeftCorner!= null && 
                options.BoundingBox.UpperRightCorner!= null)
            {
                sb.AppendFormat("&bb={0}_{1}~{2}_{3}", 
                                options.BoundingBox.LowerLeftCorner.Latitude, 
                                options.BoundingBox.LowerLeftCorner.Longitude,
                                options.BoundingBox.UpperRightCorner.Latitude, 
                                options.BoundingBox.UpperRightCorner.Longitude);
            }

            if (options.ViewStyle != MapViewStyle.Default)
            {
                sb.AppendFormat("&sty={0}", options.ViewStyle == MapViewStyle.Aerial ? "a" : "r");
            }

            if (options.ShowTraffic)
            {
                sb.Append("&trfc=1");
            }            

            return sb.ToString().TrimStart(new[]{'&'});
        }
    }
}
