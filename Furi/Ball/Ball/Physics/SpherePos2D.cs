namespace Ball.Physics;

public class SpherePos2D : Pos2D<double>
{ 
    public override double X { get; set; }
    public override double Y { get; set; }
    public int Diameter { get; }
    public Dimensions Dimension { get; }
    
    public SpherePos2D(double x, double y, Dimensions dimension, int diameter) : base(x, y)
    {
        var diameterFactor = (double)dimension / 100;
        Diameter = (int)(diameter * diameterFactor) ;
        Dimension = dimension;
    }
    
    public override string ToString()
    {
        return "(" + X + ", " + Y + ")";
    }
}