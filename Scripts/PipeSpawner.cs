using UnityEngine;

/// <summary>
/// Spawner pipe after 2s and random pipe 
/// </summary>
public class PipeSpawner : MonoBehaviour
{
    #region -Variable-
    [SerializeField] 
    private float maxTime = 1;      // Time Spawner Pipe

    [SerializeField] 
    private float timer;            // runtime check if = max time spawn 

    [SerializeField] 
    private GameObject pipe;        // prefab Pipe
    
    // <name>_<type>
    // pipePrefab, scoreText, deadMaterial, myComponentRef

    [SerializeField] 
    private float height;           // set height pipe
    
    [SerializeField] 
    private float destroy = 10f;    // destroy after 10s

    private bool _gameStart;        // check game start disable button and UI
    
    [SerializeField] 
    private GameObject box;          // box hold bird 
   
    #endregion
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _gameStart = true;
            box.SetActive(false);
        }
        if (timer > maxTime && _gameStart)
        {
            SpawnPipe();
        }
        timer += Time.deltaTime;
    }
    
    /// <summary>
    /// spawner pipe and destroy 
    /// </summary>
    private void SpawnPipe() // 
    {
        GameObject newpipe = Instantiate(pipe);
        newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        Destroy(newpipe, destroy);
        timer = 0f;
    }
}
