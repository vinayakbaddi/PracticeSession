using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConsoleApplication.XML
{
    public class XmlManipulation
    {
        public static void run()
        {
            //another();
            //t2();
            //xn();
            overlay2();
        }

        private static void overlay2()
        {
            XDocument sourceDoc = XDocument.Load(@"C:\Users\vinay\source\repos\PracticeSession\ConsoleApplication\XML\data\x1.xml");
            XDocument updateDoc = XDocument.Load(@"C:\Users\vinay\source\repos\PracticeSession\ConsoleApplication\XML\data\x2.xml");
            XDocument master = XDocument.Load(@"C:\Users\vinay\source\repos\PracticeSession\ConsoleApplication\XML\data\x1.xml");

            var rootElements = sourceDoc.Root.Elements().Select(s => s.Attribute("name").Value);
            var d= updateDoc.Root.Elements().Where(c => !rootElements.Contains(c.Attribute("name").Value));

            //var df = updateDoc.Root.Elements().Where(c => !sourceDoc.Root.Elements().Any(s => s.Attribute("name")));
            //var s = updateDoc.Root.Descendants().Where(d => updateElements.Any(u => u.Attribute("name").Value.Equals(d.Attribute("name"))));
            //foreach (var element in s)
            //{

            //    //var matchingUpdateElement = updateElements.Where(e=> e.Attribute("name").Value.Equals(element.Attribute("name").Value, StringComparison.InvariantCultureIgnoreCase));

            //    //if (matchingUpdateElement != null && matchingUpdateElement.Count() > 0)
            //    //{
            //    //    var m = master.Root.Elements().Where(e => e.Attribute("name").Value.Equals(element.Attribute("name").Value, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            //    //    m.ReplaceWith(matchingUpdateElement);
            //    //    //element.ReplaceWith(matchingUpdateElement);
            //    //}
            //    Console.WriteLine("t");
            //}

            master.Save(@"C:\Users\vinay\source\repos\PracticeSession\ConsoleApplication\XML\data\overlayed.xml");

        }
        private static void overlay()
        {
            XDocument sourceDoc = XDocument.Load(@"C:\Users\vinay\source\repos\PracticeSession\ConsoleApplication\XML\data\x1.xml");
            XDocument updateDoc = XDocument.Load(@"C:\Users\vinay\source\repos\PracticeSession\ConsoleApplication\XML\data\x2.xml");

            var updateElements = updateDoc.Root.Elements().Where(e => e.Attribute("name") != null);
            var s = sourceDoc.Root.Elements().Where(e => e.Attribute("name") != null);
            foreach (var element in sourceDoc.Root.Elements().Where(e => e.Attribute("name") != null))
            {
                var matchingUpdateElement = updateElements.FirstOrDefault(e => e.Attribute("name") == element.Attribute("name"));

                if (matchingUpdateElement != null)
                {
                    element.ReplaceWith(matchingUpdateElement);
                }
            }

            sourceDoc.Save(@"C:\Users\vinay\source\repos\PracticeSession\ConsoleApplication\XML\data\overlayed.xml");

        }

        static void xn()
        {
            XDocument doc = new XDocument();
            var path = $"{Path.GetDirectoryName(typeof(XmlManipulation).Assembly.Location)}/xml/data/nodex.xml";
            
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.CreateReader().NameTable);
            ns.AddNamespace("hd", "http://www.example.com/ns1");
            ns.AddNamespace("xsi", "http://www.example.com/ns2");

            // Use the SelectNodes method to query the document using the XPath expression
            var at1 = doc.XPathSelectElements("/*[@name]", ns);

        }
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

        static void another()
        {
            // Load the XML document
            XmlDocument doc = new XmlDocument();
            var path = $"{Path.GetDirectoryName(typeof(XmlManipulation).Assembly.Location)}/xml/data/XmlFile.xml";
            doc.Load(path);

            // Define the namespace and prefix
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("hd", "http://s.m.com/");
            ns.AddNamespace("xsi", "http://xsi.com/");

            // Use the SelectNodes method to query the document using the XPath expression
            XmlNodeList nodes = doc.SelectNodes("//hd:textAnswer", ns);
            XmlNodeList attr = doc.SelectNodes("//hd:textAnswer/@xsi:nil", ns);
            XmlNodeList at1 = doc.SelectNodes("//hd:textAnswer/hd:value[@xsi:nil]", ns);

            XmlNodeList empty = doc.SelectNodes("//@xsi:nil", ns);
            //XmlNodeList nslist = doc.SelectNodes("*[namespace-uri()='http://xsi.com/' |  @*[namespace-uri()='http://xsi.com/']");
            XmlNodeList nslist = doc.SelectNodes("@*[namespace-uri()='http://xsi.com/']");
            var attributeName = "nil";
            //string xpath = @"//*[@" + attributeName + "]";
            var xpath = "//xsi:nil";
            XmlNodeList xmlNodeList = doc.SelectNodes(xpath,ns);

            // Iterate through the list of nodes
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node.OuterXml);
            }

            foreach (XmlNode node in empty)
            {
                Console.WriteLine("Empty node");
                Console.WriteLine(node.OuterXml);
            }
            Console.ReadLine();
        }
        static void t2()
        {
            XmlDocument doc = new XmlDocument();
            var path = $"{Path.GetDirectoryName(typeof(XmlManipulation).Assembly.Location)}/xml/data/sample.xml";

            doc.Load(path);

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            
            ns.AddNamespace("hd", "http://www.example.com/ns1");
            ns.AddNamespace("xsi", "http://www.example.com/ns2");

            //XmlNodeList nodes = doc.SelectNodes("//@hd:attributeName | //@xsi:nil", ns);
            XmlNodeList nodes = doc.SelectNodes("//@xsi:nil/../..", ns);

            XmlNode nodes1 = doc.SelectSingleNode("//@xsi:nil", ns);
            XmlNode nodes2 = doc.SelectSingleNode("//@xsi:nil/../..", ns);
            XmlNode nodes3 = doc.SelectSingleNode("//@xsi:nil/../hd:textAnswer", ns);

            XmlNodeList rt = doc.SelectNodes("//@xsi:nil/../ancestor::hd:textAnswer", ns);
            //XmlNodeList rt = doc.SelectNodes("//@xsi:nil/../ancestor::hd:[ends_with(answer)]", ns);

            Console.WriteLine("Selected attribute names with namespaces:");
            foreach (XmlNode node in rt)
            {
                Console.WriteLine(node.Name);
                
                Console.WriteLine(node.Attributes["name"].Value);
            }
        }

        void ttt(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("sample.xml");

            XmlNodeList nodes = doc.SelectNodes("//*[ends-with(name(), 'answer')]");

            foreach (XmlNode node in nodes)
            {
                Console.WriteLine("Element Name: " + node.Name);
                Console.WriteLine("Element Value: " + node.InnerText);
                Console.WriteLine();
            }
        }
}



    namespace XPathExample
    {
        class Program2
        {
            static void t2(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("sample.xml");

                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("ns1", "http://www.example.com/ns1");
                ns.AddNamespace("ns2", "http://www.example.com/ns2");

                XmlNodeList nodes = doc.SelectNodes("//@ns1:attributeName | //@ns2:attributeName", ns);

                Console.WriteLine("Selected attribute names with namespaces:");
                foreach (XmlNode node in nodes)
                {
                    Console.WriteLine(node.Name);
                }
            }
        }
    }
}

namespace XmlMergeExample
{
    class Program22
    {
        static void Main(string[] args)
        {
            XDocument xml1 = XDocument.Load("xml1.xml");
            XDocument xml2 = XDocument.Load("xml2.xml");

            var nodes1 = xml1.Descendants().Where(x => x.Name.LocalName != "root");
            var nodes2 = xml2.Descendants().Where(x => x.Name.LocalName != "root");

            int index = 1;
            foreach (var node1 in nodes1)
            {
                Console.WriteLine("Node 1 Index: " + index);
                Console.WriteLine("Node 1 Data: " + node1.Value);

                if (index <= nodes2.Count())
                {
                    var node2 = nodes2.ElementAt(index - 1);
                    Console.WriteLine("Node 2 Index: " + index);
                    Console.WriteLine("Node 2 Data: " + node2.Value);
                }

                Console.WriteLine();
                index++;
            }
        }
    }
}
