from models import Beverage, Coffee, CoffeeShop, Tea


def run_console_ui() -> None:
    shop = CoffeeShop(
        name="Campus Cafe",
        menu=[
            Coffee("Latte", 3.50, roast="Medium"),
            Coffee("Cold Brew", 3.25, roast="Dark"),
            Tea("Earl Grey", 2.50, origin="Sri Lanka"),
        ],
    )
    order = shop.create_order()

    print(f"Welcome to {shop.name}!")
    print("Menu:")
    for item in shop.menu:
        print(f"- {item.describe()}")

    while True:
        choice = input("Add item by name (or 'done'): ").strip()
        if choice.lower() == "done":
            break
        item: Beverage | None = shop.find_item(choice)
        if item:
            order.add_item(item)
            print(f"Added {item.name}.")
        else:
            print("Item not found.")

    print("\nOrder summary:")
    print(order.summary())


if __name__ == "__main__":
    run_console_ui()
