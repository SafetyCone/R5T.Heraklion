using System;


namespace R5T.Heraklion.Extensions
{
    public static class FinishedContextExtensions
    {
        public static string Finish(this ICommandBuilderContext<FinishedContext> finishedContext)
        {
            var command = finishedContext.BuildCommand();
            return command;
        }
    }
}
