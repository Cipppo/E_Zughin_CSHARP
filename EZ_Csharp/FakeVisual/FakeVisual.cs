using EZ_Csharp.Components;
using EZ_Csharp.modularGun;
using EZ_Csharp.utils;

namespace EZ_Csharp.FakeVisual;

public class FakeVisual
{
    public int Width { get; }
    public int Heigth { get; }

    public ArpionComponent ArpionComponent { get; set; }
    
    public HeroComponent HeroComponent { get; set; }

    public FakeVisual(int width, int heigth, EntityPos2D startpos)
    {
        this.Width = width;
        this.Heigth = heigth;
        this.HeroComponent = new HeroComponent(startpos);
        this.ArpionComponent = new ArpionComponent(startpos);
        this.HeroComponent.ChangeLocation(startpos);
        this.HeroComponent.ChangeLocation(startpos);
    }

    public void Move(EntityPos2D pos)
    {
        this.HeroComponent.ChangeLocation(pos);
        if (ArpionComponent.Status == Status.Idle)
        {
            ArpionComponent.ChangeLocation(pos);
        }
    }

    public void SetDirection(Directions dir)
    {
        if (this.ArpionComponent.Status == Status.Idle)
        {
            this.ArpionComponent.SetDirection(dir, this.HeroComponent.S);
        }
    }
}