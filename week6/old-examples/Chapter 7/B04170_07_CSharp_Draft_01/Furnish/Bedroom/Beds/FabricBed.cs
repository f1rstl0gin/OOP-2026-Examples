namespace Chapter7.Furnish.Bedroom.Beds
{
    using System;
    using General;

    public class FabricBed : Bed
    {
        public override string Description
        {
            get { return "Fabric Bed"; }
            set { throw new InvalidOperationException(); }
        }

        public FabricBed(double x, double y, double width, double height, IFloorPlanElement parent)
            : base(x, y, width, height, parent)
        {
        }
    }
}
