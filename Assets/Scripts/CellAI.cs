using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAI : MonoBehaviour
{

    public Chromosome DNA;
    public CellManager Me;
    public Rigidbody2D Rb;

    private void Start()
    {
        DNA = this.GetComponent<Chromosome>();
        Me = this.GetComponent<CellManager>();
        Rb = this.GetComponent<Rigidbody2D>();
    }

    public Collider2D[] Look()
    {
        Collider2D[] Objects = Physics2D.OverlapCircleAll(this.transform.position, this.GetComponent<Chromosome>().SenseRange);
        return Objects;
    }

    public void FixedUpdate()
    {
        if (!Ticking)
            StartCoroutine(Tick());
        if (!Ticking2)
            StartCoroutine(Tick2());
    }
    public GameObject ClosestPlant = null;
    public GameObject ClosestMeat = null;
    public GameObject ClosestKillable = null;
    public GameObject ClosestDanger = null;
    private bool Ticking;
    private bool Ticking2;


    IEnumerator Tick2()
    {
        Ticking2 = true;
        yield return new WaitForSeconds(0.1f);
        Ticking2 = false;
        Blink();
    }
    IEnumerator Tick()
    {
        Ticking = true;
        yield return new WaitForSeconds(0.01f);
        GameObject Target = null;
        if (ClosestDanger!=null)
        {
            Target = ClosestDanger.gameObject;
                transform.right = Vector3.Lerp(transform.right, transform.position- ClosestDanger.transform.position,0.1f);

          //  transform.right =transform.position - ClosestDanger.transform.position;


            Rb.AddForce(this.transform.right * DNA.Speed);
                Me.Energy -= 1 / DNA.FoodEfficency;
        }
        else if (Me.CurrentFood < DNA.FoodCapacity)
        {
            if (ClosestKillable != null)
                Target = ClosestKillable;
            if (ClosestMeat != null)
                Target = ClosestMeat;
            if (DNA.Bacteria && ClosestPlant != null)
                Target = ClosestPlant;


            if (Target != null)
            {
               transform.right = Vector3.Lerp(transform.right,Target.transform.position - transform.position,0.1f);
            //    transform.right = Target.transform.position - transform.position;

                Rb.AddForce(this.transform.right * DNA.Speed);
                Me.Energy -= 1 / DNA.FoodEfficency;
            }


        }
        if(Target==null)
        {

           
            transform.right += (new Vector3(RandomNumberList.GetNumber(), RandomNumberList.GetNumber(), 0));
            Rb.AddForce(this.transform.right * DNA.Speed*5);
            Me.Energy -= 5*(1 / DNA.FoodEfficency);
          yield return new WaitForSeconds(1f);
        }
        Ticking = false;
    }
    private void OnDrawGizmosSelected()
    {

       


        foreach (Collider2D c in Look())
        {
            if (c.gameObject.tag == "FoodP")
            {
                Gizmos.color = Color.gray;
                if (DNA.Bacteria)
                    Gizmos.color = Color.cyan;
                Gizmos.DrawLine(this.transform.position, c.transform.position);
            }
            if (c.gameObject.GetComponent<Chromosome>() != null)
            {
                if (c.gameObject == Me.Child)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawLine(this.transform.position, Me.Child.transform.position);
                }
                else if (c.GetComponent<Chromosome>().SpeciesID == DNA.SpeciesID)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(this.transform.position, c.transform.position);
                }
            }

        }

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, this.GetComponent<Chromosome>().SenseRange);

        DNA = this.GetComponent<Chromosome>();
        Me = this.GetComponent<CellManager>();
        Rb = this.GetComponent<Rigidbody2D>();
        Blink();
        Gizmos.color = Color.green;
        if (ClosestPlant != null)
        {
            if (!this.GetComponent<Chromosome>().Bacteria)
                Gizmos.color = Color.black;
            Gizmos.DrawLine(this.transform.position, ClosestPlant.transform.position);
        }
        Gizmos.color = Color.green;
        if (ClosestMeat != null)
        {
            if(this.GetComponent<Chromosome>().Bacteria)
                Gizmos.color = Color.black;
            Gizmos.DrawLine(this.transform.position, ClosestMeat.transform.position);
        }
        Gizmos.color = Color.yellow;
        if (ClosestKillable != null)
        {
      
            
            Gizmos.DrawLine(this.transform.position, ClosestKillable.transform.position);
        }
        Gizmos.color = Color.red;
        if (ClosestDanger != null)
            Gizmos.DrawLine(this.transform.position, ClosestDanger.transform.position);




                Gizmos.color = Color.white;
    }

   

    public void Blink()
    {

             ClosestPlant = null;
      ClosestMeat = null;
      ClosestKillable = null;
      ClosestDanger = null;

    float Dist = Mathf.Infinity;
        float Dist2 = Mathf.Infinity;
        float Dist3 = Mathf.Infinity;
        float Dist4 = Mathf.Infinity;
        foreach (Collider2D c in Look())
        {
            if (c.gameObject != this.gameObject)
            {
                if (Vector2.Distance(this.transform.position, c.transform.position) < Dist && c.gameObject.tag == "FoodP")
                {
                    Dist = Vector2.Distance(this.transform.position, c.transform.position);
                    ClosestPlant = c.gameObject;
                }

                if (Vector2.Distance(this.transform.position, c.transform.position) < Dist2 && c.gameObject.tag == "Food" && c.gameObject.GetComponent<Chromosome>() == null)
                {
                    Dist = Vector2.Distance(this.transform.position, c.transform.position);
                    ClosestMeat = c.gameObject;
                }

                if (Vector2.Distance(this.transform.position, c.transform.position) < Dist3 && c.gameObject.tag == "Food" && c.gameObject.GetComponent<Chromosome>() != null)
                {
                    if (CompareSize(this.gameObject, c.gameObject)==1 && c.gameObject != Me.Child&&c.GetComponent<Chromosome>().SpeciesID!=DNA.SpeciesID)
                    {
                        Dist = Vector2.Distance(this.transform.position, c.transform.position);
                        ClosestKillable = c.gameObject;
                    }
                }
                if (Vector2.Distance(this.transform.position, c.transform.position) < Dist4 && c.gameObject.tag == "Food" && c.gameObject.GetComponent<Chromosome>() != null)
                {
                    if (CompareSize(this.gameObject,c.gameObject)==0 && c.gameObject != Me.Child)
                    {
                        Dist = Vector2.Distance(this.transform.position, c.transform.position);
                        ClosestDanger = c.gameObject;
                    }
                }
            }
        }
    }
    public int CompareSize(GameObject g,GameObject c)
    {
        float Size = c.transform.localScale.x;
        Size = c.transform.localScale.x;
        if (!c.gameObject.GetComponent<Chromosome>().Bacteria)
        {
         //   Size += 1;
            Size /= 10;
        }
        float Size2 = g.transform.localScale.x;
        Size2 = g.transform.localScale.x;
        if (!DNA.Bacteria)
        {
            Size2 /= 10;
         //   Size2 += 1;
        }
        if (Size > Size2)
            return 0;
        else if (Size < Size2)
            return 1;
        else
            return -1;
    }
    private void OnCollisionStay2D(Collision2D collision)
    { 
        if(collision.gameObject.tag=="Food"&&collision.gameObject.GetComponent<Chromosome>()!=null)
        {
            if (CompareSize(this.gameObject, collision.gameObject) == 1 && collision.gameObject != Me.Child)
            {
                if (collision.gameObject.GetComponent<CellManager>().age > 1)
                {
                    if (!Attacking) 
                    StartCoroutine(Attack(collision.gameObject));
                }
            }
        }
        if(collision.gameObject.tag=="Border")
        {
            transform.right = new Vector3(0,0,this.transform.position.z) - transform.position;

            Rb.AddForce(this.transform.right * DNA.Speed*5);
            
        }
    }
    private bool Attacking;
    IEnumerator Attack(GameObject collision)
    {
        Attacking = true;
        yield return new WaitForSeconds(0.01f);
        Attacking = false;
        if (collision.gameObject != null)
        {
            if (collision.gameObject.GetComponent<Chromosome>().SpeciesID == DNA.SpeciesID)
                collision.gameObject.GetComponent<CellManager>().Health -= DNA.Attack / 100;
            else
                collision.gameObject.GetComponent<CellManager>().Health -= DNA.Attack;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food" && collision.gameObject.GetComponent<Chromosome>() == null)
        {
            if (Me.CurrentFood < DNA.FoodCapacity)
            {
        
                Destroy(collision.gameObject);
                Me.CurrentFood+=collision.gameObject.GetComponent<MeatValue>().value;
                collision.gameObject.GetComponent<MeatValue>().value = 0;
            }
        }

        if (collision.gameObject.tag == "FoodP" && collision.gameObject.GetComponent<Chromosome>() == null)
        {
            if (DNA.Bacteria)
            {
                if (Me.CurrentFood < DNA.FoodCapacity)
                {
   
                    Destroy(collision.gameObject);
                    Me.CurrentFood++;
                }
            }
        }

    }


}
