using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public interface GunBag
{
    void resetGunType(GunTypes caller);

    Bullet getShootingGun();

    void setsDirections(Directions dir);

    void setWaitTime(int wait);
    
    
}