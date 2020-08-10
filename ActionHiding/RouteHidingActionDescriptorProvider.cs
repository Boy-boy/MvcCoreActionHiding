using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using ActionHiding.Attributes;

namespace ActionHiding
{
    public class RouteHidingActionDescriptorProvider : IActionDescriptorProvider
    {
        public int Order => -900;

        public void OnProvidersExecuted(ActionDescriptorProviderContext context)
        {
            HashSet<string> stringSet = new HashSet<string>((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase);
            for (int index = 0; index < context.Results.Count; ++index)
            {
                foreach (string key in (IEnumerable<string>)context.Results[index].RouteValues.Keys)
                    stringSet.Add(key);
            }
            for (int index = 0; index < context.Results.Count; ++index)
            {
                ActionDescriptor result = context.Results[index];
                foreach (string key in stringSet)
                {
                    if (!result.RouteValues.ContainsKey(key))
                        result.RouteValues.Add(key, (string)null);
                }
            }
        }

        public void OnProvidersExecuting(ActionDescriptorProviderContext context)
        {
            var removeActionDescriptorList = new List<ActionDescriptor>();
            foreach (var actionDescriptor in context.Results)
            {
                if (actionDescriptor.EndpointMetadata.Any(e => e.GetType() == typeof(RouteHidingAttribute)))
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
