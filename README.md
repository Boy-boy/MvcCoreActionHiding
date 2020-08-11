# MvcCoreActionHiding
hiding asp net core action routing

## nuget
### 1.package address https://www.nuget.org/packages/AspNetCore.Mvc.RoutingHiding/
### 2.install package
```
 1.package Manager:Install-Package AspNetCore.Mvc.RoutingHiding -Version 3.1.0
 2..net cli:dotnet add package AspNetCore.Mvc.RoutingHiding --version 3.1.0
```


## 使用方式
### 1.在需要隐藏的控制器或方法上加入特性[RoutingHiding],如下例子：
    [RoutingHiding]
    public class DemoController : ControllerBase
    {
    
    }
```

```
### 2.在Startup的ConfigureServices方法中添加AddRouteHiding(services)，如下例子
```
 services.AddControllersWithViews().AddRoutingHiding(services);
```
