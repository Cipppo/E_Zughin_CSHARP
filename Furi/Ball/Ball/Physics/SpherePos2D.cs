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

    private bool Equals(SpherePos2D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SpherePos2D) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string ToString()
    {
        return "(" + X + ", " + Y + ")";
    }
}