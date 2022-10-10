using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectPlayer : MonoBehaviour
{
    public static SubjectPlayer instance;
    public List<ObserverInterface> list;

    private void Awake() {
        instance = this;
        list = new List<ObserverInterface>();
    }
    public void AddObserver(ObserverInterface obs){
        list.Add(obs);
    }
    public void RemoveObserver(ObserverInterface obs){
        list.Remove(obs);
    }
    public void NotifyObserver(string state){
        foreach (ObserverInterface obs in list)
        {
            obs.NotifyObserver(state);
        }
    }
}
