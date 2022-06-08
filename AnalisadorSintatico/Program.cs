using System;
using System.IO;
using AnalisadorSintatico.Content;
using Antlr4.Runtime;

namespace AnalisadorSintatico
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var fileName="Content\\code.txt";
            var fileContents = File.ReadAllText(fileName);
            
            var inputStream = new AntlrInputStream(fileContents);
            
            var languageLexer = new LanguageLexer(inputStream);
            
            var commonTokenStream = new CommonTokenStream(languageLexer);
            
            var languageParser = new LanguageParser(commonTokenStream);

            var languageContext = languageParser.program();

            var visitor = new LanguageVisitor();
            
            //visitor.Visit(languageContext);

            if(languageParser.NumberOfSyntaxErrors == 0)
                Console.WriteLine("Código válido");
            else
            {
                Console.WriteLine("Código inválido");
            }
        }
    }
}