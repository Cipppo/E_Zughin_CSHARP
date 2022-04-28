using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public interface Bullet
{
    void Restore();

    void Raise();

    void Lock();

    void Unlock();

    void hit();

}