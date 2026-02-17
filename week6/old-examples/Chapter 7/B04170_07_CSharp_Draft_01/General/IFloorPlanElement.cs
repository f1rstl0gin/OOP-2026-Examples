namespace Chapter7.General
{
    public interface IFloorPlanElement
    {
        string Category { get; set; }
        string Description { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        IFloorPlanElement Parent { get; set; }

        void MoveTo(double x, double y);
        void PrintCategory();
        void PrintDescription();
        void Draw();
    }
}
