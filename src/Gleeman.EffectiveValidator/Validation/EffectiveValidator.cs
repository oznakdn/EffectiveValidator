namespace Gleeman.EffectiveValidator.Validation;

public sealed class EffectiveValidator<T> where T : class
{
    private Type _type { get; }
    private PropertyInfo[] _properties { get; }
    private FieldInfo[] _fields { get; }
    private List<string> _errors { get; }

    public EffectiveValidator()
    {
        _type = typeof(T);
        _errors = new();
        _properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        _fields = _type.GetFields(BindingFlags.Public | BindingFlags.Instance);
    }

    public IValidationResult Validate(T item)
    {

        foreach (PropertyInfo property in _properties)
        {
            if (property.CustomAttributes != null)
            {
                if (property.GetCustomAttribute<CheckRequiredAttribute>() != null)
                {
                    CheckRequiredProperty(property, item);
                }
                if (property.PropertyType == typeof(string))
                {
                    if (property.GetCustomAttribute<CheckStringLenghtAttribute>() != null)
                    {
                        CheckStringLenghtProperty(property, item);
                    }
                    if (property.GetCustomAttribute<CheckStringEmptyAttribute>() != null)
                    {
                        CheckStringEmptyProperty(property, item);
                    }
                    if (property.GetCustomAttribute<CheckNameAttribute>() != null)
                    {
                        CheckNameProperty(property, item);
                    }
                    if (property.GetCustomAttribute<CheckEmailAttribute>() != null)
                    {
                        CheckEmailProperty(property, item);
                    }
                    if (property.GetCustomAttribute<CheckPhoneAttribute>() != null)
                    {
                        CheckPhoneNumberProperty(property, item);
                    }
                    if (property.GetCustomAttribute<CheckZipCodeAttribute>() != null)
                    {
                        CheckZipCodeProperty(property, item);
                    }
                    if (property.GetCustomAttribute<CheckCreditCardAttribute>() != null)
                    {
                        CheckCreditCardField(property, item);
                    }
                    if (property.GetCustomAttribute<CheckPassportAttribute>() != null)
                    {
                        CheckPassportNumberProperty(property, item);
                    }
                }
                if (property.PropertyType == typeof(int))
                {
                    if (property.GetCustomAttribute<CheckRangeAttribute>() != null)
                    {
                        CheckRangeProperty(property, item);
                    }
                }
                if (property.PropertyType == typeof(DateTime))
                {
                    if (property.GetCustomAttribute<CheckDateAttribute>() != null)
                    {
                        CheckDateProperty(property, item);
                    }
                }
            }
        }

        foreach (FieldInfo field in _fields)
        {
            if (field.CustomAttributes != null)
            {
                if (field.GetCustomAttribute<CheckRequiredAttribute>() != null)
                {
                    CheckRequiredField(field, item);
                }
                if (field.FieldType == typeof(string))
                {
                    if (field.GetCustomAttribute<CheckStringLenghtAttribute>() != null)
                    {
                        CheckStringLenghtField(field, item);
                    }
                    if (field.GetCustomAttribute<CheckStringEmptyAttribute>() != null)
                    {
                        CheckStringEmptyField(field, item);
                    }
                    if (field.GetCustomAttribute<CheckNameAttribute>() != null)
                    {
                        CheckNameField(field, item);
                    }
                    if (field.GetCustomAttribute<CheckEmailAttribute>() != null)
                    {
                        CheckEmailField(field, item);
                    }
                    if (field.GetCustomAttribute<CheckPhoneAttribute>() != null)
                    {
                        CheckPhoneNumberField(field, item);
                    }
                    if (field.GetCustomAttribute<CheckZipCodeAttribute>() != null)
                    {
                        CheckZipCodeField(field, item);
                    }
                    if (field.GetCustomAttribute<CheckCreditCardAttribute>() != null)
                    {
                        CheckCreditCardProperty(field, item);
                    }
                    if (field.GetCustomAttribute<CheckPassportAttribute>() != null)
                    {
                        CheckPassportNumberField(field, item);
                    }
                }
                if (field.FieldType == typeof(int))
                {
                    if (field.GetCustomAttribute<CheckRangeAttribute>() != null)
                    {
                        CheckRangeField(field, item);
                    }
                }
                if (field.FieldType == typeof(DateTime))
                {
                    if (field.GetCustomAttribute<CheckDateAttribute>() != null)
                    {
                        CheckDateField(field, item);
                    }
                }
            }
        }

        if (_errors.Count > 0) return new ValidationResult(_errors, false);
        return new ValidationResult(null, true);
    }

