using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class circleChart_Test : MonoBehaviour
{
    public bool b = true;
    public Image image;
    public Text progress;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (b)
        {
            image.fillAmount = Inputdata.index_F / 2000f;
            
            if (progress)
            {
                progress.text = (int)(image.fillAmount * 2000f) + "";
            }
        }
    }
}
