class Notification:
    def send(self, message):
        raise NotImplementedError("Subclasses must implement send()")


class EmailNotification(Notification):
    def send(self, message):
        print(f"Sending EMAIL: {message}")


class SMSNotification(Notification):
    def send(self, message):
        print(f"Sending SMS: {message}")


class PushNotification(Notification):
    def send(self, message):
        print(f"Sending PUSH alert: {message}")


def run_demo():
    notifications = [
        EmailNotification(),
        SMSNotification(),
        PushNotification(),
    ]

    for notification in notifications:
        notification.send("System maintenance tonight at 11 PM")


if __name__ == "__main__":
    run_demo()
