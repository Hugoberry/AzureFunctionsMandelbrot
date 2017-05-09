#load "..\SharedCode\POCO.csx"
#load "..\SharedCode\MandelbrotPoint.csx"
#r "Newtonsoft.Json"

using MathNet.Numerics;
using Newtonsoft.Json;
using System;

public static void Run( MandelbrotBatch batch, 
                        TraceWriter log, 
                        IBinder binder)
{
    var req = batch.SetRequest;
    var xSpace = Generate.LinearSpaced( req.Resolution, 
                                        req.XMin, 
                                        req.XMax);  

    var mandelbrotSet = xSpace.Select(x=>new MandelbrotPoint(x,batch.Y));
    using (var outputBlob = binder.Bind<TextWriter>(
        new BlobAttribute($"mandelbrot/{batch.OutputBlobFolder}/{Guid.NewGuid()}")))
    {
        outputBlob.WriteLine(JsonConvert.SerializeObject(mandelbrotSet));
    }
}