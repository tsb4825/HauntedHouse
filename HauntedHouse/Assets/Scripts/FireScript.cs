using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float SparkleFrequency;
    public float SparkleIntensity;

    private float _currentChangeTime;
    private float _nextChangeTime;

    // Start is called before the first frame update
    void Start()
    {
        _nextChangeTime = SparkleFrequency * Random.Range(1f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        _currentChangeTime += Time.deltaTime;
        if (_currentChangeTime >= _nextChangeTime)
        {
            var newIntensity = Random.Range(1f, 1.4f) * SparkleIntensity;
            transform.GetComponent<Light>().intensity = newIntensity;
            _nextChangeTime = SparkleFrequency * Random.Range(1f, 1.2f);
            _currentChangeTime = 0;
        }
    }
}
