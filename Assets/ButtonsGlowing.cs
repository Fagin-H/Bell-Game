using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsGlowing : MonoBehaviour
{
    public GameObject object;

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOnGlowing()
    {
      object.SetActive(true);
    }
    public void TurnOffGlowing()
    {}
}
