# MvcCoreActionHiding
hiding asp net core action routing

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
