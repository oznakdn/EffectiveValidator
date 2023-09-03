﻿namespace Gleeman.EffectiveValidator.CustomAttributes;

public class CheckEmailAttribute : AbstractAttribute<CheckEmailAttribute>
{

    public CheckEmailAttribute(string errorMessage) : base(errorMessage)
    {
    }
}
