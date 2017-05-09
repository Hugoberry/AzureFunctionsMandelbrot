public class MandelbrotSetRequest
{
    public Double XMin {get; set;}
    public Double YMin {get; set;}
    public Double XMax {get; set;}
    public Double YMax {get; set;}
    public int Resolution {get; set;}
}

public class MandelbrotBatch
{
    public MandelbrotSetRequest SetRequest;
    public Double Y {get; set;}
    public Guid OutputBlobFolder;
}