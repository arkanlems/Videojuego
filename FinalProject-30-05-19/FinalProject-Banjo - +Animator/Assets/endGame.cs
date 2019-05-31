using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        string oldScreenName = "ScreenGameLevel2";
        string newScreenName = "ScreenFinalLevel1";
        string canvasName = "Canvas";
        string pathToScreens = "UI/Screens/";

        string points = GameObject.Find("Canvas/ScreenGame/TextCorn").GetComponent<Text>().text;
        string lifes = GameObject.Find("Canvas/ScreenGame/TextLifes").GetComponent<Text>().text;


        // Destroy the current UI Screen
        GameObject oldScreen = GameObject.Find( oldScreenName);
        Destroy(oldScreen);

        GameObject oldScreen1 = GameObject.Find(canvasName + "/" + "ScreenButtons");
        Destroy(oldScreen1);

        GameObject oldScreen2 = GameObject.Find(canvasName + "/" + "ScreenGame");

        
        System.Console.WriteLine(points);
        Destroy(oldScreen2);

        // Get a reference to canvas object
        GameObject canvas = GameObject.Find(canvasName);

        // Creates a copy of the new UI Screen
        GameObject newScreen = Instantiate(Resources.Load(pathToScreens + newScreenName) as GameObject);
        newScreen.SetActive(true);
        newScreen.name = newScreenName;

        // Make the new screen child of canvas object
        newScreen.transform.SetParent(canvas.transform);

        // Reset new screen's transform
        newScreen.transform.rotation = Quaternion.identity;
        newScreen.transform.position = Vector3.zero;
        newScreen.transform.localScale = Vector3.one;

        // Locate anchors on screen's corners
        newScreen.GetComponent<RectTransform>().anchorMin = Vector2.zero;
        newScreen.GetComponent<RectTransform>().anchorMax = Vector2.one;

        // Move vertices to anchor's position
        newScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        newScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        GameObject.Find("Canvas/ScreenFinalLevel1/ImagePanel1/Lifes").GetComponent<Text>().text = lifes;
        GameObject.Find("Canvas/ScreenFinalLevel1/ImagePanel1/Corn").GetComponent<Text>().text = points;
    }
}
