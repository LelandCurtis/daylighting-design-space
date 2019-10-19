using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace daylighting_design_space
{
    public class ddsInfo : GH_AssemblyInfo
  {
    public override string Name
    {
        get
        {
            return "daylightingdesignspace";
        }
    }
    public override Bitmap Icon
    {
        get
        {
            //Return a 24x24 pixel bitmap to represent this GHA library.
            return null;
        }
    }
    public override string Description
    {
        get
        {
            //Return a short string describing the purpose of this GHA library.
            return "";
        }
    }
    public override Guid Id
    {
        get
        {
            return new Guid("2d8eca95-7351-46ba-89d7-e97af7499a1e");
        }
    }

    public override string AuthorName
    {
        get
        {
            //Return a string identifying you or your company.
            return "";
        }
    }
    public override string AuthorContact
    {
        get
        {
            //Return a string representing your preferred contact details.
            return "";
        }
    }
}
}
