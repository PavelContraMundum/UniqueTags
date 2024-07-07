using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;


class Program
{
    static void Main(string[] args)
    {
        string xmlFilePath = "D:\\Downloads\\Studijni Bible\\Studijni_Bible\\GenMod.xml";
        string outputFilePath = "D:\\Downloads\\unikatni_tagy.txt";

        
        XDocument xdoc = XDocument.Load(xmlFilePath);

        
        HashSet<string> uniqueTags = new HashSet<string>();

       
        CollectUniqueTags(xdoc.Root, uniqueTags);

        
        File.WriteAllLines(outputFilePath, uniqueTags.OrderBy(tag => tag));

        Console.WriteLine("Unikátní tagy byly uloženy do souboru: " + outputFilePath);
    }

    // Rekurzivní metoda pro procházení XML elementů
    static void CollectUniqueTags(XElement element, HashSet<string> uniqueTags)
    {
        if (element == null)
            return;


        if (element.IsEmpty)
        {
            uniqueTags.Add($"<{element.Name.LocalName}/>");
        }
        else
        {
            uniqueTags.Add($"<{element.Name.LocalName}>");
            uniqueTags.Add($"</{element.Name.LocalName}>");
        }

        // Procházení všech potomků
        foreach (XElement child in element.Elements())
        {
            CollectUniqueTags(child, uniqueTags);
        }
    }
}