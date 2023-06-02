using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public bool isPlaying;
    public Transform[] Space;
    public Transform[] Planets;
    public Transform[] Galaxies;
    public float SpaceSpeed;
    public float PlanetsSpeed;
    public float GalaxiesSpeed;

    private void Update()
    {
        if (isPlaying)
        {
            foreach (Transform t in Space)
            {
                t.Translate(Vector3.down * SpaceSpeed * Time.deltaTime);

                if (t.localPosition.y < -13.5f)
                {
                    t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y + Space.Length * 13.5f, t.localPosition.z);
                }
            }

            foreach (Transform t in Galaxies)
            {
                t.Translate(Vector3.down * GalaxiesSpeed * Time.deltaTime);

                if (t.localPosition.y < -13.5f)
                {
                    t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y + Space.Length * 13.5f, t.localPosition.z);
                }
            }

            foreach (Transform t in Planets)
            {
                t.Translate(Vector3.down * PlanetsSpeed * Time.deltaTime);

                if (t.localPosition.y < -13.5f)
                {
                    t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y + Space.Length * 13.5f, t.localPosition.z);
                }
            }
        }
    }
}
