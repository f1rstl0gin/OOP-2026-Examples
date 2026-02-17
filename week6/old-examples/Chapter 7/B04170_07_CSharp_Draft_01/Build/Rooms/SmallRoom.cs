namespace Chapter7.Build.Rooms
{
    using System;
    using General;

    public class SmallRoom : Room
    {
        public override string Description
        {
            get { return "Small room"; }
            set { throw new InvalidOperationException(); }
        }

        public SmallRoom(double x, double y, double width, double height, IFloorPlanElement parent)
            : base(x, y, width, height, parent)
        {
        }
    }
}
