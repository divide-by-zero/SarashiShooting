using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Text>().text = GameManager.Instance.damageNum.ToString();
    }
}