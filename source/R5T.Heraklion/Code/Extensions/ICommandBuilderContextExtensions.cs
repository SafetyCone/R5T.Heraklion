using System;

using R5T.Magyar;


namespace R5T.Heraklion
{
    public static class ICommandBuilderContextExtensions
    {
        public static string BuildCommand(this ICommandBuilderContext context)
        {
            var command = context.CommandBuilder.BuildCommand();
            return command;
        }

        public static ICommandBuilderContext Condition(this ICommandBuilderContext context, bool condition, Action ifTrue, Action ifFalse)
        {
            if(condition)
            {
                ifTrue();
            }
            else
            {
                ifFalse();
            }

            return context;
        }

        public static ICommandBuilderContext Condition(this ICommandBuilderContext context, bool condition, Action ifTrue)
        {
            context.Condition(condition, ifTrue, ActionHelper.DoNothing);

            return context;
        }

        public static ICommandBuilderContext Condition<TContext>(this ICommandBuilderContext<TContext> context, bool condition, Action<ICommandBuilderContext<TContext>> ifTrue, Action<ICommandBuilderContext<TContext>> ifFalse)
        {
            if (condition)
            {
                ifTrue(context);
            }
            else
            {
                ifFalse(context);
            }

            return context;
        }

        public static ICommandBuilderContext Condition<TContext>(this ICommandBuilderContext<TContext> context, bool condition, Action<ICommandBuilderContext<TContext>> ifTrue)
        {
            context.Condition(condition, ifTrue, ActionHelper.DoNothing);

            return context;
        }
    }
}
