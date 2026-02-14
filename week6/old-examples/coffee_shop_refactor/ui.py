from catalog import Menu
from order import Order


def prompt_for_items(menu: Menu) -> Order:
    order = Order()
    print("Menu:")
    for item in menu.items:
        print(f"- {item.display()}")

    while True:
        choice = input("Add item by name (or 'done'): ").strip()
        if choice.lower() == "done":
            break
        item = menu.find(choice)
        if item:
            order.add(item)
            print(f"Added {item.name}.")
        else:
            print("Item not found.")

    return order
