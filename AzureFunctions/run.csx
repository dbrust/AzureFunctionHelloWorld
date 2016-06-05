using System.Net;
using System.Threading.Tasks;

public static async Task<HttpResponseMessage> Run(HttpResponseMessage req, TraceWriter log) {
    return req.CreateResponse(HttpStatusCode.OK, "Hello World!");
}