using UnityEditor;
using UnityEngine;
using CustomMath;
public class MatrixDebugger : EditorWindow
{
	public GameObject target;
	GUIStyle style = new GUIStyle();
	[MenuItem("Window/MatrixDebugger")]
	static void Init()
	{
		MatrixDebugger window = (MatrixDebugger)EditorWindow.GetWindow(typeof(MatrixDebugger));
		window.Show();
	}

	private void OnGUI()
	{
		target = EditorGUILayout.ObjectField(target, typeof(GameObject), true) as GameObject;
		if (target != null)
		{
			target.transform.position = EditorGUILayout.Vector3Field("Position: ", target.transform.position);
			target.transform.rotation = Quaternion.Euler(EditorGUILayout.Vector3Field("Rotation: ", target.transform.rotation.eulerAngles));
			target.transform.localScale = EditorGUILayout.Vector3Field("Scale: ", target.transform.localScale);
			style.fontSize = 15;
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Translation matrix", style);
			DrawMatrix(MatrixRecargada.Translate(new Vec3 (target.transform.position)));
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Rotation matrix", style);
			DrawMatrix(MatrixRecargada.Rotate(new Quarentenion(target.transform.rotation)));
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Scale matrix", style);
			DrawMatrix(MatrixRecargada.Scale(new Vec3(target.transform.localScale)));
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("TRS matrix",style);
			DrawMatrix(MatrixRecargada.TRS(new Vec3(target.transform.position), new Quarentenion(target.transform.rotation), new Vec3(target.transform.localScale)));

		}
	}

	private void DrawMatrix(Matrix4x4 matrix)
	{
		GUIStyle style = new GUIStyle();
		style.fontSize = 20;
		EditorGUILayout.LabelField("| " + matrix.m00.ToString("00.00") + " " + matrix.m01.ToString("00.00") + " " + matrix.m02.ToString("00.00") + " " + matrix.m03.ToString("00.00") + " |", style);
		EditorGUILayout.LabelField("| " + matrix.m10.ToString("00.00") + " " + matrix.m11.ToString("00.00") + " " + matrix.m12.ToString("00.00") + " " + matrix.m13.ToString("00.00") + " |", style);
		EditorGUILayout.LabelField("| " + matrix.m20.ToString("00.00") + " " + matrix.m21.ToString("00.00") + " " + matrix.m22.ToString("00.00") + " " + matrix.m23.ToString("00.00") + " |", style);
		EditorGUILayout.LabelField("| " + matrix.m30.ToString("00.00") + " " + matrix.m31.ToString("00.00") + " " + matrix.m32.ToString("00.00") + " " + matrix.m33.ToString("00.00") + " |", style);
	}
}
