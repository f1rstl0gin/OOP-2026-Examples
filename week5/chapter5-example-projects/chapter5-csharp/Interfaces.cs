namespace Chapter5Demo;

public interface IComicCharacter
{
    string NickName { get; }
    void DrawSpeechBalloon(string message);
    void DrawSpeechBalloon(IComicCharacter destination, string message);
    void DrawThoughtBalloon(string message);
}

public interface IGameCharacter
{
    string FullName { get; }
    uint Score { get; set; }
    uint X { get; set; }
    uint Y { get; set; }

    void Draw(uint x, uint y);
    void Move(uint x, uint y);
    bool IsIntersectingWith(IGameCharacter other);
}

public interface IAlien
{
    uint NumberOfEyes { get; }
    void Appear();
    void Disappear();
}

public interface IWizard
{
    uint SpellPower { get; }
    void DisappearAlien(IAlien alien);
}

public interface IKnight
{
    uint SwordPower { get; }
    uint SwordWeight { get; }
    void UnsheathSword(IAlien target);
}
