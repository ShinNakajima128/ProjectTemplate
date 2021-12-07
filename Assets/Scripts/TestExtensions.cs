using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public static class TestExtensions
{
    public static IEnumerator  TextCallBack(this Text text, UnityAction callBack,float time = 1f) 
    {
        
        text.text = "呼ばれたよ";
        yield return new WaitForSeconds(time);

        if(callBack != null)
            callBack.Invoke();
    }
}

