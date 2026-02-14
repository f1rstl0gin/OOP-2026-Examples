namespace Chapter7.General
{
    using System;

    public abstract class FloorPlanElement: IFloorPlanElement
    {
        public virtual string Category 
        { 
            get { return "Undefined"; }
            set { throw new InvalidOperationException(); }
        }

        public virtual string Description
        {
            get { return "Undefined"; }
            set { throw new InvalidOperationException(); }
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        private IFloorPlanElement _parent;
        public IFloorPlanElement Parent
        {
            get { return _parent; }
            set { throw new InvalidOperationException(); }
        }

        public FloorPlanElement(double x, double y, double width, double height, IFloorPlanElement parent)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this._parent = parent;
        }

        public void MoveTo(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public void PrintCategory()
        {
            Console.WriteLine(this.Category);
        }

        public void PrintDescription()
        {
            Console.WriteLine(this.Description);
        }

        public void Draw()
        {
            this.PrintCategory();
            this.PrintDescription();
            Console.WriteLine(
                "X: {0}, Y: {1}. Width: {2}, Height: {3}.",
                this.X,
                this.Y,
                this.Width,
                this.Height);
        }
    }
}
