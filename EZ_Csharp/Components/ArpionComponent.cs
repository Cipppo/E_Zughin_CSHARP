using EZ_Csharp.modularGun;
using EZ_Csharp.utils;

namespace EZ_Csharp.Components;



public class ArpionComponent
{
    private const int Width = 10;
    private const int Height = 2000;
    //private const int Speed = 5;
    
    public Shape S { get; set; }
    public Status Status { get; set; } = Status.Idle;
    public Directions Dir { get; set; } = Directions.LEFT;
    public GunTypes Type { get; set; } = GunTypes.Arpion;

    public ArpionComponent(EntityPos2D startPos)
    {
        this.S = new Shape(startPos, new FullPair<int, int>(Width, Height));
    }

    public void ChangeLocation(EntityPos2D newPos) => this.S = new Shape(newPos, new FullPair<int, int>(Width, Height));

    public void SetDirection(Directions dir, Shape shape)
    {
        var posConverter = new PosConverter(new FullPair<int, int>(Width, Height), shape);
        this.ChangeLocation(posConverter.GetPos(dir));
        this.Dir = dir;
    }
    
    
}