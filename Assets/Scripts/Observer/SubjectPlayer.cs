using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPlayer : MonoBehaviour
{
    public static SubjectPlayer instance;
    public delegate void MyDelegate();
    public MyDelegate notify;

    private void Awake() {
        instance = this;
    }
    public void NotifyObserver(){
        notify();
    }
}
