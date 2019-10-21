using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConventionsAndConstraints.Infrastructure
{
    using Microsoft.AspNetCore.Mvc.ApplicationModels;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AddActionAttribute : Attribute, IActionModelConvention
    {
        private readonly string additionalName;

        public AddActionAttribute(string name)
        {
            this.additionalName = name;
        }

        public void Apply(ActionModel action)
        {
            action.Controller.Actions.Add(new ActionModel(action) { ActionName = additionalName });
        }
    }
}