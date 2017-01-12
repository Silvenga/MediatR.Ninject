# MediatR.Ninject
Ninject configuration helper for MediatR. 

[![Build status](https://img.shields.io/appveyor/ci/Silvenga/mediatr-ninject.svg?maxAge=86400&style=flat-square)](https://ci.appveyor.com/project/Silvenga/mediatr-ninject)
[![Nuget Package](https://img.shields.io/nuget/v/MediatR.Ninject.svg?maxAge=86400&style=flat-square)](https://www.nuget.org/packages/MediatR.Ninject/)
[![License](https://img.shields.io/github/license/silvenga/MediatR.Ninject.svg?maxAge=86400&style=flat-square)](https://github.com/Silvenga/MediatR.Ninject/blob/master/LICENSE)

```
Install-Package MediatR.Ninject
```

Example usage:

```csharp
// using MediatR;
// using MediatR.Ninject;
// using Ninject;
// ...

// Bind required services.
IKernel kernel = new StandardKernel();
kernel.BindMediatR();

// That's it! Make sure to bind the handlers as needed.
kernel.Bind<ExampleAsyncRequestHandler>.To<IAsyncRequestHandler<,>>;
```