using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using DaylightML;

namespace daylighting_design_space
{
    public class MLTrainer : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MLTrainer class.
        /// </summary>
        public MLTrainer()
          : base("MLTrainer", "Nickname",
              "Description",
              "Category", "Subcategory")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("number", "num", "whatever", GH_ParamAccess.item);
        }


        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Prediction", "Prediction", "Prediction", GH_ParamAccess.item);
            pManager.AddNumberParameter("Score", "Score", "Score", GH_ParamAccess.list);
            pManager.AddTextParameter("text", "text", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            //ModelBuilder model = ModelBuilder();
            //ModelBuilder.CreateModel();
            // Add input data
            /*
            Model.ModelInput sampleData = new ModelInput()
            {
                In_location = "PH",
                In_Orientation = 0,
                In_ObstructAngle = 0,
                In_Width = 40,
                In_Depth = 40,
                In_Ceiling_Height = 9,
                In_Wall_Thickness = (float)0.5,
                In_Window_Width = 4,
                In_Window_Bottom_Sill = (float)2.5,
                In_Window_Top_Sill = (float)8.7,
                In_Spacing_Between_Windows = 1,
                In_WWR = (float)0.4822222,
                In_Ceiling_Reflectance = 80,
                In_Wall_Reflectance = 60,
                In_Floor_Reflectance = 20,
                In_Shade_Trigger_Distance__1000_direct_ = 1
            };
            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(sampleData);
            DA.SetData(0, (double)result.Prediction);

            List<double> newScore = new List<double>();

            foreach (float y in result.Score)
            {
                newScore.Add((double)y);
            }
            */
            string testString = ModelBuilder.Foobar();

            //DA.SetDataList(1, newScore);
            DA.SetData(2, testString);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("c84d5aeb-ffd0-44d3-a295-7137ec7f62a5"); }
        }
    }
}