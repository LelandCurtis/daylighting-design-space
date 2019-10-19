using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace DaylightingDesignSpace
{
    public class Database : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent2 class.
        /// </summary>
        public Database()
          : base("Database", "Nickname",
              "Description",
              "DDS", "Cat01")
        {
        }

        public Dictionary<string, Genome> myDict = new Dictionary<string, Genome>();



        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("location", "loc", "Climate location", GH_ParamAccess.item);


        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("genome", "genome", "this is a list of all of the input parameters that define the unique iteration", GH_ParamAccess.list);
            pManager.AddTextParameter("phenome", "phenome", "this is a list of all of the output metrics that define the unique iteration", GH_ParamAccess.list);
            pManager.AddTextParameter("identity", "identity", "this is a list of the generation and number of each iteration", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string mystring = null;
            DA.GetData(0, ref mystring);
            int myint = 0;
            DA.GetData(1, ref myint);

            Genome myGene = new Genome(xxxxx);
            myDict.Add(myGene.ToString(), myGene);
            List<string> myList = new List<string>();
            foreach (KeyValuePair<string, Genome> kvp in myDict)
            {
                myList.Add(kvp.Key);
            }

            DA.SetDataList(0, myList);

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
            get { return new Guid("dec8227d-df90-4d33-91f4-55b2f89c569e"); }
        }
    }
}