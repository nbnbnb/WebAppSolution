using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4App.Extensions.Validator
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AgeRangeAttribute : RangeAttribute, IClientValidatable
    {
        public AgeRangeAttribute(int minimum, int maximum) : base(minimum, maximum)
        {

        }

        public override bool IsValid(object value)
        {
            DateTime? birthData = value as DateTime?;
            if (null == birthData)
            {
                return true;
            }

            DateTime age = new DateTime(DateTime.Today.Ticks - birthData.Value.Ticks);
            return (int)this.Minimum < age.Year && age.Year <= (int)this.Maximum;
        }

        // 可以重写格式话字符串从而实现自定义的错误信息
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, this.ErrorMessageString, "出生日期", this.Minimum, this.Maximum);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            // 客户段也需要这些信息
            // 用于生成 data- 开头的 html 属性
            // 客户端通过这些值，来实现相同规则的脚本验证

            // 生成的 rule
            // data-val-agerange="字段 年龄 必须在 10 和 30 之间。"  // 同时指定了规则和该规则失败时显示的字符串信息
            // data-val-agerange-maxage="30"  // 规则中的参数值
            // data-val-agerange-minage="10"  // 规则中的参数值
            string errorMessage = FormatErrorMessage("");
            ModelClientValidationRule rule = new ModelClientValidationRule { ValidationType = "agerange", ErrorMessage = errorMessage };
            rule.ValidationParameters.Add("minage", this.Minimum);
            rule.ValidationParameters.Add("maxage", this.Maximum);
            yield return rule;
        }
    }
}