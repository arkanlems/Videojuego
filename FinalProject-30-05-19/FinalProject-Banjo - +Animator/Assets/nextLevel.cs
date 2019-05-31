using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
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
        string oldScreenName = "ScreenGameLevel1";
        string newScreenName = "ScreenGameLevel2";
        string pathToScreens = "Levels/";

        // Destroy the current UI Screen
        GameObject oldScreen = GameObject.Find( oldScreenName);
        Destroy(oldScreen);

        

        // Creates a copy of the new UI Screen
        GameObject newScreen = Instantiate(Resources.Load(pathToScreens + newScreenName) as GameObject);
        newScreen.SetActive(true);
        newScreen.name = newScreenName;

        
        
    }

}
