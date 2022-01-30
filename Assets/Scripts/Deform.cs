using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deform : MonoBehaviour
{

	/*private Mesh m;
    private Vector3[] verts;

    public float radius = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<MeshFilter>().mesh;

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Obstacle"))
        {
            print("First point that collided: " + col.contacts[0].point);
            Vector3 pt = transform.InverseTransformPoint(col.GetContact(0).point);
            Vector3 nrm = transform.InverseTransformDirection(col.GetContact(0).normal);
            float colForce = col.impulse.magnitude;


            float scale;
            m.vertices = verts;
            for (int i = 0; i < verts.Length; i++)
            {
                //Get deformation scale based on distance
                scale = Mathf.Clamp(radius - (pt - verts[i]).magnitude, 0, radius);

                //Deform by impulse multiplied by scale and strength parameter
                verts[i] += nrm * colForce * scale;
            }
        }
    }*/


	//Public
	public float minImpulse = 2;
	public float malleability = 0.05f;
	public float radius = 0.1f;
	public GameObject sphereCar;
	//Private
	private Mesh m;
	private BoxCollider mc;
	private Vector3[] verts;
	private Vector3[] iVerts;

	private void Start()
	{
		m = sphereCar.GetComponent<MeshFilter>().mesh;
		mc = sphereCar.GetComponent<BoxCollider>();
		iVerts = m.vertices;
	}

	private void OnCollisionEnter(Collision collision)
	{

		//Get point, impulse mag, and normal
		Vector3 pt = sphereCar.transform.InverseTransformPoint(collision.GetContact(0).point);
		Vector3 nrm = sphereCar.transform.InverseTransformDirection(collision.GetContact(0).normal);
		float imp = collision.impulse.magnitude;
		if (collision.gameObject.CompareTag("Obstacle"))
        {
			if (imp < minImpulse)
				return;

			//Deform vertices
			verts = m.vertices;
			float scale; ///Declare outside of tight loop
			for (int i = 0; i < verts.Length; i++)
			{
				//Get deformation scale based on distance
				scale = Mathf.Clamp(radius - (pt - verts[i]).magnitude, 0, radius);

				//Deform by impulse multiplied by scale and strength parameter
				verts[i] += nrm * imp * scale * malleability;
				m.vertices = verts;
			}
		}
		
		

		//Apply changes to collider and mesh
		
		//mc.sharedMesh = m;

		//Recalculate mesh stuff
		///Currently gets unity to recalc normals. Could be optimized and improved by doing it ourselves.
		m.RecalculateNormals();
		m.RecalculateBounds();
	}

	private void OnApplicationQuit()
	{
		//Need to reset mesh after quit
		m.vertices = iVerts;
	}
}
