using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HelperPSR.Class
{
public static class ClassHelper 
{
    public static T CopyClass<T>(this T original) where T : class, new()
    {
        Type type = typeof(T);
        T returnClass = new T();
        var fields = type.GetFields();
        foreach (var field  in fields)
        {
            if(field.IsStatic || field.IsLiteral)
                continue;
            field.SetValue(returnClass,  field.GetValue(original));
            
        }
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            
            property.SetValue(returnClass,property.GetValue(original));
        }
        return returnClass;
    }
}
}
