using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BOSS : Hitable
{
    [SerializeField] private Transform[] crystalPosition;
    [SerializeField] private GameObject crystal;//which take immortals
    [SerializeField] private float timeBetweenSpawnCrystal=6f;
    [SerializeField]private float currentTimeSpawnCrystal=6f;
    [SerializeField]private bool IsImmortal = false;
    [SerializeField] private GameObject shield;
    
    [SerializeField] private GameObject minions;
    [SerializeField] private Transform[] minionsPosition;
    [SerializeField] private float timeBetweenSpawnMinions=3f;
    [SerializeField] private float currentTimeSpawnMinions=3f;
    private int currentCountOfMinions=0;
    [SerializeField]private int MaxCountOfMinions=5;
    
    

    [SerializeField] private int score=10;
    
    public delegate void AddScore(int scor);

    public static event AddScore AddScore1;
    
    public delegate void BossDie(string A);

    public static event BossDie Die;
    void Start()
    {
        Minion.Dead += MinionDie;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCrystal();
        //SpawnMinions();
    }

    void SpawnCrystal()
    {
        if (!IsImmortal && currentTimeSpawnCrystal<=0)
        {
            GameObject A = Instantiate(crystal, crystalPosition[Random.Range(0,crystalPosition.Length)].position, crystalPosition[0].rotation);
            var B = A.GetComponent<Crystal>();
            B.CrystalDestroy += CrystalDie;
            currentTimeSpawnCrystal = timeBetweenSpawnCrystal;
            IsImmortal = true;
            shield.SetActive(true);
        }
        currentTimeSpawnCrystal -= Time.deltaTime;
    }

    void SpawnMinions()
    {
        if (currentCountOfMinions<MaxCountOfMinions && currentTimeSpawnMinions<=0)
        {
            Instantiate(minions, minionsPosition[Random.Range(0,minionsPosition.Length)].position, transform.rotation);
            currentTimeSpawnMinions = timeBetweenSpawnMinions;
        }
        currentTimeSpawnMinions -= Time.deltaTime;
    }
    protected override void Death()
    {
        AddScore1(score);
        Die("Победа");
        Time.timeScale = 0f;
        base.Death();
    }

    void CrystalDie()
    {
        currentTimeSpawnCrystal = timeBetweenSpawnCrystal;
        IsImmortal = false;
        shield.SetActive(false);
    }

    void MinionDie()
    {
        currentCountOfMinions -= 1;
    }
}
