
public class Ovni : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        _currentTargetPos = _startPos; 
        _parentTransform = this.transform.parent.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
        if(_canAttack)
            StartCoroutine(Attack()); 
    }

}
