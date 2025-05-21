using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class vanishingPlat : MonoBehaviour
{

    [SerializeField] private float _fadeTime = 4.5f;
    [SerializeField] private float _interval = 5f;
    [SerializeField] private float _respawn = 2f;


    private bool _active = false;       

    private Collider _collider;
    private Material _material;
    

//private IEnumerator FadeBehaviour()
//{
  //      _active = true;

    //    float t = 0.0f;

      //  while (t < 1f)
        //{
          //  t += Time.deltaTime/_fadeTime;
            //_material.color = new Color(_material.color.r);
        //}
}


}
