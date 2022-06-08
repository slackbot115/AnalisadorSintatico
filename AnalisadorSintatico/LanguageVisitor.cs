using System.Collections.Generic;
using AnalisadorSintatico.Content;

namespace AnalisadorSintatico
{
    public class LanguageVisitor : LanguageBaseVisitor<object?>
    {
        private Dictionary<string, object?> Variables { get; } = new();

        public override object? VisitAssignment(LanguageParser.AssignmentContext context)
        {
            var varName = context.ID().GetText();

            var value = Visit(context.expression());
            
            Variables[varName] = value;
            
            return null;
        }
        
    }
}