namespace Chapter7
{
    using System;
    /*using Build.Rooms;
    using Build.Doors;
    using Furnish.Bedroom.Beds;
    */

    class Program
    {
        static void Main(string[] args)
        {
            var room1 = new Build.Rooms.SquareRoom(0, 0, 200, null);
            var door1 = new Build.Doors.EntryDoor(100, 1, 50, 5, room1);
            var bedroom1 = new Build.Rooms.SquareRoom(100, 200, 180, null);
            var bed1 = new Furnish.Bedroom.Beds.FabricBed(130, 230, 120, 110, bedroom1);
            room1.Draw();
            door1.Draw();
            bedroom1.Draw();
            bed1.Draw();

            Console.ReadLine();
        }
    }
}
