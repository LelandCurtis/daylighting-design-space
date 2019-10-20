﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace DaylightML.Model
{

        public class ModelInput
        {
            [ColumnName("in:location"), LoadColumn(0)]
            public string In_location { get; set; }


            [ColumnName("in:Orientation"), LoadColumn(1)]
            public float In_Orientation { get; set; }


            [ColumnName("in:ObstructAngle"), LoadColumn(2)]
            public float In_ObstructAngle { get; set; }


            [ColumnName("in:Width"), LoadColumn(3)]
            public float In_Width { get; set; }


            [ColumnName("in:Depth"), LoadColumn(4)]
            public float In_Depth { get; set; }


            [ColumnName("in:Ceiling Height"), LoadColumn(5)]
            public float In_Ceiling_Height { get; set; }


            [ColumnName("in:Wall Thickness"), LoadColumn(6)]
            public float In_Wall_Thickness { get; set; }


            [ColumnName("in:Window Width"), LoadColumn(7)]
            public float In_Window_Width { get; set; }


            [ColumnName("in:Window Bottom Sill"), LoadColumn(8)]
            public float In_Window_Bottom_Sill { get; set; }


            [ColumnName("in:Window Top Sill"), LoadColumn(9)]
            public float In_Window_Top_Sill { get; set; }


            [ColumnName("in:Spacing Between Windows"), LoadColumn(10)]
            public float In_Spacing_Between_Windows { get; set; }


            [ColumnName("in:WWR"), LoadColumn(11)]
            public float In_WWR { get; set; }


            [ColumnName("in:Ceiling Reflectance"), LoadColumn(12)]
            public float In_Ceiling_Reflectance { get; set; }


            [ColumnName("in:Wall Reflectance"), LoadColumn(13)]
            public float In_Wall_Reflectance { get; set; }


            [ColumnName("in:Floor Reflectance"), LoadColumn(14)]
            public float In_Floor_Reflectance { get; set; }


            [ColumnName("in:Shade Trigger Distance (1000 direct)"), LoadColumn(15)]
            public float In_Shade_Trigger_Distance__1000_direct_ { get; set; }


            [ColumnName("out:sDA300"), LoadColumn(16)]
            public float Out_sDA300 { get; set; }


        }
    
}
