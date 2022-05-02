using System.Data.SqlTypes;
using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public class Arpion : Bullet
{
    public Status Status { get; set; } = Status.Idle;
    public Directions Dir { get; set; } = Directions.LEFT;
    public int WaitTime { get; set; } = 0;
    public int Steps { get; set; } = 0;

    public Arpion() {}

    public void Restore()
    {
        this.Status = Status.Idle;
        this.Steps = 0;
    }

    public void Raise() => this.Steps++;

    public void Lock() => this.Status = Status.Rising;

    public void Unlock() => this.Status = Status.Idle;

    public void Hit()
    {
        if (this.Status == Status.Rising)
        {
            this.Status = Status.Hit;
        }
    }

    public override string ToString()
    {
        return "Status: " + this.Status + " Direction: " + this.Dir;
    }

    
}