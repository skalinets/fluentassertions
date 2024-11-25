---
title: Extensibility
permalink: /extensibility/
toc: true
layout: single
sidebar:
  nav: "sidebar"
---

To facilitate the need for those developers which ideas don't end up in the library, Fluent Assertions offers several extension points. They are there so that they can build their own extensions with the same consistent API and behavior people are used to. And if they feel the need to alter the behavior of the built-in set of assertion methods, they can use the many hooks offered out of the box. The flip side of all of this is that we cannot just change the internals of FA without considering backwards compatibility. But looking at the many extensions available on the NuGet, it's absolutely worth it.

## Building your own extensions

As an example, let's create an extension method on `DirectoryInfo` like this

```csharp
public static class DirectoryInfoExtensions 
{
    public static DirectoryInfoAssertions Should(this DirectoryInfo instance)
    {
      return new DirectoryInfoAssertions(instance); 
    } 
}
```

It's the returned assertions class that provides the actual assertion methods. You don't need to, but if you sub-class the self-referencing generic class `ReferenceTypeAssertions<TSubject, TSelf>`, you'll already get methods like `BeNull`, `BeSameAs` and `Match` for free. Assuming you did, and you provided an override of the `Identifier` property so that these methods know that we're dealing with a directory, it's time for the the next step. Let's add an extension that allows you to assert that the involved directory contains a particular file.

```csharp
public class DirectoryInfoAssertions : 
    ReferenceTypeAssertions<DirectoryInfo, DirectoryInfoAssertions>
{
    public DirectoryInfoAssertions(DirectoryInfo instance)
        : base(instance)
    {
    }

    protected override string Identifier => "directory";

    [CustomAssertion]
    public AndConstraint<DirectoryInfoAssertions> ContainFile(
        string filename, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(!string.IsNullOrEmpty(filename))
            .FailWith("You can't assert a file exist if you don't pass a proper name")
            .Then
            .Given(() => Subject.GetFiles())
            .ForCondition(files => files.Any(fileInfo => fileInfo.Name.Equals(filename)))
            .FailWith("Expected {context:directory} to contain {0}{reason}, but found {1}.", 
                _ => filename, files => files.Select(file => file.Name));

        return new AndConstraint<DirectoryInfoAssertions>(this);
    }
}
```

This is quite an elaborate example which shows some of the more advanced extensibility features. Let me highlight some things:

* The `Subject` property is used to give the base-class extensions access to the current `DirectoryInfo` object.
* `[CustomAssertion]` attribute enables correct subject identification, allowing Fluent Assertions to render more meaningful test fail messages
* `Execute.Assertion` is the point of entrance into the internal fluent assertion API.
* The optional `because` parameter can contain `string.Format` style place holders which will be filled using the values provided to the `becauseArgs`. They can be used by the caller to provide a reason why the assertion should succeed. By passing those into the `BecauseOf` method, you can refer to the expanded result using the `{reason}` tag in the `FailWith` method.
* The `Then` property is just there to chain multiple assertions together. You can have more than one.
* The `Given` method allows you to perform a lazily evaluated projection on whatever you want. In this case I use it to get a list of `FileInfo` objects from the current directory. Notice that the resulting expression is not evaluated until the final call to `FailWith`.
* `FailWith` will evaluate the condition, and raise the appropriate exception specific for the detected test framework. It again can contain numbered placeholders as well as the special named placeholders `{context}` and `{reason}`. I'll explain the former in a minute, but suffice to say that it displays the text "directory" at that point. The remainder of the place holders will be filled by applying the appropriate type-specific value formatter for the provided arguments. If those arguments involve a non-primitive type such as a collection or complex type, the formatters will use recursion to always use the appropriate formatter.
* Since we used the `Given` construct to create a projection, the parameters of `FailWith` are formed by a `params` array of `Func<T, object>` that give you access to the projection (such as the `FileInfo[]` in this particular case). But normally, it's just a `params array` of objects.

## Scoping your extensions

Now what if you want to reuse your newly created extension method within some other extension method? For instance, what if you want to apply that assertion on a collection of directories? Wouldn't it be cool if you can tell your extension method about the current directory? This is where the `AssertionScope` comes into place.

