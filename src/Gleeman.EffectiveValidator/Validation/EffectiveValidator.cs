using Gleeman.EffectiveValidator.CustomAttributes;
using Gleeman.EffectiveValidator.Enums;
using Gleeman.EffectiveValidator.Results;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Gleeman.EffectiveValidator.Validation;

public sealed class EffectiveValidator<T> where T: class
{
    private Type _type { get; }
    private PropertyInfo[] _properties { get; }
    private List<string> _errors { get; }

    public EffectiveValidator()
    {
        _type = typeof(T);
        _errors = new();
        _properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }

    public IValidationResult Validate(T item)
    {

        foreach (PropertyInfo property in _properties)
        {
            if (property.CustomAttributes != null)
            {
                if (property.GetCustomAttribute<CheckRequiredAttribute>() != null)
                {
                    CheckRequired(property, item);
                }
                if (property.PropertyType == typeof(string))
                {
                    if (property.GetCustomAttribute<CheckStringLenghtAttribute>() != null)
                    {
                        CheckStringLenght(property, item);
                    }
                    if (property.GetCustomAttribute<CheckStringEmptyAttribute>() != null)
                    {
                        CheckStringEmpty(property, item);
                    }
                    if (property.GetCustomAttribute<CheckNameAttribute>() != null)
                    {
                        CheckName(property, item);
                    }
                    if (property.GetCustomAttribute<CheckEmailAttribute>() != null)
                    {
                        CheckEmail(property, item);
                    }
                    if (property.GetCustomAttribute<CheckPhoneAttribute>() != null)
                    {
                        CheckPhoneNumber(property, item);
                    }
                    if (property.GetCustomAttribute<CheckZipCodeAttribute>() != null)
                    {
                        CheckZipCode(property, item);
                    }
                    if (property.GetCustomAttribute<CheckCreditCardAttribute>() != null)
                    {
                        CheckCreditCard(property, item);
                    }
                    if (property.GetCustomAttribute<CheckPassportAttribute>() != null)
                    {
                        CheckPassportNumber(property, item);
                    }
                }
                if (property.PropertyType == typeof(int))
                {
                    if (property.GetCustomAttribute<CheckRangeAttribute>() != null)
                    {
                        CheckRange(property, item);
                    }
                }
                if (property.PropertyType == typeof(DateTime))
                {
                    if (property.GetCustomAttribute<CheckDateAttribute>() != null)
                    {
                        CheckDate(property, item);
                    }
                }
            }
        }

        if (_errors.Count > 0) return new ValidationResult(_errors, false);
        return new ValidationResult(null, true);
    }

    void CheckRequired(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckRequiredAttribute>();

        if (attribute != null)
        {
            if (property.GetValue(item) == null)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckStringLenght(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckStringLenghtAttribute>();

        if (attribute != null)
        {
            if (attribute.MinLenght > property.GetValue(item).ToString().Length)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
            if (attribute.MaxLenght < property.GetValue(item).ToString().Length)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }


    }

    void CheckStringEmpty(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckStringEmptyAttribute>();

        if (attribute != null)
        {
            if (property.GetValue(item).ToString() == string.Empty)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckName(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckNameAttribute>();

        if (attribute != null)
        {
            Regex regex = new Regex(@"^[\p{L} \.'\-]+$");
            Match match = regex.Match(property.GetValue(item).ToString());
            if (!match.Success)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckEmail(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckEmailAttribute>();

        if (attribute != null)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            Match match = regex.Match(property.GetValue(item).ToString());
            if (!match.Success)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckZipCode(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckZipCodeAttribute>();

        if (attribute != null)
        {
            Regex regex = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
            Match match = regex.Match(property.GetValue(item).ToString());
            if (!match.Success)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckPhoneNumber(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckPhoneAttribute>();

        if (attribute != null)
        {
            Regex regex = new Regex(@"(\+[0-9]{2}|\+[0-9]{2}\(0\)|\(\+[0-9]{2}\)\(0\)|00[0-9]{2}|0)([0-9]{9}|[0-9\-\s]{9,18})");
            Match match = regex.Match(property.GetValue(item).ToString());
            if (!match.Success)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckCreditCard(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckCreditCardAttribute>();

        if (attribute != null)
        {
            Regex regex = null;
            switch (attribute.CreditCard)
            {
                case CreditCardType.Visa: regex = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$"); break;
                case CreditCardType.Mastercard: regex = new Regex(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"); break;
                case CreditCardType.AmericanExpress: regex = new Regex(@"^3[47][0-9]{13}$"); break;
            }
            Match match = regex.Match(property.GetValue(item).ToString());
            if (!match.Success)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckPassportNumber(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckPassportAttribute>();

        if (attribute != null)
        {
            Regex regex = new Regex(@"^(?!^0+$)[a-zA-Z0-9]{3,20}$");
            Match match = regex.Match(property.GetValue(item).ToString());
            if (!match.Success)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckRange(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckRangeAttribute>();

        if (attribute != null)
        {
            if (attribute.Min > (int)property.GetValue(item))
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
            if (attribute.Max < (int)property.GetValue(item))
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }

    void CheckDate(PropertyInfo property, T item)
    {
        var attribute = property.GetCustomAttribute<CheckDateAttribute>();

        if (attribute != null)
        {
            DateTime startDateAttribute = Convert.ToDateTime(attribute.StartDate);
            DateTime startDateProperty = Convert.ToDateTime(property.GetValue(item).ToString());

            DateTime endDateAttribute = Convert.ToDateTime(attribute.EndDate);
            DateTime endDateProperty = Convert.ToDateTime(property.GetValue(item).ToString());


            if (startDateProperty < startDateAttribute)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
            if (endDateProperty > endDateAttribute)
            {
                _errors.Add($"{property.Name} {attribute.ErrorMessage}");
            }
        }
    }



}
