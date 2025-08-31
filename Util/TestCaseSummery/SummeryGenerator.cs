using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SauseLabPomProject.Util.TestCaseSummery
{
    public class SummeryGenerator
    {

        public static async Task GenerateSummaryForMethodAsync(string filePath, string methodName)
        {
            if (!File.Exists(filePath))
                return;

            var code = File.ReadAllText(filePath);
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();

            var method = root.DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .FirstOrDefault(m => m.Identifier.Text == methodName);

            if (method == null)
                return;

            var hasSummary = method.GetLeadingTrivia()
                .Any(triv => triv.ToString().Contains("<summary>"));

            if (hasSummary)
                return;

            var generator = new AutoSummeryGenerator();
            var summary = await generator.GenerateSummeryAsync(method.ToFullString());

            var summaryTrivia = SyntaxFactory.ParseLeadingTrivia(
                $"/// <summary>\n/// {summary}\n/// </summary>\n"
            );
            var newMethod = method.WithLeadingTrivia(summaryTrivia.AddRange(method.GetLeadingTrivia()));

            var newRoot = root.ReplaceNode(method, newMethod);
            File.WriteAllText(filePath, newRoot.ToFullString());
        }
    }
}

