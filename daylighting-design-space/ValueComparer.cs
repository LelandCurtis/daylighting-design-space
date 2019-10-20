using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace DaylightingDesignSpace
{
    public class ValueComparer : GH_Component, IGH_VariableParameterComponent
    {

        public ValueComparer()
          : base("ValueComparer", "VComp",
              "Compares pairs of values to determine accuracy of a model",
              "DDS", "Cat01")
        {
        }

        private int m_iteration = 1;
        private bool m_restart = false;

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Output01", "01", "First value should be 'correct' value, second value should be 'ML prediction', third value is optional weighting value (default weight is 1.0)", GH_ParamAccess.list);
            pManager.AddNumberParameter("", "", "", GH_ParamAccess.tree);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("output1", "test output", "this is a description", GH_ParamAccess.list);
        }

        public bool CanInsertParameter(GH_ParameterSide side, int index)
        {
            //Allow parameter insertion on "input" side only
            if (side == 0) { return true; }
            return false;
        }

        public bool CanRemoveParameter(GH_ParameterSide side, int index)
        {
            //Allow parameter deletion only on the input side and only if it is not the [P] input or the last of the sort patterns
            if ((side == 0) && (Params.Input.Count > 1)) { return true; }
            return false;
        }

        public IGH_Param CreateParameter(GH_ParameterSide side, int index)
        {
            IGH_Param param = new Grasshopper.Kernel.Parameters.Param_Number();

            string x = "";
            if (index < 10) { x = "0" + index.ToString(); }
            else { x = index.ToString(); }

            param.Name = "Gene_" + x;
            param.NickName = "G_" + x;
            param.MutableNickName = false;
            param.Description = "One gene, must be formated as list with three items, 0:min, 1:max, 2:step_size";
            param.Access = GH_ParamAccess.list;

            return param;
        }

        public bool DestroyParameter(GH_ParameterSide side, int index)
        {
            this.m_restart = true;
            return true;
        }

        public void VariableParameterMaintenance()
        {
            throw new NotImplementedException();
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            /*
            string mystring = null;
            DA.GetData(0, ref mystring);
            int myint = 0;
            DA.GetData(1, ref myint);

            Gene myGene = new Gene(mystring, myint);
            myDict.Add(myGene.ToString(), myGene);
            List<string> myList = new List<string>();
            foreach (KeyValuePair<string, Gene> kvp in myDict) 
            {
                myList.Add(kvp.Key);
            }

            DA.SetDataList(0, myList);
           */
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