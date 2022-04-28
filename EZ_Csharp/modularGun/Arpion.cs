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

    public void Raise()
    {
        throw new NotImplementedException();
    }

    public void Lock()
    {
        throw new NotImplementedException();
    }

    public void Unlock()
    {
        throw new NotImplementedException();
    }

    public void hit()
    {
        throw new NotImplementedException();
    }


}