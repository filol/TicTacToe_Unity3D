using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour {
    public Button button;

	void Start()
    {
        button.onClick.AddListener(restart);
    }

    void restart()
    {
        
    }
}
