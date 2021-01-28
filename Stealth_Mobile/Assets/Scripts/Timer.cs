using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public static Timer Create(Action _action, float _timer)
    {
        GameObject monoBehaviourHood = new GameObject("Timer", typeof(MonoBehaviourHood));

        Timer timer = new Timer(_action, _timer, monoBehaviourHood);

        
        monoBehaviourHood.GetComponent<MonoBehaviourHood>().OnUpdate = _action;

        return timer;
    }

    public class MonoBehaviourHood : MonoBehaviour
    {
        public Action OnUpdate;
        private void Update()
        {
            if (OnUpdate != null) OnUpdate();
        }
    }
    
    Action action;
    float timer;
    bool isDestroyed;
    GameObject gameObject;
    private Timer(Action _action, float _timer, GameObject _gameObject)
    {
        action = _action;
        timer = _timer;
        isDestroyed = true;
        gameObject = _gameObject;
    }

    public void Update()
    {
        if (!isDestroyed)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                action();
                DestroySelf();
            }
        }
    }

    void DestroySelf()
    {
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
    }
}
