using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OrderInfo.Core.Extentions
{
    public static class ModelStateExtentions
    {

        public static IEnumerable<ModelErrorCollection> GetErrorMessage(this ModelStateDictionary model)
        {
            return model.Select(x => x.Value.Errors)
                             .Where(y => y.Count > 0)
                             .ToList();
        }

    }
}
