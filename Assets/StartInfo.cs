using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInfo : MonoBehaviour
{
    public bool isUsed;
    public PauseMenu pasueMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (!isUsed)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            pasueMenu.Resume();
            this.gameObject.SetActive(false);
        }
    }
}
