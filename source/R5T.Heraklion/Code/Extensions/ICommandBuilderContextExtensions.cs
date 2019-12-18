using System;

using R5T.Magyar;
using R5T.Piraeus.Extensions;


namespace R5T.Heraklion.Extensions
{
    public static class ICommandBuilderContextExtensions
    {
        public static ICommandBuilderContext<TContext> Append<TContext>(this ICommandBuilderContext<TContext> context, string token)
        {
            context.CommandBuilder.Append(token);

            return context;
        }

        /// <summary>
        /// Properly quotes a path token.
        /// Surrounds the provided path with quotes in case of spaces in the path.
        /// </summary>
        public static ICommandBuilderContext<TContext> AppendPath<TContext>(this ICommandBuilderContext<TContext> context, string path)
        {
            context.CommandBuilder.AppendPath(path);

            return context;
        }

        public static ICommandBuilderContext<TContext> AppendQuotedValue<TContext>(this ICommandBuilderContext<TContext> context, string value)
        {
            context.CommandBuilder.AppendQuotedValue(value);

            return context;
        }

        public static ICommandBuilderContext<TContext> AppendNameValuePair<TContext>(this ICommandBuilderContext<TContext> context, string name, string value)
        {
            context.CommandBuilder.AppendNameValuePair(name, value);

            return context;
        }

        public static ICommandBuilderContext<TContext> AppendNamePathValuePair<TContext>(this ICommandBuilderContext<TContext> context, string name, string pathValue)
        {
            context.CommandBuilder.AppendNamePathValuePair(name, pathValue);

            return context;
        }

        public static ICommandBuilderContext<TContext> AppendNameQuotedValuePair<TContext>(this ICommandBuilderContext<TContext> context, string name, string value)
        {
            context.CommandBuilder.AppendNameQuotedValuePair(name, value);

            return context;
        }

        public static string BuildCommand(this ICommandBuilderContext context)
        {
            var command = context.CommandBuilder.BuildCommand();
            return command;
        }

        public static ICommandBuilderContext<TContext> Condition<TContext>(this ICommandBuilderContext<TContext> context, bool condition, Action ifTrue, Action ifFalse)
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

        public static ICommandBuilderContext<TContext> Condition<TContext>(this ICommandBuilderContext<TContext> context, bool condition, Action ifTrue)
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
