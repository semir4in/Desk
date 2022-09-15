using System.CommandLine;

namespace R4iny.Desk.Cli.ExtensionMethods
{
    public static partial class ExtensionMethod
    {
        public static void AddCommandWithSort(this Command command, IEnumerable<Symbol> symbols)
        {
            foreach (Symbol sym in symbols.OrderBy(x => x.Name))
            {
                if (sym is Command) command.AddCommand(sym as Command);
                else if (sym is Argument) command.AddArgument(sym as Argument);
                else if (sym is Option) command.AddOption(sym as Option);
                else throw new NotImplementedException();
            }
        }
    }
}
