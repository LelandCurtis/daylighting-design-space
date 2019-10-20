using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
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
        /// Initialize dictionaries
        /// </summary>
        public Dictionary<string, Genome> gDict = new Dictionary<string, Genome>();
        public Dictionary<string, Phenome> pDict = new Dictionary<string, Phenome>();


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Data1", "D1", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data2", "D2", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data3", "D3", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data4", "D4", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data5", "D5", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data6", "D6", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data7", "D7", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data8", "D8", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data9", "D9", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data10", "D10", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data11", "D11", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            pManager.AddNumberParameter("Data12", "D12", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            
            pManager.AddTextParameter("Genome", "G", "Input a genome as properly formated text", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Build Database", "R", "Run 'Build Database' to create a dictionary of Genome objects from the data", GH_ParamAccess.item);
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
            //get boolean input
            //if true
                //myDict.Clean()
                //go through each input (connected to Excel importer)
                //build new dictionary



            /// initialize the objects
            List<string> d1 = new List<string>();
            List<string> d2 = new List<string>();
            List<string> d3 = new List<string>();
            List<string> d4 = new List<string>();
            List<string> d5 = new List<string>();
            List<string> d6 = new List<string>();
            List<string> d7 = new List<string>();
            List<string> d8 = new List<string>();
            List<string> d9 = new List<string>();
            List<string> d10 = new List<string>();
            List<string> d11 = new List<string>();
            List<string> d12 = new List<string>();

            String myGenome = "";
            Genome genome = new Genome();
            Boolean run = new Boolean();
            Phenome phenome = new Phenome();

            DA.GetDataList(0, d1);
            DA.GetDataList(1, d2);
            DA.GetDataList(2, d3);
            DA.GetDataList(3, d4);
            DA.GetDataList(4, d5);
            DA.GetDataList(5, d6);
            DA.GetDataList(6, d7);
            DA.GetDataList(7, d8);
            DA.GetDataList(8, d9);
            DA.GetDataList(9, d10);
            DA.GetDataList(10, d11);
            DA.GetDataList(11, d12);
            DA.GetData(12, ref myGenome);
            DA.GetData(13, ref run);



            ///if run = true, create the dictionary
            if(run == true)
                /// clean dictionary
                gDict.Clear();
                pDict.Clear();

                
                /// create genomes and phenomes from input data
                for (int i = 0; i < d1.Count; i++)
                    ///genome = Genome(d1[i], d2[i], d3[i], d4[i], d5[i], d6[i], d7[i], d8[i], d9[i], d10[i], d11[i], d12[i]);


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