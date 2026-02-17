namespace Chapter7.Build.Rooms
{
    using System;
    using General;

    public class Closet : Room
    {
        public override string Description
        {
            get { return "Closet"; }
            set { throw new InvalidOperationException(); }
        }

        public Closet(double x, double y, double width, double height, IFloorPlanElement parent)
            : base(x, y, width, height, parent)
        {
        }
    }
}
