using System.Data.SqlTypes;
using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public class Arpion : Bullet
{
    public Status Status { get; set; }
    public Directions Dir { get; set; }
    public int WaitTime { get; set; }
    public int Steps { get; set; }

    public Arpion()
    {
        this.WaitTime = 0;
        this.Status = Status.Idle;
        this.Dir = Directions.LEFT;
        this.Steps = 0;
    }

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