using Flurl.Http;
using System.Net;

namespace Polyathlon.Db.Common;

internal static class RequestExtensions {
    public static bool IsSuccessful(this IFlurlResponse response) {
        return
            response.StatusCode == (int)HttpStatusCode.OK ||
            response.StatusCode == (int)HttpStatusCode.Created ||
            response.StatusCode == (int)HttpStatusCode.Accepted ||
            response.StatusCode == (int)HttpStatusCode.NoContent;
    }
}
