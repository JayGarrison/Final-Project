using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float durationMinutes = 5.0f;
    
    public int startTimeHourly = 0;  //Hours
    public int endTimeHourly = 6;  //Hours
  
    public float timeMultiplier = 1.0f; // to speed up game for testing

    [SerializeField]
    float actualTime = 0.0f;
    [SerializeField]
    float gameTime = 0.0f;

    bool isRunning = false;
    bool timerFinished = false;

    public bool TimerFinished { get => timerFinished; private set => timerFinished = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartTimeManager()
    {
        isRunning = true;
    }

    void EndTimeManager()
    {
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            actualTime += Time.deltaTime * timeMultiplier;
            float normalizeTime = actualTime / (durationMinutes * 60.0f);
            gameTime = normalizeTime * (endTimeHourly - startTimeHourly);

            if(actualTime > durationMinutes * 60.0f)
            {
                isRunning = false;
                gameTime = endTimeHourly;
                TimerFinished = true;
            }
    }
    }
   
}
