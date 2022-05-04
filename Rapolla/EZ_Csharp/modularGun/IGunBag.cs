using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public interface IGunBag
{
    void ResetGunType(GunTypes caller);

    Optional<Bullet> GetShootingGun();

    void SetsDirections(Directions dir);

    void SetWaitTime(int wait);
    
    
}