﻿//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;

//public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
//    return req.CreateResponse(HttpStatusCode.OK, "Hello World!");
//}
#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log) {
    log.Info($"Webhook was triggered!");

    string jsonContent = await req.Content.ReadAsStringAsync();
    dynamic data = JsonConvert.DeserializeObject(jsonContent);

    if (data.first == null || data.last == null) {
        return req.CreateResponse(HttpStatusCode.BadRequest, new {
            error = "Please pass first/last properties in the input object"
        });
    }

    return req.CreateResponse(HttpStatusCode.OK, new {
        greeting = $"Hello {data.first} {data.last}!"
    });
}