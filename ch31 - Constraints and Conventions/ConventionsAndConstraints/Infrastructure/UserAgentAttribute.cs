using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.DependencyInjection;

namespace ConventionsAndConstraints.Infrastructure
{
    public class UserAgentAttribute : Attribute, IActionConstraintFactory
    {
        private readonly string _sub;

        public UserAgentAttribute(string sub)
        {
            _sub = sub.ToLower();
        }

       
        public IActionConstraint CreateInstance(IServiceProvider services)
        {
            return new UserAgentConstraint(  services.GetRequiredService<UserAgentComparer>(),
                _sub);
        }

        public bool IsReusable  => false;


        private class UserAgentConstraint : IActionConstraint
        {
            private UserAgentComparer comparer;
            private string _sub;

            public UserAgentConstraint(UserAgentComparer comp, string sub)
            {
                comparer = comp;
                _sub = sub.ToLower();
            }

            public bool Accept(ActionConstraintContext context)
            {
                return context.RouteContext.HttpContext
                    .Request.Headers["User-Agent"]
                    .Any(h => h.ToLower().Contains(_sub) || context.Candidates.Count() ==
                    1);
            }

            public int Order { get; } = 0;
        }
    }
}
