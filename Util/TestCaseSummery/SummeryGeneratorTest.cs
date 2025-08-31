using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace SauseLabPomProject.Util.TestCaseSummery
{
    public class SummeryGeneratorTests
    {
        [Test]
        public async Task GenerateSummary_ForGivenMethod_AddsSummary()
        {
            // Find project root by locating the .csproj file
            string projectRoot = TestContext.CurrentContext.WorkDirectory;
            while (!File.Exists(Path.Combine(projectRoot, "SauseLabPomProject.csproj")))
            {
                projectRoot = Directory.GetParent(projectRoot).FullName;
            }

            string filePath = Path.Combine(projectRoot, "Tests", "ProductPageTest", "ProductIsAvailableTest.cs");
            string methodName = "productIsAvailableTest";

            Assert.IsTrue(File.Exists(filePath), $"File not found: {filePath}");

            await SummeryGenerator.GenerateSummaryForMethodAsync(filePath, methodName);

            string code = File.ReadAllText(filePath);
            StringAssert.Contains("<summary>", code, "Summary was not added to the method.");

        }
    }
}