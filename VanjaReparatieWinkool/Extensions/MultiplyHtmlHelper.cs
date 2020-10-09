using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.Extensions
{
    public static class CustomHelper
    {
        public static HtmlString MultiplyFor<TModel, TValue>(this HtmlHelper<TModel> helper,
                                                                    Expression<Func<TModel, TValue>> expression,
                                                                    object HtmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression,
                                                                        helper.ViewData);
            //Type type = metadata.ModelType;
            //string name = ExpressionHelper.GetExpressionText(expression);
            AssignmentModel value = metadata.Model as AssignmentModel;
            IDictionary<string, object> attrs = new RouteValueDictionary(HtmlAttributes);
            string key = "Class";
            object AttributesValue;
            attrs.TryGetValue(key, out AttributesValue);

            if (value.Status.ToString() == "Awaiting" && DateTime.Now >= value.StartDatum)
            {
                return new HtmlString(helper.Encode(String.Format("{0}", AttributesValue)));
            }
            else
            {
                return new HtmlString("");
            }

        }
    }
}