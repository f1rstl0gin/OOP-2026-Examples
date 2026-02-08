"""Python demo for Chapter 5 topics.

Covered concepts:
  - Multiple inheritance with *orthogonal* base classes (comic + game)
  - Declaring base classes and overriding methods
  - Using Abstract Base Classes (abc.ABC / @abstractmethod)

This is original demo code (not copied from the textbook) that matches the
chapter's learning objectives.
"""

from __future__ import annotations

from abc import ABC, abstractmethod
from dataclasses import dataclass
from typing import Optional


# -----------------------------
# Abstract base classes (ABCs)
# -----------------------------

class ComicCharacter(ABC):
    """A character that can render speech and thought balloons."""

    def __init__(self, nick_name: str) -> None:
        self._nick_name = nick_name

    @property
    def nick_name(self) -> str:
        return self._nick_name

    @abstractmethod
    def draw_speech_balloon(self, message: str, destination: Optional["ComicCharacter"] = None) -> None:
        raise NotImplementedError

    @abstractmethod
    def draw_thought_balloon(self, message: str) -> None:
        raise NotImplementedError


class GameCharacter(ABC):
    """A character that exists in a 2D game space."""

    def __init__(self, full_name: str, initial_score: int, x: int, y: int) -> None:
        self._full_name = full_name
        self._score = initial_score
        self._x = x
        self._y = y

    @property
    def full_name(self) -> str:
        return self._full_name

    @property
    def score(self) -> int:
        return self._score

    @property
    def x(self) -> int:
        return self._x

    @property
    def y(self) -> int:
        return self._y

    @abstractmethod
    def draw(self) -> None:
        raise NotImplementedError

    @abstractmethod
    def move(self, x: int, y: int) -> None:
        raise NotImplementedError

    @abstractmethod
    def is_intersecting_with(self, other: "GameCharacter") -> bool:
        raise NotImplementedError


class Alien(ABC):
    """Something that can appear/disappear and has eyes."""

    def __init__(self, number_of_eyes: int) -> None:
        self._number_of_eyes = number_of_eyes
        self._is_visible = False

    @property
    def number_of_eyes(self) -> int:
        return self._number_of_eyes

    def appear(self) -> None:
        self._is_visible = True
        print(f"[Alien] appears with {self.number_of_eyes} eyes")

    def disappear(self) -> None:
        self._is_visible = False
        print("[Alien] disappears")


class Wizard(ABC):
    def __init__(self, spell_power: int) -> None:
        self._spell_power = spell_power

    @property
    def spell_power(self) -> int:
        return self._spell_power

    def vanish(self, target: Alien) -> None:
        # Simple demo: spell succeeds if power >= eyes * 10
        threshold = target.number_of_eyes * 10
        if self.spell_power >= threshold:
            print(f"[Wizard] spell succeeds (power={self.spell_power} >= {threshold})")
            target.disappear()
        else:
            print(f"[Wizard] spell fizzles (power={self.spell_power} < {threshold})")


class Knight(ABC):
    def __init__(self, sword_power: int, sword_weight: int) -> None:
        self._sword_power = sword_power
        self._sword_weight = sword_weight

    @property
    def sword_power(self) -> int:
        return self._sword_power

    @property
    def sword_weight(self) -> int:
        return self._sword_weight

    def unsheathe_sword(self, target: Alien) -> None:
        print(f"[Knight] unsheathes sword (power={self.sword_power}) at alien({target.number_of_eyes} eyes)")


# ---------------------------------
# Concrete classes using inheritance
# ---------------------------------


@dataclass
class AngryCat(ComicCharacter, GameCharacter):
    """A character that is both a comic character and a game character."""

    age: int

    def __init__(
        self,
        nick_name: str,
        age: int,
        full_name: str,
        initial_score: int,
        x: int,
        y: int,
    ) -> None:
        ComicCharacter.__init__(self, nick_name)
        GameCharacter.__init__(self, full_name, initial_score, x, y)
        self.age = age

    # --- ComicCharacter ---
    def draw_speech_balloon(self, message: str, destination: Optional[ComicCharacter] = None) -> None:
        prefix = self.nick_name
        if destination is not None:
            print(f"{prefix} -> {destination.nick_name}: \"{message}\"")
        else:
            print(f"{prefix} -> \"{message}\"")

    def draw_thought_balloon(self, message: str) -> None:
        print(f"{self.nick_name} ***{message}***")

    # --- GameCharacter ---
    def draw(self) -> None:
        print(f"[Draw] {self.full_name} at ({self.x},{self.y}) score={self.score}")

    def move(self, x: int, y: int) -> None:
        self._x = x
        self._y = y
        print(f"[Move] {self.full_name} -> ({self.x},{self.y})")

    def is_intersecting_with(self, other: GameCharacter) -> bool:
        # Toy collision model: exact coordinate match
        return self.x == other.x and self.y == other.y


class AngryCatAlien(AngryCat, Alien):
    def __init__(
        self,
        nick_name: str,
        age: int,
        full_name: str,
        initial_score: int,
        x: int,
        y: int,
        number_of_eyes: int,
    ) -> None:
        AngryCat.__init__(self, nick_name, age, full_name, initial_score, x, y)
        Alien.__init__(self, number_of_eyes)


class AngryCatWizard(AngryCat, Wizard):
    def __init__(
        self,
        nick_name: str,
        age: int,
        full_name: str,
        initial_score: int,
        x: int,
        y: int,
        spell_power: int,
    ) -> None:
        AngryCat.__init__(self, nick_name, age, full_name, initial_score, x, y)
        Wizard.__init__(self, spell_power)


class AngryCatKnight(AngryCat, Knight):
    def __init__(
        self,
        nick_name: str,
        age: int,
        full_name: str,
        initial_score: int,
        x: int,
        y: int,
        sword_power: int,
        sword_weight: int,
    ) -> None:
        AngryCat.__init__(self, nick_name, age, full_name, initial_score, x, y)
        Knight.__init__(self, sword_power, sword_weight)


def show_mro(cls: type) -> None:
    print("MRO:")
    for t in cls.__mro__:
        print("  -", t.__name__)
