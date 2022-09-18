using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(1);
    }
    //public Transform levelsParent;
    //List<Transform> levels = new();
    //Transform currentLevel = null;

    //void Start()
    //{
    //    foreach (Transform child in levelsParent)
    //    {
    //        levels.Add(child);
    //    }

    //    foreach (Transform i in levels)
    //    {
    //        i.GetComponent<Button>().onClick.AddListener(() => SelectLevel(i));
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void SelectLevel(Transform selectedLevel)
    //{
    //  Debug.Log("Clicked");
    //  currentLevel = selectedLevel;
    //  GameObject glowOn =  selectedLevel.Find("Glow").gameObject;
    //  Debug.Log(glowOn);
    //  glowOn.SetActive(true);

    //  foreach (Transform i in levels)
    //  {
    //    if (i != selectedLevel)
    //    {
    //      GameObject glowOff = i.Find("Glow").gameObject;
    //      glowOff.SetActive(false);
    //    }
    //  }
    //}

    //public void PlayLevel()
    //{
    //  SceneManager.LoadScene(currentLevel.name, LoadSceneMode.Single);
    //}
}
