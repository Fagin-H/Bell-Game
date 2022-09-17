using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsGlowing : MonoBehaviour
{
    public GameObject glowImage;

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOnGlowing()
    {
      glowImage.SetActive(true);
    }
    public void TurnOffGlowing()
    {}
}
