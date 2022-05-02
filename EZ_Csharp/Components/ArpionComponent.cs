using EZ_Csharp.modularGun;
using EZ_Csharp.utils;

namespace EZ_Csharp.Components;



public class ArpionComponent
{
    private const int Width = 10;
    private const int Height = 2000;
    //private const int Speed = 5;
    
    public Shape S { get; set; }
    public Status Status { get; set; }
    public Directions Dir { get; set; }
    public GunTypes Type { get; set; }
    
}