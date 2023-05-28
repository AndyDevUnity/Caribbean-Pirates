using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 start, Vector3 speed)
    {
        Vector3[] points = new Vector3[50];
        _lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = start + speed * time + Physics.gravity * time * time / 2f;

            if (points[i].y < 0)
            {
                _lineRenderer.positionCount = i + 1;
                break;
            }
        }
        _lineRenderer.SetPositions(points);
    }
}
