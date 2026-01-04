# Design Justification (Composition vs. Inheritance)

## Inheritance
`SmartLight` and `SmartSpeaker` inherit from `Device` because they share a common identity
(name) and override behavior (`status`). This avoids repeating the `name` property while
keeping device-specific logic in each subclass.

## Composition
`Room` **composes** `Device` objects, and `SmartHub` **composes** `Room` objects. Rooms are
not a type of device; they **contain** devices. Likewise, a hub is not a type of room—it
**aggregates** rooms to form a full-home view. Composition models the real-world “has-a”
relationship and allows rooms to manage a mix of device types without deep inheritance trees.
