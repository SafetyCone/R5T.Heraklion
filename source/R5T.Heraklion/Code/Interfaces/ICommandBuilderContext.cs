using System;

using R5T.Piraeus;


namespace R5T.Heraklion
{
    public interface ICommandBuilderContext
    {
        ICommandBuilder CommandBuilder { get; }
    }


    public interface ICommandBuilderContext<TContext> : ICommandBuilderContext
    {
        ICommandBuilderContext<TNewContext> ChangeContext<TNewContext>();
    }
}
