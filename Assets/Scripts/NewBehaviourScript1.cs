using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class NewBehaviourScript1 : MonoBehaviour
{
    [SerializeField] Text text;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(text.TextCallBack(() => Debug.Log("AAAAAAAA"),1f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
