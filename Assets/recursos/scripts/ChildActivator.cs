using UnityEngine;
using System.Collections.Generic;

public class ChildActivator : MonoBehaviour
{
    // Este m�todo recibe un Transform (padre) y maneja la activaci�n de los hijos seg�n las reglas especificadas
    public void ManageActiveChildren(Transform parent)
    {
        // Lista para almacenar los hijos activos
        var activeChildren = new List<Transform>();

        // Recorre todos los hijos del Transform recibido
        foreach (Transform child in parent)
        {
            if (child.gameObject.activeSelf)
            {
                // A�ade a la lista los hijos que est�n activos
                activeChildren.Add(child);
            }
        }

        // Si hay m�s de un hijo activo
        if (activeChildren.Count > 1)
        {
            // Desactiva todos los hijos activos excepto el primero
            for (int i = 1; i < activeChildren.Count; i++)
            {
                activeChildren[i].gameObject.SetActive(false);
            }
        }
        else if (activeChildren.Count == 1) // Si hay exactamente un hijo activo
        {
            int activeIndex = activeChildren[0].GetSiblingIndex();
            int nextIndex = (activeIndex + 1) % parent.childCount;

            // Desactiva el hijo actual
            activeChildren[0].gameObject.SetActive(false);

            // Activa el siguiente hijo en la jerarqu�a
            parent.GetChild(nextIndex).gameObject.SetActive(true);
        }
        else if (parent.childCount > 0) // Si no hay hijos activos y hay hijos disponibles
        {
            // Activa el primer hijo
            parent.GetChild(0).gameObject.SetActive(true);
        }
    }
}
