using EZ_Csharp.utils;

namespace EZ_Csharp.hero;

public class Hero : IPausable
{
    private EntityPos2D Pos { get; set; } = new(0, 0);
    public Directions Dir { get; private set; } = Directions.LEFT;
    public HeroStatus Status { get; private set; } = HeroStatus.Neutral;
    public int Lives { get; private set; } = 3;
    public bool IsAwake { get; set; } = true;
    
    public Hero() {}

    public void Move(Directions newDir)
    {
        this.Pos = newDir switch
        {
            Directions.RIGHT => new EntityPos2D(this.Pos.X + 1, this.Pos.Y),
            Directions.LEFT => new EntityPos2D(this.Pos.X - 1, this.Pos.Y),
            _ => Pos
        };
        this.Dir = newDir;
    }

    public void Hit()
    {
        if (!this.IsAwake) return;
        this.Lives--;
        this.Status = HeroStatus.Hit;
        Console.WriteLine("Lives: " + this.Lives);
    }

    public void Reset()
    {
        this.Pos = new EntityPos2D(0, 0);
        this.Lives = 3;
    }

    public void PauseAll() => this.IsAwake = false;

    public void ResumeAll() => this.IsAwake = true;

}   