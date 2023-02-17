using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelperPSR.Enums
{
public class EnumsDataSO : ScriptableObject
{

    public static EnumsDataSO current;
    public static Enums currentEnums;
    public EnumData[] enumsData;
    private void OnDestroy()
    {
        current = null;
    }
}
}

