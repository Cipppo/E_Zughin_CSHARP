using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public class Arpion : Bullet
{    
    private Status status { get; set; }
    private Directions dir { get; set; }
    private int WaitTime { get; set; }
    private int Steps { get; set; }

    public Arpion()
    {
        this.WaitTime = 0;
        this.status = Status.Idle;
        this.dir = Directions.LEFT;
        this.Steps = 0;
    }

    public void Restore()
    {
        this.status = Status.Idle;
        this.Steps = 0;
    }

    public void Raise() => this.Steps++;

    public void Lock() => this.status = Status.Rising;

    public void Unlock() => this.status = Status.Idle;

    public void Hit()
    {
        if (this.status == Status.Rising)
        {
            this.status = Status.Hit;
        }
    }

    public Status GetStatus() => status;

    public override string ToString()
    {
        return "Status: " + this.status + " Direction: " + this.dir;
    }
}