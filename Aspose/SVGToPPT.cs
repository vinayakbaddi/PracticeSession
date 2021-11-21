using Aspose.Pdf;
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose
{
    public class SVGToPPT
    {
        public static void run()
        {
            convert();
        }

        private static void convert()
        {
            // load SVG file with an instance of Document class
            //Document document = new Document(@"C:\Users\vinay\source\repos\PracticeSession\Aspose\img\stats.svg");
            //// save SVG as a PPTX 
            //document.Save("PptxOutput.pptx", SaveFormat.Pptx);

            using (var p = new Presentation())
            {
                string svgContent = File.ReadAllText(@"C:\Users\vinay\source\repos\PracticeSession\Aspose\img\stats.svg");
                ISvgImage svgImage = new SvgImage(svgContent);
                IPPImage ppImage = p.Images.AddImage(svgImage);
                p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, ppImage.Width, ppImage.Height, ppImage);
                p.Save(@"C:\Users\vinay\source\repos\PracticeSession\Aspose\img\stats", (Slides.Export.SaveFormat)SaveFormat.Pptx);
            }
        }
    }
}
