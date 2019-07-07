using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using System.Linq;

public class PointerInputModule : BaseInputModule
{
    RaycastResultComparer comparer = new RaycastResultComparer();
    PointerEventData pointerData;
    List<RaycastResult> resultList;
    Vector2 viewportCenter;

    class RaycastResultComparer : EqualityComparer<RaycastResult>
        {
            public override bool Equals(RaycastResult x, RaycastResult y)
            {
                return x.gameObject == y.gameObject;
            }

            public override int GetHashCode(RaycastResult obj)
        {
                return obj.gameObject.GetHashCode();
        }
    }

    protected override void Start()
    {
        pointerData = new PointerEventData(eventSystem);
        viewportCenter = GetViewportCenter();
    }

    public override void Process()
    {
            resultList = new List<RaycastResult>();
            pointerData.Reset();
            pointerData.position = viewportCenter;
            eventSystem.RaycastAll(pointerData, resultList);
            var enterList = resultList.Except<RaycastResult>(m_RaycastResultCache, comparer);
                foreach (var r in enterList)
                {
                ExecuteEvents.Execute(r.gameObject, pointerData, ExecuteEvents.pointerEnterHandler);
                }
            var exitList = m_RaycastResultCache.Except<RaycastResult>(resultList, comparer);
                foreach (var r in exitList)
                {
                ExecuteEvents.Execute(r.gameObject, pointerData, ExecuteEvents.pointerExitHandler);
                }
            m_RaycastResultCache = resultList;
            }

            public Vector2 GetViewportCenter()
        {
            var viewportWidth = Screen.width;
            var viewportHeight = Screen.height;

            if (XRSettings.enabled)
            {
                viewportWidth = XRSettings.eyeTextureWidth;
                viewportHeight = XRSettings.eyeTextureHeight;
            }
            return new Vector2(viewportWidth * 0.5f, viewportHeight * 0.5f);
        }
    }