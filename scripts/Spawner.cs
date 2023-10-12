	public Transform[] spawnPoints;
    public GameObject enemy;

    public float startTimeBetweenSpawn;
    private float timeBetweenSpawn;

    private float gameTime = 0f;
    private int stage = 1;
    public float maximumDiff;

    private void Start()
    {
        timeBetweenSpawn = startTimeBetweenSpawn;
    }
    private void Update()
    {
        if (PhotonNetwork.IsMasterClient == true && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            if (timeBetweenSpawn <= 0)
            {
                Vector3 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
                PhotonNetwork.Instantiate(enemy.name, randomSpawnPoint, Quaternion.identity);
                timeBetweenSpawn = startTimeBetweenSpawn;
            }
            else
            {
                timeBetweenSpawn -= Time.deltaTime;
            }
        }

        gameTime += Time.deltaTime;

        if ( gameTime >= 40 )
        {
            gameTime = 0;
            stage++;
            startTimeBetweenSpawn = startTimeBetweenSpawn / stage + maximumDiff;
        }

    }