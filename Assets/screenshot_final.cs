using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class screenshot_final : MonoBehaviour
{
    private MovementController moveCont;

    // Start is called before the first frame update
    private int shotind = 0;
    private int count=0;
    DirectoryInfo folder;

    void Start()
    {
        moveCont = gameObject.GetComponent<MovementController>();
        folder = Directory.CreateDirectory($"Screenshots_{System.DateTime.Now.ToString("yyyy-MM-dd-THH:mm:ss")}");
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCont.currentCommand < moveCont.moveList.Count)
        {
            if(count%10==0) { // Takes screenshot after every 30 frames
            ScreenCapture.CaptureScreenshot($"{folder}/screenshot_{System.DateTime.Now.ToString("yyyy-MM-dd-THH:mm:ss")}_{shotind}.png", 2);
            shotind++;
            }
            count++;
        }
    }
}
