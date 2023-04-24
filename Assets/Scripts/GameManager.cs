using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int points;
    public TMP_Text text;
    public static GameManager instance;
    public static GameManager GetInstance() { return instance; }

    private void Awake(){
        // Singleton
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        points=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetPoints()
    {
        return points;
    }

    public void AddPoints(int p)
    {
        points += p;
    }
    public void UpdatePoints()
    {
        text.text = points.ToString();
    }
}
