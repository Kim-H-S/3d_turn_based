using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObject :MonoBehaviour
{
    public InteractableSO objectBase;

    private InteractableSO info;


    private void Awake()
    {
        info = new InteractableSO(objectBase);
    }

    private void Update()
    {
        // 테스트용 레이캐스트

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Interact();
                }
            }
        }
    }
    public void Interact()
    {
        if (info.interactionTime > 0)
        {
            Debug.Log(info.interactionTime);
            info.interactionTime -= 1;

            if (info.interactionTime <= 0) 
            {
                DropItem();
            }
        }
    }

    public void DropItem()
    {
        int index = Random.Range(0, info.dropItemLists.Count);
        Instantiate(info.dropItemLists[index], transform.position + new Vector3(0,1,0), Quaternion.identity, MapManager.Instance.CurrentMap.transform);
        Destroy(gameObject);
    }
}