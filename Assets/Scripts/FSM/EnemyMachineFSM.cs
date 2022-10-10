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

    public Transform startPosition;
    // public float speed;
    // public float energy;

    void Start()
    {
        SubjectPlayer.instance.AddObserver(this);
        Target = GameObject.Find("Player").transform;
        SetState(new PatrolStateFSM(this));
        startPosition = this.transform;
        // energy = 3;
    }

    void FixedUpdate()
    {
        state?.Update();
    }

    public void NotifyObserver(string state){
        print(state);
        if(state == "coletou")
            SetState(new ScapeStateFSM(this));
        else
            SetState(new PatrolStateFSM(this));
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
        if (Physics.Raycast(transform.position, TargetDir(), out hit, float.MaxValue))
        {
            // Debug.Log(hit.collider);
            if(hit.collider.transform == target){
                near = true;
            }
        }
        return near;
    }
    public bool CollideWithTarget()
    {
        return /* TargetDir().magnitude */ Vector3.Distance(transform.position, target.position) < 10.0f;
    }

    // public void Move(Vector3 dir)
    // {
    //     energy -= Time.fixedDeltaTime;
    //     transform.position += dir * speed * Time.fixedDeltaTime;
    // }

    private void OnDrawGizmosSelected() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, TargetDir(), out hit, float.MaxValue))
        {
            if(hit.collider.transform == target){
                Gizmos.color = Color.blue;
            }
            else
                Gizmos.color = Color.white;
        }
        Gizmos.DrawRay(transform.position, TargetDir());
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
    public void GotThePlayer()
    {
        SceneManager.LoadScene("Game");
    }
}
