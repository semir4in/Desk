using System.CommandLine;

namespace R4iny.Desk.Cli.Commands
{
    public static class Add
    {
        public static Command GetCommand()
        {
            Command command = new Command(
                name: "add",
                description: "Add entry");



            return command;
        }
    }
}
