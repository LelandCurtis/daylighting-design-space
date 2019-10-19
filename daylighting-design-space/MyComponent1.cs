using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace daylighting_design_space
{
    public class MyComponent1 : GH_Component, IGH_VariableParameterComponent
    {

        public MyComponent1()
          : base("ValueComparer", "VComp",
              "Compares pairs of values to determine accuracy of a model",
              "DDS", "Cat01")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Output01", "01", "First value should be 'correct' value, second value should be 'ML prediction', third value is optional weighting value (default weight is 1.0)", GH_ParamAccess.list);
            pManager.AddNumberParameter("", "", "", GH_ParamAccess.tree);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            
            
           
        }

        public bool CanInsertParameter(GH_ParameterSide side, int index)
        {
            if 
        }

        public bool CanRemoveParameter(GH_ParameterSide side, int index)
        {
            throw new NotImplementedException();
        }

        public IGH_Param CreateParameter(GH_ParameterSide side, int index)
        {
            throw new NotImplementedException();
        }

        public bool DestroyParameter(GH_ParameterSide side, int index)
        {
            throw new NotImplementedException();
        }

        public void VariableParameterMaintenance()
        {
            throw new NotImplementedException();
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
            get { return new Guid("a8e4d468-6d73-455c-8c89-accd89781b45"); }
        }
    }
}