```csharp
public AndConstraint<DirectoryInfoAssertions> ContainFileInAllSubdirectories(
    string filename, string because, params object[] becauseArgs)
{
    foreach (DirectoryInfo subDirectory in Subject.GetDirectories())
    {
        using (new AssertionScope(subDirectory.FullName))
        {
            subDirectory.Should().ContainFile(filename, because, becauseArgs);
        }
    }

    return new AndConstraint<DirectoryInfoAssertions>(this);
}
```

Whatever you pass into its constructor will be used to overwrite the default `{context}` passed to `FailWith`.

```csharp
    .FailWith("Expected {context:directory} to contain {0}{reason}, but found {1}.",
```

So in this case, our nicely created `ContainFile` extension method will display the directory that it used to assert that file existed. You can do a lot more advanced stuff if you want. Just check out the code that is used by the structural equivalency API.

## Rendering objects with beauty

Whenever Fluent Assertions raises an assertion exception, it will use value formatters to render a display representation of an object. Notice that these things are supposed to do more than just calling `Format`. A good formatter will include the relevant parts and hide the irrelevant parts. For instance, the `DateTimeOffsetValueFormatter` is there to give you a nice human-readable representation of a date and time with offset. It will only show the parts of that value that have non-default values. Check out the [specs](https://github.com/fluentassertions/fluentassertions/blob/master/Tests/FluentAssertions.Specs/Formatting/FormatterSpecs.cs) to see some examples of that.

You can hook-up your own formatters in several ways, for example by calling the static method `FluentAssertions.Formatting.Formatter.AddFormatter(IValueFormatter)`. But what does it mean to build your own? Well, a value formatter just needs to implement the two methods `IValueFormatter` declares. First, it needs to tell FA whether your formatter can handle a certain type by implementing the well-named method `CanHandle(object)`. The other one is there to, no surprises here, render it to a string.

```csharp
void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild);
```

Next to the actual value that needs rendering, this method accepts a couple of parameters worth mentioning.

* `formattedGraph` is the object that collects the textual representation of the entire graph. It supports adding fragments of text, full lines and deals with automatic indentation using its `WithIndentation` method. It also protects the performance of the rendering by throwing a `MaxLinesExceededException` when the textual representation has exceeded the configured maximum.  
* `context.UseLineBreaks` denotes that the value should be prefixed by a newline. It is used by some assertion code to force displaying the various elements of the failure message on a separate line.
* `formatChild` is used when rendering a complex object that would involve multiple, potentially recursive, nested calls through `Formatter`.

This is what an implementation for the `DirectoryInfo` would look like.

```csharp
public class DirectoryInfoValueFormatter : IValueFormatter
{
    public bool CanHandle(object value)
    {
        return value is DirectoryInfo;
    }

    void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
    {
        var info = (DirectoryInfo)value;
        string result = $"{info.FullName} ({info.GetFiles().Length} files, {info.GetDirectories().Length} directories)";

        if (context.UseLineBreaks)
        {
            // Forces the result to be added as a separate line in the final output
            formattedGraph.AddLine(result);
        }
        else
        {
            // Appends the result to any existing fragments on the current line
            formattedGraph.AddFragment(result);
        }
    }
}
```

Say you want to customize the formatting of your `CustomClass` type to:

* Increase the indentation from the default 3 to 8,
* Exclude all `string` members and
* Exclude the namespace of the type.

An easy way to achieve this is by extending the `DefaultValueFormatter`.

```csharp
class CustomClassFormatter : DefaultValueFormatter
{
    protected override int SpacesPerIndentionLevel => 8;

    public override bool CanHandle(object value) => value is CustomClass;

    protected override MemberInfo[] GetMembers(Type type) =>
        base.GetMembers(type).Where(e => e.GetUnderlyingType() != typeof(string));

    protected override string TypeDisplayName(Type type) => type.Name;
}
```

Per default the first 32 items are included when formatting an enumerable.
That might be too many or too few depending on your data.
To create a formatter that only prints out the first 5 items, when formatting an `IEnumerable<CustomClass>` you can extend the `EnumerableValueFormatter`.

```csharp
class EnumerableCustomClassFormatter : EnumerableValueFormatter
{
    protected override int MaxItems => 5;

    public override bool CanHandle(object value) => value is IEnumerable<CustomClass>;
}
```

## To be or not to be a value type

The structural equivalency API provided by `Should().BeEquivalentTo` and is arguably the most powerful, but also the most complicated part of Fluent Assertions. And to make things worse, you can extend and adapt the default behavior quite extensively.

For instance, to determine whether FA needs to recursive into a complex object, it needs to know whether or not a particular type has value semantics. An object that has properties isn't necessarily a complex type that you want to recurse on. `DirectoryInfo` has properties, but you don't want FA to just traverse its properties. So you need to tell what types should be treated as value types.

The default behavior is to treat every type that overrides `Object.Equals` as on object that was designed to have value semantics. Unfortunately, anonymous types and tuples also override this method, but because we tend to use them quite often in equivalency comparison, we always compare them by their properties.

You can easily override this by using the `ComparingByValue<T>` options for individual assertion, or to do the same using the global options:

```csharp
AssertionOptions.AssertEquivalencyUsing(options => options
    .ComparingByValue<DirectoryInfo>());
```

Similarly, you can force comparing objects that do override `Equals` by their properties using `ComparingByMembers<T>`.
This also works for open types, so if all concrete types of your `Option<T>` should be compared be their members you just call `ComparingByMembers(typeof(Option<>))`.
Primitive types are never compared by their members and trying to call e.g. `ComparingByMembers<int>` will throw an `InvalidOperationException`.

## Equivalency assertion step by step

The entire structural equivalency API is built around the concept of a plan containing equivalency steps that are run in a predefined order. Each step is an implementation of the `IEquivalencyStep` which exposes a single method `Handle`. You can pass your own implementation to a particular assertion call by passing it into the `Using` method (which puts it behind the final default step) or directly tweak the global `AssertionOptions.EquivalencyPlan`. Checkout the underlying `EquivalencyPlan` to see how it relates your custom step to the other steps. That said, the `Handle` method has the following signature:

```csharp
EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IEquivalencyValidator nestedValidator);
```

It provides you with a couple of parameters. The `comparands` gives you access to the subject-under-test and the expectation. The `context` provides some additional information such as where you are in a deeply nested structure (the `CurrentNode`), or the effective configuration that should apply to the current assertion call (the `Options`). The `nestedValidator` allows you to perform nested assertions like the `StructuralEqualityEquivalencyStep` is doing. Using this knowledge, the simplest built-in step looks like this:

```csharp
public class SimpleEqualityEquivalencyStep : IEquivalencyStep
{
    public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IEquivalencyValidator nestedValidator)
    {
        if (!context.Options.IsRecursive && !context.CurrentNode.IsRoot)
        {
            comparands.Subject.Should().Be(comparands.Expectation, context.Reason.FormattedMessage, context.Reason.Arguments);

            return EquivalencyResult.AssertionCompleted;
        }

        return EquivalencyResult.ContinueWithNext;
    }
}
```

Since `Should().Be()` internally uses the `{context}` placeholder I discussed at the beginning of this article and the encompassing `EquivalencyValidator` will use the `AssertionScope` to set-up the right context, you'll get crystal-clear messages when something didn't meet the expectation. This particular extension point is pretty flexible, but the many options `Should().BeEquivalentTo` provides out-of-the-box probably means you don't need to use it.

## About selection, matching and ordering

Next to tuning the value type evaluation and changing the internal execution plan of the equivalency API, there are a couple of more specific extension methods. They are internally used by some of the methods provided by the `options` parameter, but you can add your own by calling the appropriate overloads of the `Using` methods. You can even do this globally by using the static `AssertionOptions.AssertEquivalencyUsing` method.

The interface `IMemberSelectionRule` defines an abstraction that defines what members (fields and properties) of the subject need to be included in the equivalency assertion operation. The main in-out parameter is a collection of `IMember` objects representing the fields and properties that need to be included. However, if your selection rule needs to start from scratch, you should override `IncludesMembers` and return `false`. As an example, the `AllPublicPropertiesSelectionRule` looks like this:

```csharp
internal class AllPublicPropertiesSelectionRule : IMemberSelectionRule
{
    public bool IncludesMembers => false;

    public IEnumerable<IMember> SelectMembers(INode currentNode 
        IEnumerable<IMember> selectedMembers, MemberSelectionContext context)
    {
            IEnumerable<IMember> selectedNonPrivateProperties = context.Type
                .GetNonPrivateProperties()
                .Select(info => new Property(info, currentNode));

        return selectedMembers.Union(selectedNonPrivateProperties).ToList();
    }

    public override string ToString()
    {
        return "Include all non-private properties";
    }
}
```

Notice the override of `ToString`. The output of that is included in the message in case the assertion fails. It'll help the developer understand the 'rules' that were applied to the assertion.

Another interface, `IMemberMatchingRule`, is used to map a member of the subject to the member of the expectation object with which it should be compared with. It's not something you likely need to implement, but if you do, checkout the built-in implementations `MustMatchByNameRule` and `TryMatchByNameRule`. It receives a `IMember` of the subject's property, the expectation to which you need to map a property, the dotted path to it and the configuration object uses everywhere.

The final interface, the `IOrderingRule`, is used to determine whether FA should be strict about the order of items in collections. The `ByteArrayOrderingRule` is the one used by default, will ensure that FA isn't strict about the order, unless it involves a `byte[]`. The reason behind that is when ordering is treated as irrelevant, FA needs to compare every item in the one collection with every item in the other collection. Each of these comparisons might involve a recursive and nested comparison on the object graph represented by the item. This proved to cause a performance issue with large byte arrays. So I figured that byte arrays are generally used for raw data where ordering is important.

## Thread Safety

The classes `AssertionOptions` and `Formatter` control the global configuration by having static state, so one must be careful when they are mutated. 
They are both designed to be configured from a single setup point in your test project and not from within individual unit tests. 
Not following this could change the outcome of tests depending on the order they are run in or throw unexpected exceptions when run parallel.

In order to ensure they are configured exactly once, a test framework specific solution might be required depending on the version of .NET you are using.

### .NET 5+

.NET 5 introduced the [`ModuleInitializerAttribute`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.moduleinitializerattribute) which can be used to setup the defaults _exactly_ once before any tests are run.

```csharp
internal static class Initializer
{
    [ModuleInitializer]
    public static void SetDefaults()
    {
        AssertionOptions.AssertEquivalencyUsing(
            options => { <configure here> });
    }
}
```

### MSTest

MSTest provides the `AssemblyInitializeAttribute` to annotate that a method in a `TestClass` should be run once per assembly.

```csharp
[TestClass]
public static class TestInitializer
{
    [AssemblyInitialize]
    public static void SetDefaults(TestContext context)
    {
        AssertionOptions.AssertEquivalencyUsing(
            options => { <configure here> });
    }
}
```

### xUnit.net

Create a custom [xUnit.net test framework](https://xunit.net/docs/running-tests-in-parallel#runners-and-test-frameworks) where you configure equivalency assertions.
This class can be shared between multiple test projects using assembly references.

```csharp
namespace MyNamespace
{
    using Xunit.Abstractions;
    using Xunit.Sdk;

    public class MyFramework: XunitTestFramework
    {
        public MyFramework(IMessageSink messageSink)
            : base(messageSink)
        {
            AssertionOptions.AssertEquivalencyUsing(
                options => { <configure here> });
        }
    }
}
```

Add the assembly level attribute so that xUnit.net picks up your custom test framework. This is required for *every* test assembly that should use your custom test framework.

```csharp
[assembly: Xunit.TestFramework("MyNamespace.MyFramework", "MyAssembly.Facts")]
```

Note:

* The `nameof` operator cannot be used to reference the `MyFramework` class. If your global configuration doesn't work, ensure there is no typo in the assembly level attribute declaration and that the assembly containing the `MyFramework` class is referenced by the test assembly and gets copied to the output folder.
* Because you have to add the assembly level attribute per assembly you can define different `AssertionOptions` per test assembly if required.
