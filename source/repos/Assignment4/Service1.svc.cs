using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Assignment4
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    
    //Movies Data structure for searching service
    class Movies
    {
        public string rating { get; set; }
        public string title { get; set; }
        public string runtime { get; set; }
        public string genre { get; set; }
        public string director { get; set; }
        public string[] directors { get; set; }
        public string high_rated { get; set; }
        public string studio { get; set; }
        public string year { get; set; }
    }

  
    public class Service1 : IService1
    {

        //5.1 Verification service
        public string XmlVerification(string xmlPath, string xsdPath)
        {
            string output = "";

            //Create a new XML schema and assign input schema to it
            XmlSchemaSet sc = new XmlSchemaSet();

            try
            {
                sc.Add("", xsdPath);
            }
            catch (Exception)
            {
                return "Check URL of XSD File";
            }

            //Load our xml file


            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load(xmlPath);
            }
            catch (Exception)
            {
                return "Check URL of XML file";
            }
            //If there are no errors!
            output = "The XML file is valid according to the schema in XSD file";

            //If some errors in xml file then it will be reflected in the string
            xdoc.Validate(sc, (o, e) =>
            {
                output = e.Message;
            });
            return output;
        }

        //5.3 Search Service
        public string searchElement(string xmlPath, string key)
        {
            //Load xml file
            XDocument doc;
            try
            {
                doc = XDocument.Load(xmlPath);
            }
            catch (Exception)
            {
                return "Check the URL for XML file.";
            }
            //Select root element
            XElement movies = doc.Element("Movies");
            Movies[] searchList = null;

            if (movies != null)
            {
                //Select all the movie elements!
                IEnumerable<XElement> movie_element = movies.Elements("Movie");
                
                //Search for the keyword
                searchList = (from itm in movie_element
                            where itm.Element("Title").Value == key || itm.Attribute("rating").Value == key || itm.Element("Genre").Value == key || itm.Element("Studio").Value == key || itm.Element("Year").Value == key || itm.Elements("Director").Select(x => x.Element("Name").Element("First").Value + " " + x.Element("Name").Element("Last").Value).ToArray()[0] == key
                              select new Movies()
                            {
                                rating = itm.Attribute("rating").Value,
                                title = itm.Element("Title").Value,
                                genre = itm.Element("Genre").Value,
                                directors = itm.Elements("Director").Select(x => x.Element("Name").Element("First").Value +" "+ x.Element("Name").Element("Last").Value).ToArray(),
                                studio = itm.Element("Studio").Value,
                                year = itm.Element("Year").Value,
                            }).ToArray<Movies>();
            }

            string output = "";

            //Creating the output in a format.
            foreach (Movies i in searchList)
            {
                output = output + "Movie: " + i.title + "<br/>" + "Rating: " + i.rating + "<br/>" + "Genre: " + i.genre + "<br/>";
                output = output + "Directors: ";
                for (int j = 0; j<i.directors.Length;j++)
                {
                    string s = i.directors[j];
                    output = output + s;
                    if (j < i.directors.Length - 1)
                        output = output + ", ";
                }
                output = output + "<br/>";
                output = output + "Studio: " + i.studio + "<br/>" + "Year: " + i.year + "<br/><br/>";

            }
            return output;
        }
    }
}
