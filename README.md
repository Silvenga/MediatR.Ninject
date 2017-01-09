# MediatR.Ninject
Ninject configuration helper for MediatR. 

Example usage:

```csharp
// using MediatR;
// using MediatR.Ninject;
// using Ninject;
// ...

// Bind required services.
IKernel kernel = new StandardKernel();
kernel.BindMediatR();

// Bind the handlers as needed.
kernel.Bind<ExampleAsyncRequest>.To<IAsyncRequestHandler<,>>;
```