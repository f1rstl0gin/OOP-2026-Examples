namespace Chapter7.Furnish.Bedroom.Beds
{
    using System;
    using General;

    public class Bed : FloorPlanElement
    {
        public override string Category
        {
            get { return "Bed"; }
            set { throw new InvalidOperationException(); }
        }

        public override string Description
        {
            get { return "Generic Bed"; }
            set { throw new InvalidOperationException(); }
        }

        public Bed(double x, double y, double width, double height, IFloorPlanElement parent)
            : base(x, y, width, height, parent)
        {
        }
    }
}
