using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public GameObject go;
    public Text txt; 
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time; //Time.time means right now
        go.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if(!active)
            return;

        //  10sec in the game - we started showing this object at 7 sec in the game > 2 sec
        if(Time.time - lastShown > duration)
            Hide();

        else
            go.transform.position += motion * Time.deltaTime;
    }
}
