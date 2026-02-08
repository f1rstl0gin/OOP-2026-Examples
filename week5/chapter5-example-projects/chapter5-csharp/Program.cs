using Chapter5Demo;

Console.WriteLine("=== C# Interfaces + Multiple Interfaces Demo ===");

var dog1 = new AngryDog("Brian");
var dog2 = new AngryDog("Merlin");

dog1.DrawSpeechBalloon($"Hello, my name is {dog1.NickName}");
dog1.DrawSpeechBalloon(dog2, "How do you do?");
dog2.DrawThoughtBalloon("Who are you? I think.");

Console.WriteLine();

var cat = new AngryCat("Garfield", 10, "Mr. Garfield", 0, 10, 20);
cat.Draw(cat.X, cat.Y);
dog1.DrawSpeechBalloon(cat, $"Hello {cat.NickName}");

Console.WriteLine();

var alien = new AngryCatAlien("Xeno", 120, "Mr. Xeno", 0, 10, 20, 3);
if (alien.IsIntersectingWith(cat))
{
    alien.Move(cat.X + 20, cat.Y + 20);
}
alien.Appear();

Console.WriteLine();

var wizard = new AngryCatWizard("Gandalf", 75, "Mr. Gandalf", 100, 30, 40, 9001);
wizard.Draw(wizard.X, wizard.Y);
wizard.DisappearAlien(alien);
alien.Appear();

Console.WriteLine();

var knight = new AngryCatKnight("Camelot", 35, "Sir Camelot", 500, 50, 50, 100, 30);
knight.Draw(knight.X, knight.Y);
knight.UnsheathSword(alien);

Console.WriteLine();

// Example of a method that receives an interface type:
static void Announce(IComicCharacter character)
    => character.DrawSpeechBalloon("I can talk because I implement IComicCharacter.");

Announce(dog1);
Announce(cat);
