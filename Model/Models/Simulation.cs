using Microsoft.ML.Data;

namespace Model.Models
{
    public class Simulation
    {
        [LoadColumn(0)]
        public string Location;

        [LoadColumn(1)]
        public string Orientation;

        [LoadColumn(2)]
        public float ObstructAngle;

        [LoadColumn(3)]
        public float Width;

        [LoadColumn(4)]
        public float Depth;

        [LoadColumn(5)]
        public string CeilingHeight;

        [LoadColumn(6)]
        public float WallThicknes;
        
        [LoadColumn(7)]
        public float WindowWidth;
        
        [LoadColumn(8)]
        public float WindowBottomSill;
        
        [LoadColumn(9)]
        public float WindowTopSill;
        
        [LoadColumn(10)]
        public float SpacingBetweenWindow;
        
        [LoadColumn(11)]
        public float WWR;
        
        [LoadColumn(12)]
        public float CeilingReflectance;
        
        [LoadColumn(13)]
        public float WallReflectance;
        
        [LoadColumn(14)]
        public float FloorReflectance;
        
        [LoadColumn(15)]
        public float ShadeTriggerDistance;
    }
}