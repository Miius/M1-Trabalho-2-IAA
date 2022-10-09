using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMachineFSM : MonoBehaviour, ObserverInterface
{
    StateFSM state;
    [SerializeField] private Transform target;
    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }
    // public float speed;
    // public float energy;

    void Start()
    {
        // SubjectPlayer.instance.notify += NotifyObserver;
        Target = GameObject.Find("Player").transform;
        SetState(new PatrolStateFSM(this));
        // energy = 3;
    }

    void FixedUpdate()
    {
        state?.Update();
    }

    public void NotifyObserver(){
        SetState(new ScapeStateFSM(this));
    }

    public void SetState(StateFSM state)
    {
        state?.Exit();
        this.state = state;
        state?.Enter();
    }

    public Vector3 TargetDir()
    {

        Vector3 dir = target.position - transform.position;
        return dir;
    }

    public bool IsNearTarget()
    {
        bool near = false;
        RaycastHit hit;
        Vector3 tg = new Vector3(target.position.x, 2.5f, target.position.z);
        if (Physics.Raycast(transform.position, tg, out hit))
        {
            // Debug.DrawLine(transform.position,tg,Color.white,1.0f);
            if(hit.collider.transform == target){
                Debug.DrawLine(transform.position,tg,Color.white,1.0f);
                near = true;
            }
        }
        return near;
    }
    public bool CollideWithTarget()
    {
        return TargetDir().magnitude < 15.0f;
    }

    // public void Move(Vector3 dir)
    // {
    //     energy -= Time.fixedDeltaTime;
    //     transform.position += dir * speed * Time.fixedDeltaTime;
    // }

    public void Die()
    {
        Destroy(this.gameObject);
    }
    public void GotThePlayer()
    {
        SceneManager.LoadScene("Teste");
    }
}
