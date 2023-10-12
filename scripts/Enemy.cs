

    public PlayerController[] players;
    public static PlayerController nearestPlayer;
    public float speed;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        players = FindObjectsOfType<PlayerController>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float distanceOne = Vector2.Distance(transform.position, players[0].transform.position);
        float distanceTwo = Vector2.Distance(transform.position, players[1].transform.position);

        if (distanceOne < distanceTwo)
        {
            nearestPlayer = players[0];
        } else
        {
            nearestPlayer = players[1];
        }
        if (nearestPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, speed * Time.deltaTime);
        }
        this.spriteRenderer.flipX = Enemy.nearestPlayer.transform.position.x < this.transform.position.x;
    }