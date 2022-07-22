using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI playText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnPointerDown()
    {

        playText.color = Color.gray;

    }
}
