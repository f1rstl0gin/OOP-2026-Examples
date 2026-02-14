namespace Chapter7.Build.Doors
{
    using System;
    using General;

    public abstract class Door : FloorPlanElement
    {
        public override string Category
        {
            get { return "Door"; }
            set { throw new InvalidOperationException(); }
        }

        public Door(double x, double y, double width, double height, IFloorPlanElement parent)
            : base(x, y, width, height, parent)
        {
        }
    }
}
