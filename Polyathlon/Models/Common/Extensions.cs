using Flurl;

namespace Polyathlon.DataModel.Common;

internal static class FlurlExtensions {
    public static Url Origin(this Url url) {
        return new(@$"{url.Root}/{url.PathSegments[0]}");
    }
}