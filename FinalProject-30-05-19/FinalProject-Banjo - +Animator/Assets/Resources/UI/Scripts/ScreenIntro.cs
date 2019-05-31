using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tapOnStartButtom() {

        string oldScreenName = "ScreenIntro";
        string newScreenName = "ScreenGame";
        string canvasName = "Canvas";
        string pathToScreens = "UI/Screens/";

        GameObject oldScreen = GameObject.Find(canvasName+"/"+oldScreenName);
        oldScreen.SetActive(false);



        GameObject canvas = GameObject.Find(canvasName);

        GameObject newScreen = Instantiate(Resources.Load(pathToScreens+ newScreenName)as GameObject);
        newScreen.SetActive(true);
        newScreen.name = newScreenName;

        newScreen.transform.SetParent(canvas.transform);
    }
}
