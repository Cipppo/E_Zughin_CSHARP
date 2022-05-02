namespace EZ_Csharp.utils;

public class PosConverter
{
    private FullPair<int, int> _Dimensions;
    private Shape _heroShape;

    public PosConverter(FullPair<int, int> arpionDimensions, Shape heroShape)
    {
        this._Dimensions = arpionDimensions;
        this._heroShape = heroShape;
    }

    private EntityPos2D GetLeftPos() => this._heroShape.GetLeftFoot();

    private EntityPos2D GetRightPos()
    {
        var x = (this._heroShape.GetLeftFoot().X + this._heroShape.Dimensions.X) - this._Dimensions.X;
        var y = this._heroShape.GetLeftFoot().Y;
        return new EntityPos2D(x, y);
    }

    public EntityPos2D GetPos(Directions dir)
    {
        return dir == Directions.RIGHT ? this.GetRightPos() : GetLeftPos();
    }
}