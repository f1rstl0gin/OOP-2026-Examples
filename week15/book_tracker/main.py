import csv
from pathlib import Path

from models import Book, ReadingLog


def load_books(path: Path) -> ReadingLog:
    with path.open(newline="", encoding="utf-8") as file:
        reader = csv.DictReader(file)
        books = [
            Book(
                title=row["title"],
                genre=row["genre"],
                pages=int(row["pages"]),
                rating=int(row["rating"]),
            )
            for row in reader
        ]
    return ReadingLog(books)


def main() -> None:
    data_path = Path(__file__).parent / "data" / "reading_log.csv"
    log = load_books(data_path)

    print("Reading Log Summary")
    print(f"Books read: {len(log.books)}")
    print(f"Average rating: {log.average_rating():.2f}")
    print(f"Average pages: {log.average_pages():.1f}")

    print("\nTop rated books:")
    for book in log.top_rated():
        print(f"- {book.title} ({book.genre})")

    print("\nFantasy books:")
    for book in log.by_genre("Fantasy"):
        print(f"- {book.title} ({book.pages} pages)")


if __name__ == "__main__":
    main()
