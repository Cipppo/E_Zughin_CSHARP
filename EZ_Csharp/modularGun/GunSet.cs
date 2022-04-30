using EZ_Csharp.utils;

namespace EZ_Csharp.modularGun;

public class GunSet : IGunBag
{
    public Bullet Arpion { get; }
    private GunTypes CurrentGun { set; get; }

    public GunSet()
    {
        this.Arpion = new Arpion();
        this.CurrentGun = GunTypes.Arpion;
    }
    
    private Optional<Bullet> GetSingleArpion()
    {
        return Arpion.Status == Status.Idle ? Optional<Bullet>.of(this.Arpion) : Optional<Bullet>.Empty();
    }
    
    public void ResetGunType(GunTypes caller)
    {
        if (caller != this.CurrentGun)
        {
            this.CurrentGun = GunTypes.Arpion;
        }
    }

    public Optional<Bullet> GetShootingGun()
    {
        var shootingGun = Optional<Bullet>.Empty();
        if (!this.GetSingleArpion().isPresent)
        {
            shootingGun = this.GetSingleArpion();
        }
        return shootingGun;
    }

    public void SetsDirections(Directions dir)
    {
        this.Arpion.Dir = dir;
    }

    public void SetWaitTime(int wait)
    {
        this.Arpion.WaitTime = wait;
    }
}