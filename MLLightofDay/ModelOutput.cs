using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace DaylightML.Model
    {
        public class ModelOutput
        {
            // ColumnName attribute is used to change the column name from
            // its default value, which is the name of the field.
            [ColumnName("PredictedLabel")]
            public Single Prediction { get; set; }
            public float[] Score { get; set; }
        }
    
}
