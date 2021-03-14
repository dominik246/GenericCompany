using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common.Generic
{
    public static class TypeSafeComparison<T> where T : class
    {
        public static string Name<TMember>(Expression<Func<T, TMember>> expression)
        {
            if (expression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException(null, nameof(expression));
        }
    }
}
