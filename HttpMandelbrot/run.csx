#load "..\SharedCode\POCO.csx"

using System;
using System.Net;
using MathNet.Numerics;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req,
                                                  IAsyncCollector<MandelbrotBatch> queue,
                                                  TraceWriter log)
{
    dynamic mSetRequest = await req.Content.ReadAsAsync<MandelbrotSetRequest>();   
    var outBlobFolder = Guid.NewGuid();
    var ySpace = Generate.LinearSpaced( mSetRequest.Resolution, 
                                        mSetRequest.YMin, 
                                        mSetRequest.YMax);  
    foreach(var y in ySpace)
    {
        await queue.AddAsync(new MandelbrotBatch(){
                                SetRequest = mSetRequest,
                                OutputBlobFolder = outBlobFolder,
                                Y=y
                            });  
    }    
    log.Info($"Processing Batch {outBlobFolder} with resolution {mSetRequest.Resolution}");
    return req.CreateResponse(HttpStatusCode.OK, outBlobFolder.ToString());    
}