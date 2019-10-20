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
    public class Genome
    {
        public int location;
        public double orient;
        public double obstructAng;
        public double width;
        public double depth;
        public double ceilingHeight;
        public double wallThick;
        public double windowBsill;
        public double windowTsill;
        public double spaceBetween;
        public double wwr;
        public double shadeTrig;
        public bool isValid = true;
        public int generation;

        public string ID() {
            return this.ToString();
        }

        public Genome(int location, double orient, double obstructAng, double width, double depth, double ceilingHeight, double wallThick, double windowBsill, double windowTsill, double spaceBetween, double wwr, double shadeTrig)
        {
            this.location = location;
            this.orient = orient;
            this.obstructAng = obstructAng;
            this.width = width;
            this.depth = depth;
            this.ceilingHeight = ceilingHeight;
            this.wallThick = wallThick;
            this.windowBsill = windowBsill;
            this.windowTsill = windowTsill;
            this.spaceBetween =  spaceBetween;
            this.wwr = wwr;
            this.shadeTrig = shadeTrig;
        }

        public Genome()
        {
            this.isValid = false;
        }
        public override string ToString()
        {
            string output = "";
            output += "[" + "location, " + this.location.ToString() + "]";
            output += "[" + "orient, " + this.orient.ToString() + "]";
            output += "[" + "obstructAng, " + this.obstructAng.ToString() + "]";
            output += "[" + "width, " + this.width.ToString() + "]";
            output += "[" + "depth, " + this.depth.ToString() + "]";
            output += "[" + "ceilingHeight, " + this.ceilingHeight.ToString() + "]";
            output += "[" + "wallThick, " + this.wallThick.ToString() + "]"
                + "[" + "windowBsill, " + this.windowBsill.ToString() + "]"
                + "[" + "windowTsill, " + this.windowTsill.ToString() + "]"
                + "[" + "spaceBetween, " + this.spaceBetween.ToString() + "]"
                + "[" + "wwr, " + this.wwr.ToString() + "]"
                + "[" + "shadeTrig, " + this.shadeTrig.ToString() + "]";

            return output;
        }

        public Genome Duplicate()
        {
            return new Genome(this.location,
            this.orient,
            this.obstructAng,
            this.width,
            this.depth,
            this.ceilingHeight,
            this.wallThick,
            this.windowBsill,
            this.windowTsill,
            this.spaceBetween,
            this.wwr,
            this.shadeTrig);
        }

        public bool IsValid()
        {
            return this.isValid;
        }
    }
    public class GenomeGoo : GH_Goo<Genome>
    {

        public GenomeGoo()
        {
            this.Value = new Genome();
        }

        public GenomeGoo(Genome genome)
        {
            if (genome == null)
            {
                this.Value = new Genome();
            }
            else
            {
                this.Value = genome;
            }

        }

        public override IGH_Goo Duplicate()
        {
            return DuplicateGenome();
        }

        public GenomeGoo DuplicateGenome()
        {
            Genome genome;

            if (Value == null)
            {
                genome = new Genome();
            }

            else
            {
                genome = Value.Duplicate();
            }

            return new GenomeGoo(genome);
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
                if (Value == null) { return "No internal Genome instance"; }
                if (Value.IsValid()) { return string.Empty; }
                return "Invalid Genome instance"; //Todo: beef this up to be more informative.
            }
        }

        public override string ToString()
        {
            if (Value == null)
                return "Null type of genome that you shouldnt be seeing anyway... Base class";
            else
                return Value.ToString();
        }

        public override string TypeName
        {
            get { return ("Genome"); }
        }

        public override string TypeDescription
        {
            get { return ("Defines the input parameters, or genes, that define a single unique option, but this is the base class"); }
        }
       


        public override bool CastTo<Q>(ref Q target)
        {

            if (typeof(Q).IsAssignableFrom(typeof(Genome)))
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
            if (typeof(Genome).IsAssignableFrom(source.GetType()))
            {
                Value = (Genome)source;
                return true;
            }

            return false;
        }
    }


    public class GenomeParameter : GH_Param<GenomeGoo>
    {
        public GenomeParameter()
          : base(new GH_InstanceDescription("Genome", "Base class for Genome", "Maintains a collection of genomes", "Occamy", "Panels"))
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
            get { return new Guid("3b9ceca3-7663-4a91-a3a8-8f5ff24b5be1"); }
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
