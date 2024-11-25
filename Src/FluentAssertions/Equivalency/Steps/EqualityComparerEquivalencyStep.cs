using System;
using System.Collections.Generic;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps;

public class EqualityComparerEquivalencyStep<T> : IEquivalencyStep
{
    private readonly IEqualityComparer<T> comparer;

    public EqualityComparerEquivalencyStep(IEqualityComparer<T> comparer)
    {
        this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
    }

    public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context,
        IEquivalencyValidator nestedValidator)
    {
        var expectedType = context.Options.UseRuntimeTyping ? comparands.RuntimeType : comparands.CompileTimeType;

        if (expectedType != typeof(T))
        {
            return EquivalencyResult.ContinueWithNext;
        }

        if (comparands.Subject is null || comparands.Expectation is null)
        {
            // The later check for `comparands.Subject is T` leads to a failure even if the expectation is null.
            return EquivalencyResult.ContinueWithNext;
        }

        Execute.Assertion
            .BecauseOf(context.Reason.FormattedMessage, context.Reason.Arguments)
            .ForCondition(comparands.Subject is T)
            .FailWith("Expected {context:object} to be of type {0}{because}, but found {1}", typeof(T), comparands.Subject)
            .Then
            .Given(() => comparer.Equals((T)comparands.Subject, (T)comparands.Expectation))
            .ForCondition(isEqual => isEqual)
            .FailWith("Expected {context:object} to be equal to {1} according to {0}{because}, but {2} was not.",
                comparer.ToString(), comparands.Expectation, comparands.Subject);

        return EquivalencyResult.AssertionCompleted;
    }

    public override string ToString()
    {
        return $"Use {comparer} for objects of type {typeof(T)}";
    }
}
