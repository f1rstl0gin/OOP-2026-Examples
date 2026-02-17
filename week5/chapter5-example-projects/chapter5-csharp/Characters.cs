using System;

namespace Chapter5Demo;

public sealed class AngryDog : IComicCharacter
{
    public AngryDog(string nickName) => NickName = nickName;

    public string NickName { get; }

    public void DrawSpeechBalloon(string message)
        => Console.WriteLine($"{NickName} -> \"{message}\"");

    public void DrawSpeechBalloon(IComicCharacter destination, string message)
        => Console.WriteLine($"{NickName} -> \"{destination.NickName}, {message}\"");

    public void DrawThoughtBalloon(string message)
        => Console.WriteLine($"{NickName} ***{message}***");
}

public class AngryCat : IComicCharacter, IGameCharacter
{
    public AngryCat(string nickName, uint age, string fullName, uint initialScore, uint x, uint y)
    {
        NickName = nickName;
        Age = age;
        FullName = fullName;
        Score = initialScore;
        X = x;
        Y = y;
    }

    public string NickName { get; }
    public uint Age { get; }

    public string FullName { get; }
    public uint Score { get; set; }
    public uint X { get; set; }
    public uint Y { get; set; }

    public virtual void DrawSpeechBalloon(string message)
        => Console.WriteLine($"{NickName} -> \"{message}\"");

    public virtual void DrawSpeechBalloon(IComicCharacter destination, string message)
        => Console.WriteLine($"{destination.NickName} === {NickName} -> \"{message}\"");

    public virtual void DrawThoughtBalloon(string message)
        => Console.WriteLine($"{NickName} ***{message}***");

    public virtual void Draw(uint x, uint y)
        => Console.WriteLine($"[Draw] {FullName} at ({x}, {y})");

    public virtual void Move(uint x, uint y)
    {
        X = x;
        Y = y;
        Console.WriteLine($"[Move] {FullName} -> ({X}, {Y})");
    }

    public virtual bool IsIntersectingWith(IGameCharacter other)
        => X == other.X && Y == other.Y;
}

public sealed class AngryCatAlien : AngryCat, IAlien
{
    public AngryCatAlien(
        string nickName,
        uint age,
        string fullName,
        uint initialScore,
        uint x,
        uint y,
        uint numberOfEyes) : base(nickName, age, fullName, initialScore, x, y)
    {
        NumberOfEyes = numberOfEyes;
    }

    public uint NumberOfEyes { get; }

    public void Appear() => Console.WriteLine($"[Alien] appear ({NumberOfEyes} eyes)");
    public void Disappear() => Console.WriteLine("[Alien] disappear");
}

public sealed class AngryCatWizard : AngryCat, IWizard
{
    public AngryCatWizard(
        string nickName,
        uint age,
        string fullName,
        uint initialScore,
        uint x,
        uint y,
        uint spellPower) : base(nickName, age, fullName, initialScore, x, y)
    {
        SpellPower = spellPower;
    }

    public uint SpellPower { get; }

    public void DisappearAlien(IAlien alien)
    {
        Console.WriteLine($"[Wizard] casting vanish (power={SpellPower})");
        alien.Disappear();
    }
}

public sealed class AngryCatKnight : AngryCat, IKnight
{
    public AngryCatKnight(
        string nickName,
        uint age,
        string fullName,
        uint initialScore,
        uint x,
        uint y,
        uint swordPower,
        uint swordWeight) : base(nickName, age, fullName, initialScore, x, y)
    {
        SwordPower = swordPower;
        SwordWeight = swordWeight;
    }

    public uint SwordPower { get; }
    public uint SwordWeight { get; }

    public void UnsheathSword(IAlien target)
    {
        Console.WriteLine($"[Knight] unsheath sword (power={SwordPower}, weight={SwordWeight})");
        Console.WriteLine($"[Knight] target has {target.NumberOfEyes} eyes");
    }
}
