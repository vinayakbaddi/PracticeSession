using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Aspose.Words.Replacing;
using Aspose.Words.Drawing;

namespace Aspose.NetF.Word
{
    public class WordImageInsert
    {

        public static void run()
        {
            //InsertImg();
            InsertImgOnNewPage();

        }

        private static void InsertImg()
        {
            Document doc = new Document("./word/files/InsertImg.docx");
            FindReplaceOptions options = new FindReplaceOptions();

            options.Direction = FindReplaceDirection.Forward;
            // Replaces all 'sad' and 'mad' occurrences with 'bad'.
            doc.Range.Replace("Replace", "document text replaced", options);

            var para= doc.Range.Bookmarks.FirstOrDefault().BookmarkStart.ParentNode;
            DocumentBuilder builder = new DocumentBuilder(doc);
            Shape shape = builder.InsertImage(@"C:\Users\vinay\source\repos\PracticeSession\Aspose.NetF\Word\files\image.jpg");
            para.AppendChild(shape);
            var ran = doc.Range;
            // Replaces all 'sad' and 'mad' occurrences with 'bad'.
            //doc.Range.Replace(new Regex("[s|m]ad"), "bad");
            doc.Save("./word/files/replacedDocumentImg.docx");
            Console.WriteLine("Done.");
        }

        private static void InsertImgOnNewPage()
        {
            Document doc = new Document("./word/files/InsertImg.docx");
          
            // Replaces all 'sad' and 'mad' occurrences with 'bad'.
            var para = doc.Range.Bookmarks[1].BookmarkStart.ParentNode;
            
            DocumentBuilder builder = new DocumentBuilder(doc);
            Shape shape = builder.InsertImage(@"C:\Users\vinay\source\repos\PracticeSession\Aspose.NetF\Word\files\image.jpg");
            para.AppendChild(shape);
            //para.In
            //builder.InsertBreak(BreakType.PageBreak);
            //builder.InsertImage(@"C:\Users\vinay\source\repos\PracticeSession\Aspose.NetF\Word\files\image.jpg", 700,700);
            //var ran = doc.Range;
            // Replaces all 'sad' and 'mad' occurrences with 'bad'.
            //doc.Range.Replace(new Regex("[s|m]ad"), "bad");
            doc.Save("./word/files/replacedDocumentImg.docx");
            Console.WriteLine("Done.");
        }
    }
}
