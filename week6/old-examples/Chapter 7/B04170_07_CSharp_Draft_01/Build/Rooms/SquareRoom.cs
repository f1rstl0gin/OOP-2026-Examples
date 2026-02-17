namespace Chapter7.Build.Rooms
{
    using System;
    using General;

    class SquareRoom : Room
    {
        public override string Description
        {
            get { return "Square room"; }
            set { throw new InvalidOperationException(); }
        }

        public SquareRoom(double x, double y, double width, IFloorPlanElement parent) : base(x, y, width, width, parent)
        {
        }
    }
}
