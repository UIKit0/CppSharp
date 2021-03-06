using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Utils;

namespace CppSharp.Tests
{
    public class Basic : GeneratorTest
    {
        public Basic(GeneratorKind kind)
            : base("Basic", kind)
        {

        }

        public override void SetupPasses(Driver driver)
        {
            if (driver.Options.IsCSharpGenerator)
                driver.Options.GenerateAbstractImpls = true;
            driver.Options.GenerateVirtualTables = true;
            driver.Options.MarshalCharAsManagedChar = true;
        }

        public override void Preprocess(Driver driver, ASTContext ctx)
        {
            ctx.SetClassAsValueType("Bar");
            ctx.SetClassAsValueType("Bar2");
            ctx.SetMethodParameterUsage("Hello", "TestPrimitiveOut", 1, ParameterUsage.Out);
            ctx.SetMethodParameterUsage("Hello", "TestPrimitiveOutRef", 1, ParameterUsage.Out);
        }

        public static void Main(string[] args)
        {
            ConsoleDriver.Run(new Basic(GeneratorKind.CLI));
            ConsoleDriver.Run(new Basic(GeneratorKind.CSharp));
        }
    }
}
