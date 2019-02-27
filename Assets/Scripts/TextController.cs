using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class TextController : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Text>().text = damageNum.ToString();
    }
}