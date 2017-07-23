using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Client.Utils
{
    public static class PrintUtils
    {
        public static void Print(string title, List<string> content)
        {
            var document = new FlowDocument()
            {
                PagePadding = new System.Windows.Thickness(0),
                PageWidth = 181
            };

            var pTitle = new Paragraph()
            {
                TextAlignment = System.Windows.TextAlignment.Center,
                Margin = new System.Windows.Thickness(5),
                FontSize = 20
            };

            pTitle.Inlines.Add(title);

            document.Blocks.Add(pTitle);

            var pContent = new Paragraph()
            {
                Margin = new System.Windows.Thickness(0),
                FontSize = 18
            };

            foreach (var s in content)
            {
                pContent.Inlines.Add(s);
                pContent.Inlines.Add(new LineBreak());
            }

            document.Blocks.Add(pContent);

            var diag = new PrintDialog();

            diag.PrintDocument((document as IDocumentPaginatorSource).DocumentPaginator, "Caption");
        }
    }
}
