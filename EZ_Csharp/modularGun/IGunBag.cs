using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public interface IGunBag
{
    void ResetGunType(GunTypes caller);

    Bullet GetShootingGun();

    void SetsDirections(Directions dir);

    void SetWaitTime(int wait);
    
    
}