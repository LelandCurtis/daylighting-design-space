using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace DaylightingDesignSpace
{
    public class Database : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Database class.
        /// </summary>
        public Database()
          : base("Database", "Database",
              "This component combines the phenome and genome of every iteration and adds it to a genome and phenome dictionary database",
              "DDS", "Cat01")
        {
        }

        /// <summary>
        /// Initialize dictionaries
        /// </summary>
        public Dictionary<string, Genome> gDict = new Dictionary<string, Genome>();
        public Dictionary<string, Phenome> pDict = new Dictionary<string, Phenome>();

        /// take a genome and add it to a persistent list.
        List<Genome> genomeList = new List<Genome>();

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddParameter(new GenomeParameter(), "Genome", "G", "Input a list of genome objects", GH_ParamAccess.item);
            pManager.AddParameter(new PhenomeParameter(), "Phenome", "P", "Input a list of phenome objects", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new GenomeParameter(),"Genomes", "G", "this is a list of all of the input parameters that define the unique iterations", GH_ParamAccess.list);
            pManager.AddParameter(new PhenomeParameter(), "Phenomes", "P", "this is a list of all of the output metrics from each unique iterations", GH_ParamAccess.list);
           
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            /// get data
            Genome genome = new Genome();
            Phenome phenome = new Phenome();
            DA.GetData(0, ref genome);
            DA.GetData(1, ref phenome);

            /// add genomes and phenomes into a dictionary
            gDict.Add(genome.ToString(), genome);
            pDict.Add(phenome.ToString(), phenome);

            /// create new lists
            List<Genome> gList = new List<Genome>();
            List<Phenome> pList = new List<Phenome>();

            /// cylce through the entire dictionary and copy values (genome  / phenome objects) into output lists
            foreach (KeyValuePair<string, Genome> kvp in gDict)
            {
                gList.Add(kvp.Value);
            }

            foreach (KeyValuePair<string, Phenome> kvp in pDict)
            {
                pList.Add(kvp.Value);
            }
            
            /// set output variables
            DA.SetDataList(0, gList);
            DA.SetDataList(1, pList);

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