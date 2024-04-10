using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CMDGameEngine.Objects.VisualMap;

// Class for XML parsing, loading, editing etd.

namespace CMDGameEngine
{
    public static class XMLOperations
    {
        //Exceptions
        public class XMLObjectElementIsNull : Exception
        {
            public XMLObjectElementIsNull(string message) : base(message) { }
        }

        public class XMLObjectElementIsLongerThanOneCharacter : Exception
        {
            public XMLObjectElementIsLongerThanOneCharacter(string message) : base(message) { }
        }

        public class StringIsNotAXML : Exception
        {
            public StringIsNotAXML(string message) : base(message) { }
        }


        public static List<VisualElement>? GetVisualElementsFromXML(string? xmlDoc)
        {
            if (xmlDoc != null)
            {
                List<VisualElement> visualElements = new List<VisualElement> ();

                if (IsFileXML(xmlDoc) == false)
                {
                    throw new StringIsNotAXML("File path points to a file that is not xml.");
                }

                XDocument doc = XDocument.Load(xmlDoc);

                var elementsFromXML = from element in doc.Descendants("element")
                                      select new
                                      {
                                          X = (string)element.Attribute("x").Value,
                                          Y = (string)element.Attribute("y").Value,
                                          Sign = (string)element.Attribute("sign").Value
                                      };

                foreach (var element in elementsFromXML)
                {
                    string name;
                    int x, y;
                    char sign;

                    if (element.X == null || element.Y == null || element.Sign == null)
                    {
                        throw new XMLObjectElementIsNull("XML object value is null.");
                    }

                    if (int.TryParse(element.X, out int xValue)) x = xValue;
                    else throw new XMLObjectElementIsNull("XML object X value is not a int.");

                    if (int.TryParse(element.Y, out int yValue)) y = yValue;
                    else throw new XMLObjectElementIsNull("XML object Y value is not a int.");

                    if (element.Sign.Length == 1) sign = element.Sign[0];
                    else throw new Exception("XML object Sign value is longer then one character.");

                    VisualElement elementObj = new VisualElement(x, y, sign);
                    visualElements.Add(elementObj);
                }

                return visualElements;
            }

            return null;
        }
        public static bool IsStringXML(string xmlString)
        {
            try
            {
                XDocument.Parse(xmlString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsFileXML(string filePath)
        {
            try
            {
                XDocument.Load(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
