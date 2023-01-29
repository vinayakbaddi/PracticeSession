using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace ConsoleApplication.XML
{
    public class XmlManipulation
    {
        void t()
        {
            // Create an XmlDocument object and load the XML
            XmlDocument doc = new XmlDocument();
            doc.Load("example.xml");

            // Create an XPathNavigator object to navigate the XML
            XPathNavigator nav = doc.CreateNavigator();

            // Define the namespace prefix and URI
            XmlNamespaceManager ns = new XmlNamespaceManager(nav.NameTable);
            ns.AddNamespace("ns", "http://example.com/namespace");

            // Use the XPathNavigator to select the elements we want
            XPathNodeIterator nodes = nav.Select("//ns:elementName", ns);

            // Iterate through the selected elements
            while (nodes.MoveNext())
            {
                Console.WriteLine(nodes.Current.Value);
            }
        }
    }
}
