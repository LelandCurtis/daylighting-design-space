﻿using System;
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
            //0
            pManager.AddIntegerParameter("Data1", "D1", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //1
            pManager.AddNumberParameter("Data2", "D2", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //2
            pManager.AddNumberParameter("Data3", "D3", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //3
            pManager.AddNumberParameter("Data4", "D4", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //4
            pManager.AddNumberParameter("Data5", "D5", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //5
            pManager.AddNumberParameter("Data6", "D6", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //6
            pManager.AddNumberParameter("Data7", "D7", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //7
            pManager.AddNumberParameter("Data8", "D8", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //8
            pManager.AddNumberParameter("Data9", "D9", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //9
            pManager.AddNumberParameter("Data10", "D10", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //10
            pManager.AddNumberParameter("Data11", "D11", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //11
            pManager.AddNumberParameter("Data12", "D12", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);


            //12
            pManager.AddIntegerParameter("Data13", "D13", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //13
            pManager.AddNumberParameter("Data14", "D14", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //14
            pManager.AddNumberParameter("Data15", "D15", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //15
            pManager.AddNumberParameter("Data16", "D16", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //16
            pManager.AddNumberParameter("Data17", "D17", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //17
            pManager.AddNumberParameter("Data18", "D18", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //18
            pManager.AddNumberParameter("Data19", "D19", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //19
            pManager.AddNumberParameter("Dat20", "D20", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //20
            pManager.AddNumberParameter("Data21", "D21", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //21
            pManager.AddNumberParameter("Data22", "D22", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //22
            pManager.AddNumberParameter("Data23", "D23", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);
            //23
            pManager.AddNumberParameter("Data24", "D24", "Input a tree of data, with columns as branches, and rows as lists", GH_ParamAccess.list);


            //24
            pManager.AddTextParameter("Genome", "G", "Input a genome as properly formated text", GH_ParamAccess.item);
            //25
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
            List<int> d1 = new List<int>();
            List<double> d2 = new List<double>();
            List<double> d3 = new List<double>();
            List<double> d4 = new List<double>();
            List<double> d5 = new List<double>();
            List<double> d6 = new List<double>();
            List<double> d7 = new List<double>();
            List<double> d8 = new List<double>();
            List<double> d9 = new List<double>();
            List<double> d10 = new List<double>();
            List<double> d11 = new List<double>();
            List<double> d12 = new List<double>();

            List<double> d13 = new List<double>();
            List<double> d14 = new List<double>();
            List<double> d15 = new List<double>();
            List<double> d16 = new List<double>();
            List<double> d17 = new List<double>();
            List<double> d18 = new List<double>();
            List<double> d19 = new List<double>();
            List<double> d20 = new List<double>();
            List<double> d21 = new List<double>();
            List<double> d22 = new List<double>();
            List<double> d23 = new List<double>();
            List<double> d24 = new List<double>();

            String myGenome = "";
            Boolean run = new Boolean();
            

            if(!DA.GetDataList(0, d1)) { return; }
            if (!DA.GetDataList(1, d2)) { return; }
            if (!DA.GetDataList(2, d3)) { return; }
            if (!DA.GetDataList(3, d4)) { return; }
            if (!DA.GetDataList(4, d5)) { return; }
            if (!DA.GetDataList(5, d6)) { return; }
            if (!DA.GetDataList(6, d7)) { return; }
            if (!DA.GetDataList(7, d8)) { return; }
            if (!DA.GetDataList(8, d9)) { return; }
            if (!DA.GetDataList(9, d10)) { return; }
            if (!DA.GetDataList(10, d11)) { return; }
            if (!DA.GetDataList(11, d12)) { return; }

            if (!DA.GetDataList(12, d13)) { return; }
            if (!DA.GetDataList(13, d14)) { return; }
            if (!DA.GetDataList(14, d15)) { return; }
            if (!DA.GetDataList(15, d16)) { return; }
            if (!DA.GetDataList(16, d17)) { return; }
            if (!DA.GetDataList(17, d18)) { return; }
            if (!DA.GetDataList(18, d19)) { return; }
            if (!DA.GetDataList(19, d20)) { return; }
            if (!DA.GetDataList(20, d21)) { return; }
            if (!DA.GetDataList(21, d22)) { return; }
            if (!DA.GetDataList(22, d23)) { return; }
            if (!DA.GetDataList(23, d24)) { return; }

            DA.GetData(24, ref myGenome);
            DA.GetData(25, ref run);



            ///if run = true, create the dictionary
            if (run == true)
            {
                /// clean dictionary
                gDict.Clear();
                pDict.Clear();


                /// create genomes and phenomes from input data
                for (int i = 0; i < d1.Count; i++)
                {
                    int myCheckint = d1[i];
                    double[] myCheck = new double[] {d2[i],d3[i],
                    d14[i],
                    d15[i],
                    d16[i],
                    d17[i],
                    d18[i],
                    d19[i],
                    d20[i],
                    d21[i],
                    d22[i],
                    d23[i],
                    d24[i],

                    };

                    bool a = true;




                    Genome genome = new Genome(d1[i], d2[i], d3[i], d4[i], d5[i], d6[i], d7[i], d8[i], d9[i], d10[i], d11[i], d12[i]);


                    Phenome phenome = new Phenome();

                    /// add genomes and phenomes into a dictionary
                    gDict.Add(genome.ToString(), genome);
                    pDict.Add(phenome.ToString(), phenome);
                }
            }

            /// find output Genome and Phenome based on input genome
            Genome outGenome = new Genome();
            Phenome outPhenome = new Phenome();
            gDict.TryGetValue(myGenome, out outGenome);
            pDict.TryGetValue(myGenome, out outPhenome);


            DA.SetData(0, outGenome);
            DA.SetData(1, outPhenome);
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