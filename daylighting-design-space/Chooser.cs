﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace DaylightingDesignSpace
{
    public class Chooser : GH_Component, IGH_VariableParameterComponent
    {

        public Chooser()
          : base("Chooser", "Chooser",
              "Description",
              "Category", "Subcategory")
        {
        }

        private int m_iteration = 1;
        private bool m_restart = false;

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Gene_01", "G_01", "One gene, format as list with three items, 0:min, 1:max, 2:step_size", GH_ParamAccess.list);
        }


        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("name", "nickname", "desc", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Restart", "", "desc", GH_ParamAccess.item);
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
            List<double> inputGeneSequence = new List<double>();

            //get inputs and validate
            for (int i = 0; i < Params.Input.Count; i++)
            {
                if(!DA.GetDataList(i, inputGeneSequence)) { return; }
                if (inputGeneSequence.Count < 3) { return; }
                if (inputGeneSequence[0] >= inputGeneSequence[1]) { return; }
                if (inputGeneSequence[0] + inputGeneSequence[2] >= inputGeneSequence[1]) { return; }

                if (this.m_iteration == 1)
                {
                    //if first run do x
                    double[,] geneMatrix = new double[Params.Input.Count, 3];
                    //max 
                    geneMatrix[i, 0] = inputGeneSequence[0];

                    //min
                    geneMatrix[i, 1] = inputGeneSequence[1];

                    //halfway (max minus difference between max and mix)
                    geneMatrix[i, 2] = inputGeneSequence[1] - (0.5 * (inputGeneSequence[1] - inputGeneSequence[0]));

                }
                else if (this.m_iteration == 2)
                {
                    //if second run, do y


                }
                else
                {
                    //if third run or more, do something else


                }





            }

            this.m_iteration++;


            


            


            




            //set outputs

        }




        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }


        public override Guid ComponentGuid
        {
            get { return new Guid("0be85b63-f621-4414-b1cc-b839c6023944"); }
        }
    }
}