using System;
using System.Collections.Generic;
using System.IO;

public enum HtmlEditOption
{
    SetTitle = 1,
    SetHeaderText,
    AddParagraph,
    AddImage,
    SetFooter,
    AddJavaScript,
    AddCss,
    SaveToFile,
    ClearMain,
    Exit
}

public class HtmlPageModel
{
    public string Title { get; set; } = "My Page";
    public string HeaderText { get; set; } = "";
    public string FooterText { get; set; } = "";
    public string Css { get; set; } = "";
    public string JavaScript { get; set; } = "";
    public List<HtmlElement> MainContent { get; set; } = new List<HtmlElement>();
}

public class HtmlElement
{
    public string Type { get; set; }
    public string Id { get; set; }
    public string Content { get; set; }
}

class Program
{
    static HtmlPageModel page = new HtmlPageModel();
    static Dictionary<HtmlEditOption, Action> actions;

    static void Main()
    {
        actions = new Dictionary<HtmlEditOption, Action>
        {
            [HtmlEditOption.SetTitle] = () => {
                Console.Write("Enter title: ");
                page.Title = Console.ReadLine();
            },
            [HtmlEditOption.SetHeaderText] = () => {
                Console.Write("Enter header text: ");
                page.HeaderText = Console.ReadLine();
            },
            [HtmlEditOption.AddParagraph] = () => {
                Console.Write("Enter paragraph ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter paragraph text: ");
                string text = Console.ReadLine();
                page.MainContent.Add(new HtmlElement { Type = "paragraph", Id = id, Content = text });
            },
            [HtmlEditOption.AddImage] = () => {
                Console.Write("Enter image ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter image URL: ");
                string url = Console.ReadLine();
                page.MainContent.Add(new HtmlElement { Type = "image", Id = id, Content = url });
            },
            [HtmlEditOption.SetFooter] = () => {
                Console.Write("Enter footer text: ");
                page.FooterText = Console.ReadLine();
            },
            [HtmlEditOption.AddJavaScript] = () => {
                Console.Write("Enter JavaScript code: ");
                page.JavaScript = Console.ReadLine();
            },
            [HtmlEditOption.AddCss] = () => {
                Console.Write("Enter CSS code: ");
                page.Css = Console.ReadLine();
            },
            [HtmlEditOption.SaveToFile] = () => {
                string html = GenerateHtml();
                File.WriteAllText("page.html", html);
                Console.WriteLine("HTML saved to page.html");
            },
            [HtmlEditOption.ClearMain] = () => {
                page.MainContent.Clear();
                Console.WriteLine("Main section cleared.");
            }
        };

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            foreach (HtmlEditOption option in Enum.GetValues(typeof(HtmlEditOption)))
            {
                Console.WriteLine($"{(int)option}. {option}");
            }

            string input = Console.ReadLine();
            if (Enum.TryParse(input, out HtmlEditOption selected))
            {
                if (selected == HtmlEditOption.Exit) break;

                if (actions.ContainsKey(selected))
                    actions[selected].Invoke();
                else
                    Console.WriteLine("Option not implemented.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            DisplayHtml();
        }
    }

    static void DisplayHtml()
    {
        string html = GenerateHtml();
        Console.WriteLine("\n--- Current HTML Markup ---");
        Console.WriteLine(html);
    }

    static string GenerateHtml()
    {
        var html = new List<string>
        {
            "<!DOCTYPE html>",
            "<html>",
            "<head>",
            $"<title>{page.Title}</title>",
            $"<style>{page.Css}</style>",
            "</head>",
            "<body>",
            $"<header><h1>{page.HeaderText}</h1></header>",
            "<main>"
        };

        foreach (var element in page.MainContent)
        {
            if (element.Type == "paragraph")
                html.Add($"<p id=\"{element.Id}\">{element.Content}</p>");
            else if (element.Type == "image")
                html.Add($"<img id=\"{element.Id}\" src=\"{element.Content}\" alt=\"Image\" />");
        }

        html.Add("</main>");
        html.Add($"<footer>{page.FooterText}</footer>");
        html.Add($"<script>{page.JavaScript}</script>");
        html.Add("</body>");
        html.Add("</html>");

        return string.Join("\n", html);
    }
}
