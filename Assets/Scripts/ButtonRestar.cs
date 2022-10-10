using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestar : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 10*Time.deltaTime, 0);
    }
    public void Click()
    {
        SceneManager.LoadScene("Game");
    }
}
