using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper.Kernel.Types;

namespace DaylightingDesignSpace
{
    public class Phenome
    {
        public double sDA100;
        public double sDA200;
        public double sDA300;
        public double sDA500;
        public double sDA2000;
        public double D100;
        public double D200;
        public double D300;
        public double D500;
        public double D2000;
        public double cDA;
        public double UDI;
        public int generation;
        public bool isValid = true;
        public string ID() {
            return this.ToString();
        }

        public Phenome(double sDA100,
                        double sDA200,
                        double sDA300,
                        double sDA500,
                        double sDA2000,
                        double D100,
                        double D200,
                        double D300,
                        double D500,
                        double D2000,
                        double cDA,
                        double UDI)
        {
            this.sDA100 = sDA100;
            this.sDA200 = sDA200;
            this.sDA300 = sDA300;
            this.sDA500 = sDA500;
            this.sDA2000 = sDA2000;
            this.D100 = D100;
            this.D200 = D200;
            this.D300 = D300;
            this.D500 = D500;
            this.D2000 =  D2000;
            this.cDA = cDA;
            this.UDI = UDI;
        }

        public Phenome()
        {
            this.isValid = false;
        }
        public override string ToString()
        {
            string output = "";
            output += "[" + "sDA100, " + this.sDA100.ToString() + "]";
            output += "[" + "sDA200, " + this.sDA200.ToString() + "]";
            output += "[" + "sDA300, " + this.sDA300.ToString() + "]";
            output += "[" + "sDA500, " + this.sDA500.ToString() + "]";
            output += "[" + "sDA2000, " + this.sDA2000.ToString() + "]";
            output += "[" + "D100, " + this.D100.ToString() + "]";
            output += "[" + "D200, " + this.D200.ToString() + "]"
                + "[" + "D300, " + this.D300.ToString() + "]"
                + "[" + "D500, " + this.D500.ToString() + "]"
                + "[" + "D2000, " + this.D2000.ToString() + "]"
                + "[" + "cDA, " + this.cDA.ToString() + "]"
                + "[" + "UDI, " + this.UDI.ToString() + "]";

            return output;
        }

        public Phenome Duplicate()
        {
            return new Phenome(this.sDA100,
            this.sDA200,
            this.sDA300,
            this.sDA500,
            this.sDA2000,
            this.D100,
            this.D200,
            this.D300,
            this.D500,
            this.D2000,
            this.cDA,
            this.UDI);
        }

        public bool IsValid()
        {
            return this.isValid;
        }
    }
    public class PhenomeGoo : GH_Goo<Phenome>
    {

        public PhenomeGoo()
        {
            this.Value = new Phenome();
        }

        public PhenomeGoo(Phenome phenome)
        {
            if (phenome == null)
            {
                this.Value = new Phenome();
            }
            else
            {
                this.Value = phenome;
            }

        }

        public override IGH_Goo Duplicate()
        {
            return DuplicatePhenome();
        }

        public PhenomeGoo DuplicatePhenome()
        {
            Phenome phenome;

            if (Value == null)
            {
                phenome = new Phenome();
            }

            else
            {
                phenome = Value.Duplicate();
            }

            return new PhenomeGoo(phenome);
        }


        
        public override bool IsValid
        {
            get
            {
                if (Value == null) { return false; }
                return Value.IsValid();
            }
        }

        public override string IsValidWhyNot
        {
            get
            {
                if (Value == null) { return "No internal Phenome instance"; }
                if (Value.IsValid()) { return string.Empty; }
                return "Invalid Phenome instance"; //Todo: beef this up to be more informative.
            }
        }

        public override string ToString()
        {
            if (Value == null)
                return "Null type of phenome that you shouldnt be seeing anyway... Base class";
            else
                return Value.ToString();
        }

        public override string TypeName
        {
            get { return ("Phenome"); }
        }

        public override string TypeDescription
        {
            get { return ("Defines the input parameters, or genes, that define a single unique option, but this is the base class"); }
        }
       


        public override bool CastTo<Q>(ref Q target)
        {

            if (typeof(Q).IsAssignableFrom(typeof(Phenome)))
            {
                if (Value == null)
                    target = default(Q);
                else
                    target = (Q)(object)Value;
                return true;
            }
            target = default(Q);
            return false;
        }

        public override bool CastFrom(object source)
        {
            if (source == null) { return false; }

            //Cast from BoatShell
            if (typeof(Phenome).IsAssignableFrom(source.GetType()))
            {
                Value = (Phenome)source;
                return true;
            }

            return false;
        }
    }


    public class PhenomeParameter : GH_Param<PhenomeGoo>
    {
        public PhenomeParameter()
          : base(new GH_InstanceDescription("Phenome", "Base class for Phenome", "Maintains a collection of phenomes", "Occamy", "Panels"))
        {
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null; //Todo, provide an icon.
            }
        }

        public override GH_Exposure Exposure
        {
            get
            {
                // If you want to provide this parameter on the toolbars, use something other than hidden.
                return GH_Exposure.hidden;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("1e7ab52e-5fc5-4718-8b0f-1d29b9da7f4c"); }
        }

       
        public BoundingBox ClippingBox
        {
            get
            {
                return Preview_ComputeClippingBox();
            }
        }
    }
}
