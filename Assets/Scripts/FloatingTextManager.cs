using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
            txt.UpdateFloatingText();
    }
    
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); //get the main Camera in the scene so the camera has to be named 'main Camera' and trasform it into screen space since we are in World space
        
        //Only here to transform knowledge from the manager to the floating text object
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show(); //show text on the screen
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);
        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab); //creation of a new game object and assign it to txt.go
            txt.go.transform.SetParent(textContainer.transform); //the parent of this game object is going to be the transform of textContainer
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
