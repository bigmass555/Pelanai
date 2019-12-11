using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public CanvasGroup currentMenuGroup;
    public CanvasGroup nextMenuGroup;
    [SerializeField] bool closeCurrentMenu = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open_menu()
    {
        if (closeCurrentMenu)
        {
            turn_menu(currentMenuGroup, false);
        }
        turn_menu(nextMenuGroup, true);
    }
    void turn_menu(CanvasGroup target, bool state)
    {
        if (state)
        {
            target.alpha = 1;
        }
        else
        {
            target.alpha = 0;
        }
        target.blocksRaycasts = state;
        target.interactable = state;
    }
}
