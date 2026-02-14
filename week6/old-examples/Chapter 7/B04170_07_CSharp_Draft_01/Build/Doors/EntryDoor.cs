namespace Chapter7.Build.Doors
{
    using System;
    using General;

    public class EntryDoor : Door
    {
        public override string Description
        {
            get { return "Entry Door"; }
            set { throw new InvalidOperationException(); }
        }

        public EntryDoor(double x, double y, double width, double height, IFloorPlanElement parent)
            : base(x, y, width, height, parent)
        {
        }
    }
}
