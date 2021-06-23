using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentGoobers;
    public Text gooberText;
    // Start is called before the first frame update
    void Start()
    {
        currentGoobers = 0;
        gooberText.text = "Goobers: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGoober(int numGoobers)
    {
        currentGoobers += numGoobers;
        gooberText.text = "Goobers: " + currentGoobers;
    }
}
