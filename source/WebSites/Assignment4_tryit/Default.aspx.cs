using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Xml_operations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void xmlVerifyBtn_Click(object sender, EventArgs e)
    {
        xmlOperationsService.Service1Client s1 = new xmlOperationsService.Service1Client();

        string xmlfile = "http://www.public.asu.edu/~srpate19/Movies.xml";
        string xsdfile = "http://www.public.asu.edu/~srpate19/Movies.xsd";

        if (xmlFile.Text != "" && xmlFile.Text != " ")
        {
            xmlfile = xmlFile.Text;
        }
        if (xsdFile.Text != "" && xsdFile.Text != " ")
        {
            xsdfile = xsdFile.Text;
        }

        result1.Text = s1.XmlVerification(xmlfile,xsdfile);
    }

    protected void xmlSearchBtn_Click(object sender, EventArgs e)
    {
        xmlOperationsService.Service1Client s2 = new xmlOperationsService.Service1Client();

        string xmlfile = "http://www.public.asu.edu/~srpate19/Movies.xml";
        string keyword1 = "Inside Out";

        if (xmlFile.Text != "" && xmlFile.Text != " ")
        {
            xmlfile = xmlFile.Text;
        }
        if (keyword.Text != "" && keyword.Text != " ")
        {
            keyword1 = keyword.Text;
        }
        result2.Text = s2.searchElement(xmlfile, keyword1);
    }
}