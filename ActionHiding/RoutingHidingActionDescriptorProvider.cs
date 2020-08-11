using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using ActionHiding.Attributes;

namespace ActionHiding
{
    public class RoutingHidingActionDescriptorProvider : IActionDescriptorProvider
    {
        public int Order => -900;

        public void OnProvidersExecuted(ActionDescriptorProviderContext context)
        {
            var stringSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var result in context.Results)
            {
                foreach (var routeValuesKey in result.RouteValues.Keys)
                {
                    stringSet.Add(routeValuesKey);
                }
            }
            foreach (var result in context.Results)
            {
                foreach (var key in stringSet)
                {
                    if (!result.RouteValues.ContainsKey(key))
                        result.RouteValues.Add(key, null);
                }
            }
        }

        public void OnProvidersExecuting(ActionDescriptorProviderContext context)
        {
            var removeActionDescriptorList = new List<ActionDescriptor>();
            foreach (var actionDescriptor in context.Results)
            {
                if (actionDescriptor.EndpointMetadata.Any(e => e.GetType() == typeof(RoutingHidingAttribute)))
                {
                    removeActionDescriptorList.Add(actionDescriptor);
                }
            }
            removeActionDescriptorList.ForEach(p =>
            {
                if (context.Results.Contains(p))
                    context.Results.Remove(p);
            });
        }
    }
}
