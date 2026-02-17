namespace Chapter7.Build.Rooms
{
    using System;
    using General;

    public abstract class Room : General.FloorPlanElement
    {
        public override string Category
        {
            get { return "Room"; }
            set { throw new InvalidOperationException(); }
        }

        public Room(double x, double y, double width, double height, IFloorPlanElement parent) : base(x, y, width, height, parent)
        {
        }
    }
}
