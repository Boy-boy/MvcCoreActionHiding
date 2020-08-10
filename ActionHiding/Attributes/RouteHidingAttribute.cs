using System;

namespace ActionHiding.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RouteHidingAttribute : Attribute
    {
    }
}
