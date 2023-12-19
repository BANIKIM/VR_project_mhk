using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice_Cube : MonoBehaviour
{
    private Transform Slice_ob;//자르는 기준이 되는 오브젝트
    public GameObject target; //잘리는 오브젝트
    public Material cross; //잘리는 단면의 대한 material

    public float cutForce = 2000f;//잘릴떄 우아하게 보이기 위해서 힘을 줌

    //막대봉 관련 변수
    Vector3 presious_pos;//이전 위치
    public LayerMask Layer;

    private void Update()
    {
        RaycastHit hit;//타깃
        if (Physics.Raycast
            (transform.position, transform.forward,out hit ,5,Layer))
        {
            if(Vector3.Angle
                (transform.position-presious_pos,
                hit.transform.up)>=130f)
            {
                //slice 를 만ㄷ르어 주세용
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
            //빵빵 터지게 효과 넣어 주세용~
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