    #region CheckRequired

    void CheckRequiredProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckRequiredAttribute>();

        if (property != null)
        {
            if (propertyInfo.GetValue(item) == null)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} should not be null or empty!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckRequiredField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckRequiredAttribute>();

        if (field != null)
        {
            if (fieldInfo.GetValue(item) == null)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} should not be null or empty!");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }


    #endregion

    #region CheckStringLenght

    void CheckStringLenghtProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckStringLenghtAttribute>();

        if (property != null)
        {
            if (property.MinLenght > propertyInfo.GetValue(item).ToString().Length)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} lenght should be equal or greater then{property.MinLenght}");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
            if (property.MaxLenght < propertyInfo.GetValue(item).ToString().Length)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} lenght should be equal or less then{property.MaxLenght}");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckStringLenghtField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckStringLenghtAttribute>();

        if (field != null)
        {
            if (field.MinLenght > fieldInfo.GetValue(item).ToString().Length)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} lenght should be equal or greater then{field.MinLenght}");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
            if (field.MaxLenght < fieldInfo.GetValue(item).ToString().Length)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} lenght should be equal or less then{field.MaxLenght}");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }


    }


    #endregion

    #region CheckStringEmpty

    void CheckStringEmptyProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckStringEmptyAttribute>();

        if (property != null)
        {
            if (propertyInfo.GetValue(item).ToString() == string.Empty)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} lenght should not be empty!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckStringEmptyField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckStringEmptyAttribute>();

        if (field != null)
        {
            if (fieldInfo.GetValue(item).ToString() == string.Empty)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} lenght should not be empty!");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }


    #endregion

    #region CheckName

    void CheckNameProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckNameAttribute>();

        if (property != null)
        {
            Regex regex = new Regex(@"^[\p{L} \.'\-]+$");
            Match match = regex.Match(propertyInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckNameField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckNameAttribute>();

        if (field != null)
        {
            Regex regex = new Regex(@"^[\p{L} \.'\-]+$");
            Match match = regex.Match(fieldInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }

    #endregion

    #region CheckEmail

    void CheckEmailProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckEmailAttribute>();

        if (property != null)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            Match match = regex.Match(propertyInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckEmailField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckEmailAttribute>();

        if (field != null)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            Match match = regex.Match(fieldInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }

    #endregion

    #region CheckZipCode

    void CheckZipCodeProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckZipCodeAttribute>();

        if (property != null)
        {
            Regex regex = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
            Match match = regex.Match(propertyInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckZipCodeField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckZipCodeAttribute>();

        if (field != null)
        {
            Regex regex = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
            Match match = regex.Match(fieldInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }

    #endregion

    #region CheckPhoneNumber

    void CheckPhoneNumberProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckPhoneAttribute>();

        if (property != null)
        {
            Regex regex = new Regex(@"(\+[0-9]{2}|\+[0-9]{2}\(0\)|\(\+[0-9]{2}\)\(0\)|00[0-9]{2}|0)([0-9]{9}|[0-9\-\s]{9,18})");
            Match match = regex.Match(propertyInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckPhoneNumberField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckPhoneAttribute>();

        if (field != null)
        {
            Regex regex = new Regex(@"(\+[0-9]{2}|\+[0-9]{2}\(0\)|\(\+[0-9]{2}\)\(0\)|00[0-9]{2}|0)([0-9]{9}|[0-9\-\s]{9,18})");
            Match match = regex.Match(fieldInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }


    #endregion

    #region CheckCreditCard

    void CheckCreditCardProperty(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckCreditCardAttribute>();
        if (field != null)
        {
            Regex regex = null;

            switch (field.CreditCard)
            {
                case CreditCardType.Visa: regex = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$"); break;
                case CreditCardType.Mastercard: regex = new Regex(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"); break;
                case CreditCardType.AmericanExpress: regex = new Regex(@"^3[47][0-9]{13}$"); break;
            }

            Match match = regex.Match(fieldInfo.GetValue(item).ToString());

            if (!match.Success)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }

    void CheckCreditCardField(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckCreditCardAttribute>();

        if (property != null)
        {
            Regex regex = null;
            switch (property.CreditCard)
            {
                case CreditCardType.Visa: regex = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$"); break;
                case CreditCardType.Mastercard: regex = new Regex(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$"); break;
                case CreditCardType.AmericanExpress: regex = new Regex(@"^3[47][0-9]{13}$"); break;
            }

            Match match = regex.Match(propertyInfo.GetValue(item).ToString());

            if (!match.Success)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    #endregion

    #region CheckPassportNumber

    void CheckPassportNumberProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckPassportAttribute>();

        if (property != null)
        {
            Regex regex = new Regex(@"^(?!^0+$)[a-zA-Z0-9]{3,20}$");
            Match match = regex.Match(propertyInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckPassportNumberField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckPassportAttribute>();

        if (field != null)
        {
            Regex regex = new Regex(@"^(?!^0+$)[a-zA-Z0-9]{3,20}$");
            Match match = regex.Match(fieldInfo.GetValue(item).ToString());
            if (!match.Success)
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} format is wrong!");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }


    #endregion

    #region CheckRange

    void CheckRangeProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckRangeAttribute>();

        if (property != null)
        {
            if (property.Min > (int)propertyInfo.GetValue(item))
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} should be equal or greater than {property.Min}");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");

                }
            }
            if (property.Max < (int)propertyInfo.GetValue(item))
            {
                if (string.IsNullOrEmpty(property.ErrorMessage))
                {
                    _errors.Add($"{propertyInfo.Name} should be equal or less than {property.Max}");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }

        }
    }

    void CheckRangeField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckRangeAttribute>();

        if (field != null)
        {
            if (field.Min > (int)fieldInfo.GetValue(item))
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} should be equal or greater than {field.Min}");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");

                }
            }
            if (field.Max < (int)fieldInfo.GetValue(item))
            {
                if (string.IsNullOrEmpty(field.ErrorMessage))
                {
                    _errors.Add($"{fieldInfo.Name} should be equal or less than {field.Max}");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }

        }
    }


    #endregion

    #region CheckDate

    void CheckDateProperty(PropertyInfo propertyInfo, T item)
    {
        var property = propertyInfo.GetCustomAttribute<CheckDateAttribute>();

        if (property != null)
        {
            DateTime startDateAttribute = Convert.ToDateTime(property.StartDate);
            DateTime startDateProperty = Convert.ToDateTime(propertyInfo.GetValue(item).ToString());

            DateTime endDateAttribute = Convert.ToDateTime(property.EndDate);
            DateTime endDateProperty = Convert.ToDateTime(propertyInfo.GetValue(item).ToString());


            if (startDateProperty < startDateAttribute)
            {
                if (property.ErrorMessage == null)
                {
                    _errors.Add($"{propertyInfo.Name} should be equal or greater than {property.StartDate}!");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
            if (endDateProperty > endDateAttribute)
            {
                if (property.ErrorMessage == null)
                {
                    _errors.Add($"{propertyInfo.Name} should be equal or less than {property.EndDate}");
                }
                else
                {
                    _errors.Add($"{propertyInfo.Name} {property.ErrorMessage}");
                }
            }
        }
    }

    void CheckDateField(FieldInfo fieldInfo, T item)
    {
        var field = fieldInfo.GetCustomAttribute<CheckDateAttribute>();

        if (field != null)
        {
            DateTime startDateAttribute = Convert.ToDateTime(field.StartDate);
            DateTime startDateProperty = Convert.ToDateTime(fieldInfo.GetValue(item).ToString());

            DateTime endDateAttribute = Convert.ToDateTime(field.EndDate);
            DateTime endDateProperty = Convert.ToDateTime(fieldInfo.GetValue(item).ToString());


            if (startDateProperty < startDateAttribute)
            {
                if (field.ErrorMessage == null)
                {
                    _errors.Add($"{fieldInfo.Name} should be equal or greater than {field.StartDate}");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
            if (endDateProperty > endDateAttribute)
            {
                if (field.ErrorMessage == null)
                {
                    _errors.Add($"{fieldInfo.Name} should be equal or less than {field.EndDate}");
                }
                else
                {
                    _errors.Add($"{fieldInfo.Name} {field.ErrorMessage}");
                }
            }
        }
    }

    #endregion


}
