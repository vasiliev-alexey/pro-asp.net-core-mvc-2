using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConventionsAndConstraints.Infrastructure
{
    using Microsoft.AspNetCore.Mvc.ApplicationModels;

    public class ActionNamePrefixAttribute : Attribute, IActionModelConvention
    {
        private readonly string prefix;

        public ActionNamePrefixAttribute(string prefix)
        {
            this.prefix = prefix;
        }

       
        public void Apply(ActionModel action)
        {
            action.ActionName = prefix + action.ActionName;
        }
    }
}
