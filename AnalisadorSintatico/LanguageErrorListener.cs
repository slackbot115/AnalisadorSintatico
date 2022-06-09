using System.IO;
using Antlr4.Runtime;

namespace AnalisadorSintatico
{
    public class LanguageErrorListener : BaseErrorListener
    {
        public string Symbol { get; private set; }
        public StringWriter Writer { get; private set; }

        public LanguageErrorListener(StringWriter writer)
        {
            Writer = writer;
        }

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            Writer.WriteLine(msg);

            Symbol = offendingSymbol.Text;
        }
    }
}