# Windsor.Extension
<img align="right" src="Resource/Images/Logo.Purple.128.png">
Windsor.Extension is an extension library for open source container [Castle Windsor](http://www.castleproject.org/projects/windsor/). Library solves frequently needed features of this container.

Some of the features that provided in this libary is
  - Decoration pattern registration - Simple, chained, and type-safe  (Both for Component and BasedOnDescriptor)
  - ResolveByParameterName in construction (without explicit registration)
  - AppSettings Convention
  - Static access  for ExtenionMethod classes

[Sample codes](https://github.com/onureker/Windsor.Extension/tree/master/Source/Demos/Windsor.Extension.Demo) are included in repostory

[![Build Status](https://ci.appveyor.com/api/projects/status/github/onureker/Windsor.Extension?branch=master&svg=true)](https://ci.appveyor.com/project/OnurEker/windsor-extension)

## Features
### Decoration Pattern Registration
This feature is the one the most needed feature in registration. However there are some tricks to cover this feature, it is too confusing and complex.
Extension library solves this need by simple extension methods. Extension methods handles type-safety and decoration order 
```csharp
Component
    .For<IMathService>()
    .ImplementedBy<DefaultMathService>()
    .Decorated().By<LogDecorator>()
    .Decorated().By<ExceptionDecorator>()
```
Also it supports BasedOnDescriptor
TODO

### ResolveByParameterName
This feature is the one the most needed feature in registration too. However there is a legal way registration with DependencyKey. It is hard to re-factor and register.
Extension library solves this need just by adding ResolveByNameConvention resolver.
```csharp
container.Kernel.Resolver.AddSubResolver(new ResolveByNameConvention(container));
```
And register with name
```csharp
Component
    .For<ILogger>()
    .ImplementedBy<ConsoleLogger>()
    .Named("consoleLogger")
    .IsDefault(),

Component
    .For<ILogger>()
    .ImplementedBy<TraceLogger>()
    .Named("traceLogger")
```
Or call "NamedAsParameter" extension method
```csharp
Classes
    .FromAssemblyInThisApplication()
    .BasedOn(typeof(ILogger))
    .WithService
    .FromInterface()
    .NamedAsParameter()
    .DefaultIs(typeof(TraceLogger))
```
That's it. Now you can own them in constructor with constructor parameter name
```csharp
public ResolveByNameDemo(ILogger logger, ILogger consoleLogger, ILogger traceLogger)
{
    this.logger = logger;
    this.consoleLogger = consoleLogger;
    this.traceLogger = traceLogger;
}
```

## Releases
See the [releases](https://github.com/onureker/Windsor.Extension/releases).

## License
Windsor Extension is licensed under the [Apache 2.0](http://opensource.org/licenses/Apache-2.0) license. Refer to LICENSE for more information

Icons made by [Freepik](http://www.freepik.com") from [Flaticon](http://www.flaticon.com) is licensed by [Creative Commons BY 3.0](http://creativecommons.org/licenses/by/3.0/)
