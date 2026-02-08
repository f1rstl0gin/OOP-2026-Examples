"""Run the Python Chapter 5 demo.

This demo focuses on:
  - Multiple inheritance (ComicCharacter + GameCharacter)
  - Extending a class with additional capabilities (Alien / Wizard / Knight)
  - ABCs and why instantiating abstract classes fails
  - How Python resolves methods with MRO
"""

from characters import (
    ComicCharacter,
    GameCharacter,
    AngryCat,
    AngryCatAlien,
    AngryCatWizard,
    AngryCatKnight,
    show_mro,
)


def main() -> None:
    print("=== MRO demo ===")
    show_mro(AngryCatAlien)

    print("\n=== Basic multiple inheritance (comic + game) ===")
    cat = AngryCat(nick_name="Garfield", age=10, full_name="Mr. Garfield", initial_score=0, x=10, y=20)
    cat.draw(cat.x, cat.y)
    cat.draw_speech_balloon(f"Hello, my name is {cat.nick_name}")
    cat.draw_thought_balloon("Where's my lasagna?")

    print("\n=== Add a capability with another base (Alien) ===")
    alien_cat = AngryCatAlien(
        nick_name="Xeno",
        age=120,
        full_name="Mr. Xeno",
        initial_score=0,
        x=10,
        y=20,
        number_of_eyes=3,
    )
    # Polymorphism by behavior: alien_cat is both ComicCharacter and GameCharacter
    as_comic: ComicCharacter = alien_cat
    as_game: GameCharacter = alien_cat
    as_comic.draw_speech_balloon("I come in peace.", destination=cat)
    if as_game.is_intersecting_with(cat):
        as_game.move(cat.x + 20, cat.y + 20)
    alien_cat.appear()

    print("\n=== Add a capability (Wizard) that works with an interface-like base (Alien) ===")
    wizard_cat = AngryCatWizard(
        nick_name="Gandalf",
        age=75,
        full_name="Mr. Gandalf",
        initial_score=100,
        x=30,
        y=40,
        spell_power=9001,
    )
    wizard_cat.draw(wizard_cat.x, wizard_cat.y)
    wizard_cat.disappear_alien(alien_cat)
    alien_cat.appear()

    print("\n=== Add a capability (Knight) that receives an Alien argument ===")
    knight_cat = AngryCatKnight(
        nick_name="Camelot",
        age=35,
        full_name="Sir Camelot",
        initial_score=500,
        x=50,
        y=50,
        sword_power=100,
        sword_weight=30,
    )
    knight_cat.unsheathe_sword(alien_cat)
    alien_cat.draw_speech_balloon("Pleased to meet you, Sir.", destination=knight_cat)


if __name__ == "__main__":
    main()
