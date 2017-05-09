#r "System.Numerics"
using System.Numerics;

public class MandelbrotPoint
{
    public Double Re;
    public Double Im;
    public Int32 Value;
    
    public MandelbrotPoint(Double Re, Double Im){
        this.Re = Re;
        this.Im = Im;
        this.Value = Mandelbrot(new Complex(Re,Im));
    }
    
    public static Int32 Mandelbrot(Complex c)
    {
        Int32 count = 0;
        Complex z = Complex.Zero;
        while (count < 1000 && z.Magnitude < 4)
        {
            z = z * z + c;
            count++;
        }
        return count;
    }
}