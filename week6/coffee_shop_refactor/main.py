from catalog import Beverage, Menu
from ui import prompt_for_items


def main() -> None:
    menu = Menu(
        [
            Beverage("Latte", 3.50),
            Beverage("Cold Brew", 3.25),
            Beverage("Tea", 2.25),
        ]
    )
    print("Welcome to the refactored cafe!")
    order = prompt_for_items(menu)
    print("\nReceipt:")
    print(order.receipt())


if __name__ == "__main__":
    main()
