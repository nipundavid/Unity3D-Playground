using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQDemo : MonoBehaviour
{

    public int[] marks = { 15, 6, 65, 95, 84, 33, 74, 65, 32, 8, 52, 66, 78, 12, 54 };
    public List<Item> item = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        var passing = marks.Where(m => m > 69).OrderByDescending(g=>g).Reverse();
        foreach (var m in passing)
        {
            Debug.Log(m);
        }

        var result1 = item.Any(item => item.itemId == 3);
        Debug.Log(result1);

        var result2 = item.Where(item => item.buff > 20);
        foreach (var m in result2)
        {
            Debug.Log(result2);
        }

        var result3 = item.Average(item => item.buff);
        foreach (var m in result2)
        {
            Debug.Log(result3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public class Item
{
    public string name;
    public int itemId;
    public int buff;
}
