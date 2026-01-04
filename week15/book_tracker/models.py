from dataclasses import dataclass
from typing import Iterable, List


@dataclass(frozen=True)
class Book:
    title: str
    genre: str
    pages: int
    rating: int


class ReadingLog:
    def __init__(self, books: Iterable[Book]) -> None:
        self._books: List[Book] = list(books)

    @property
    def books(self) -> List[Book]:
        return list(self._books)

    def average_rating(self) -> float:
        if not self._books:
            return 0.0
        return sum(book.rating for book in self._books) / len(self._books)

    def average_pages(self) -> float:
        if not self._books:
            return 0.0
        return sum(book.pages for book in self._books) / len(self._books)

    def by_genre(self, genre: str) -> List[Book]:
        return [book for book in self._books if book.genre.lower() == genre.lower()]

    def top_rated(self) -> List[Book]:
        if not self._books:
            return []
        max_rating = max(book.rating for book in self._books)
        return [book for book in self._books if book.rating == max_rating]
