using Flurl;

namespace Polyathlon.DataModel.Common;

internal static class FlurlExtensions {
    public static string Origin(this Url url) {
        return @$"{url.Root}/{url.PathSegments[0]}";
    }
}