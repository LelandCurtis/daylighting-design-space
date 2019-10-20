using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace DaylightingDesignSpace
{
    public class Simulation_Repo : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Simulation_Repo()
          : base("Simulation Repo", "Sim Repo",
              "This component draws from an existing database of simulated data to replace a parametric simulation engine",
              "DDS", "Cat01")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Data", "D", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.tree);
            pManager.AddParameter(new GenomeParameter(), "Genome", "G", "Input a list of genome objects", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new GenomeParameter(), "Genomes", "G", "this is a list of all of the input parameters that define the unique iteration", GH_ParamAccess.item);
            pManager.AddParameter(new PhenomeParameter(), "Phenomes", "P", "this is a list of all of the output metrics from the unique iteration", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            /// initialize the objects
            Genome genome = new Genome();
            Phenome phenome = new Phenome();

            ///filter the input 

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
            get { return new Guid("82169b74-e0ff-4b87-8ab4-3071b37ee615"); }
        }
    }
}