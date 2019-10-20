using System;
using System.Collections.Generic;
using MyProject1ML.Model;
using MyProject1ML.ConsoleApp;
using Grasshopper.Kernel;
using System.Linq;
//using Microsoft.ML.Trainers;
using Rhino.Geometry;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace MyProject1
{
    public class MyProject1Component : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public MyProject1Component()
          : base("DaylightML", "DaylightML",
              "Description",
              "Curve", "Primative")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("mesh", "mesh", "mesh for description", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Prediction", "Prediction", "Prediction", GH_ParamAccess.item);
            pManager.AddNumberParameter("Score", "Score", "Score", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //ModelBuilder model = ModelBuilder();
            ModelBuilder.CreateModel();                 
            // Add input data

            ModelInput sampleData = new ModelInput() {
                In_location = "PH", In_Orientation = 0, In_ObstructAngle = 0, In_Width = 40, In_Depth = 40, In_Ceiling_Height = 9, In_Wall_Thickness = (float)0.5, In_Window_Width = 4,
                In_Window_Bottom_Sill = (float)2.5, In_Window_Top_Sill = (float)8.7, In_Spacing_Between_Windows = 1, In_WWR = (float)0.4822222, In_Ceiling_Reflectance = 80, In_Wall_Reflectance = 60,
                In_Floor_Reflectance = 20, In_Shade_Trigger_Distance__1000_direct_ = 1
            };
            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(sampleData);
            DA.SetData(0, (double)result.Prediction);
            
            List<double> newScore = new List<double>();

            foreach (float y in result.Score)
            {
                newScore.Add((double)y);
            }

            DA.SetDataList(1, newScore);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("6f563568-0d7b-4fd2-9ab0-173da45b5bad"); }
        }
        
    }
    
}
