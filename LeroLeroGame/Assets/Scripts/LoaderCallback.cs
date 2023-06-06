using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;
    // Start is called before the first frame update
    private void Update()
    {
        if(isFirstUpdate) {
            isFirstUpdate = false;
            Loader.LoaderCallback();
        }
    }

}
