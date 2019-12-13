using System;

using R5T.Piraeus;


namespace R5T.Heraklion
{
    public interface ICommandBuilderContext<TContext>
    {
        ICommandBuilder CommandBuilder { get; }


        ICommandBuilderContext<TNewContext> ChangeContext<TNewContext>();
    }
}
