using EZ_Csharp.utils;

namespace EZ_Csharp.hero;

public class Hero
{
    private EntityPos2D Pos { get; set; } = new(0, 0);
    private Directions Dir { get; set; }
    private HeroStatus Status { get; set; }
    private int Lives { get; set; }
    private bool IsAwake { get; set; }

    public Hero()
    {
        this.Dir = Directions.LEFT;
        this.Status = HeroStatus.Neutral;
        this.Lives = 3;
        this.IsAwake = true;
    }

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
        Console.WriteLine("Lives: " + this.Lives);
    }

    public void Reset()
    {
        this.Pos = new EntityPos2D(0, 0);
        this.Lives = 3;
    }
    
}   