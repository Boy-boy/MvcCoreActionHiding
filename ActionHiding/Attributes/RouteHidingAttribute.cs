using System;

namespace ActionHiding.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class RouteHidingAttribute : Attribute
    {
    }
}
