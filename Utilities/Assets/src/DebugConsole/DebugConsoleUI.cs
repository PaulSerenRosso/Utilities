using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace DebugConsole
{
public class DebugConsoleUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private int maxLineCount = 10;

    private string myLog;
    private int lineCount;

    private void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    public void Log(string logString, string stackTrace, LogType logType)
    {
        switch (logType)
        {
            case LogType.Assert:
            {
                logString = "<color=white>" + "<b>" +logString +"/<b>" +": " + "<i>"+stackTrace +"</i>"+"</color>";
                break;
            }
            case LogType.Log:
            {
                logString = "<color=white>" +"<b>" +logString +"</b>"+"\n"+  "<i>"+stackTrace +"</i>"+"</color>";
                break;
            }
            case LogType.Warning:
            {
                logString = "<color=yellow>" + "<b>" +logString +"</b>" +  "<i>"+stackTrace +"</i>"+"</color>";
                break;
            }
            case LogType.Error:
            {
                logString = "<color=red>" + "<b>" +logString +"</b>" +  "<i>"+stackTrace +"</i>"+"</color>";
                break;
            }
            case LogType.Exception:
            {
                logString = "<color=red>" + "<b>" +logString +"</b>" +  "<i>"+stackTrace +"</i>"+"</color>";
                break;
            }
        }

        myLog += "\n"+"\n"+ logString;
        lineCount++;
        if (lineCount > maxLineCount)
        {
            lineCount--;
            myLog = DeleteLines(myLog, 1);
        }

        text.text = myLog; 
    }
    
    private string DeleteLines(string message, int count)
    {
        return message.Split(Environment.NewLine.ToCharArray(), count + 1).Skip(count).FirstOrDefault();
    }
}
    
}
