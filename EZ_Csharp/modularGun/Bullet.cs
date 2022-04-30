using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public interface Bullet
{
    void Restore();

    void Raise();

    void Lock();

    void Unlock();

    void Hit();

    Directions Dir { get; set; }
    
    Status Status { get; set; }
    
    int WaitTime { get; set; }
    
    int Steps { get; set; }

}