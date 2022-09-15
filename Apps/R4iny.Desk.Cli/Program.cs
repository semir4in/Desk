using R4iny.Desk.Cli.Commands;
using R4iny.Desk.Cli.ExtensionMethods;
using System.CommandLine;

namespace R4iny.Desk.Cli
{
    public class Program
    {
        /// <summary>
        /// r4d
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [STAThread]
        private static int Main(string[] args)
        {
            RootCommand root = new RootCommand(
                "r4d ~ R4iny.Desk: Life logging app for developer and everyone"
                + Environment.NewLine + Environment.NewLine

                + "I made a tool that helps our work into a single app." +
                " I hope this will help you and please let me know if you have any suggestions."

                + Environment.NewLine + " - Commands must be input case-sensitively."
                + Environment.NewLine
                + Environment.NewLine + "To get further infomation or report bugs, please read README.MD or contact us");

            root.AddCommandWithSort(new List<Symbol>()
            {
                Add.GetCommand(),
            });

            return root.InvokeAsync(args).Result;
        }
    }
}
