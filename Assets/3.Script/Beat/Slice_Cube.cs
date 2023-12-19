using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice_Cube : MonoBehaviour
{
    private Transform Slice_ob;//�ڸ��� ������ �Ǵ� ������Ʈ
    public GameObject target; //�߸��� ������Ʈ
    public Material cross; //�߸��� �ܸ��� ���� material

    public float cutForce = 2000f;//�߸��� ����ϰ� ���̱� ���ؼ� ���� ��

    //����� ���� ����
    Vector3 presious_pos;//���� ��ġ
    public LayerMask Layer;

    private void Update()
    {
        RaycastHit hit;//Ÿ��
        if (Physics.Raycast
            (transform.position, transform.forward,out hit ,5,Layer))
        {
            if(Vector3.Angle
                (transform.position-presious_pos,
                hit.transform.up)>=130f)
            {
                //slice �� �������� �ּ���
                Slice_object(hit.transform.gameObject);
            }
        }


        presious_pos = transform.position;
    }


    public void Slice_object(GameObject target)
    {
        Slice_ob = target.transform.GetChild(1);

        //SlicedHull hull = target.Slice(Slice_ob.position, Slice_ob.up);
        Vector3 slice_normal = Vector3.Cross(transform.position - presious_pos, transform.forward);
        SlicedHull hull = target.Slice(Slice_ob.position, slice_normal);
        if (hull!=null)
        {
            GameObject Upperhull = hull.CreateUpperHull(target, cross);
            GameObject Lowerhull = hull.CreateLowerHull(target, cross);
            if(target.transform.childCount>0)
            {
                for(int i=0;i<transform.childCount;i++)
                {
                    GameObject g = target.transform.GetChild(i).gameObject;
                    if (g.transform.CompareTag("Slice_ob")) continue;
                    SlicedHull hull_c = g.Slice(Slice_ob.position,slice_normal);

                    if(hull_c!=null)
                    {
                        GameObject upper_c = hull_c.CreateUpperHull(g, cross, Upperhull);
                        GameObject Lower_c = hull_c.CreateLowerHull(g, cross, Lowerhull);
                    }
                }
            }

            Destroy(target);
            //���� ������ ȿ�� �־� �ּ���~
            SetupSlice_Component(Upperhull);
            SetupSlice_Component(Lowerhull);

            Destroy(Upperhull, 1.0f);
            Destroy(Lowerhull, 1.0f);
        }

    }

    private void SetupSlice_Component(GameObject g)
    {
        Rigidbody rb = g.AddComponent<Rigidbody>();
        MeshCollider c = g.AddComponent<MeshCollider>();

        c.convex = true;
        rb.AddExplosionForce(cutForce, g.transform.position, 1);
    }

}
