from models import CoffeeShop, MenuItem


def run_console_ui() -> None:
    shop = CoffeeShop(
        name="Campus Cafe",
        menu=[
            MenuItem("Latte", 3.50),
            MenuItem("Cold Brew", 3.00),
            MenuItem("Tea", 2.25),
        ],
    )
    order = shop.create_order()

    print(f"Welcome to {shop.name}!")
    print("Menu:")
    for item in shop.menu:
        print(f"- {item.display()}")

    while True:
        choice = input("Add item by name (or 'done'): ").strip()
        if choice.lower() == "done":
            break
        item = shop.find_item(choice)
        if item:
            order.add_item(item)
            print(f"Added {item.name}.")
        else:
            print("Item not found.")

    print("\nOrder summary:")
    print(order.summary())


if __name__ == "__main__":
    run_console_ui()
