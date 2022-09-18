using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

  private static MusicManager musicInstance;
  void Awake()
  {
  DontDestroyOnLoad(this);

  if (musicInstance == null) {
      musicInstance = this;
  } else {
    Destroy(gameObject);
  }
}

public static void SetVolume(System.Single volume)
{
  musicInstance.GetComponent<AudioSource>().volume = volume;
}

}
