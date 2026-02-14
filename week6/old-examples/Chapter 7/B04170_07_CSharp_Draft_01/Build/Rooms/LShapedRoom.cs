namespace Chapter7.Build.Rooms
{
    using System;
    using General;

    public class LShapedRoom: Room
    {
        public override string Description
        {
            get { return "L-Shaped room"; }
            set { throw new InvalidOperationException(); }
        }

        public LShapedRoom(double x, double y, double width, double height, IFloorPlanElement parent) : base(x, y, width, height, parent)
        {
        }
    }
}
