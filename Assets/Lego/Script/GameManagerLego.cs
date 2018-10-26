﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Block
{
    public Transform blockTransform;
    public BlockColor color;
}

public enum BlockColor
{
    White = 0,
    Red = 1,
    Green = 2,
    Blue = 3
}

public struct BlockAction
{
    public bool delete;
    public Vector3 index;
    public BlockColor color;
}

public class GameManagerLego : MonoBehaviour
{
    private EventSystem es;

    private float blockSize = 1.5f;

    public Block[,,] blocks = new Block[20, 20, 20];
    public GameObject blockPrefab;

    public BlockColor selectedColor;
    public Material[] blockMaterials;

    private GameObject foundationObject;
    private GameObject foundationObject2;
    private Vector3 blockOffset;
    private Vector3 foundationCenter = new Vector3(7.5f, 0, 7.5f);
    private bool isDeleting;

    private BlockAction previewAction;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        foundationObject = GameObject.Find("Foundation");
        foundationObject2 = GameObject.Find("Foundation2");
        blockOffset = (Vector3.one * (blockSize*2)) / 4;
        selectedColor = BlockColor.White;

        es = FindObjectOfType<EventSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIObject())
            {
                return;
            }

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 30.0f))
            {
                if (isDeleting)
                {
                    if (hit.transform.name != "Foundation" || hit.transform.name != "Foundation2")
                    {
                        Vector3 oldCubeIndex = BlockPosition(hit.point - (hit.normal * (blockSize - 0.01f)));
                        BlockColor previousColor = blocks[(int)oldCubeIndex.x, (int)oldCubeIndex.y, (int)oldCubeIndex.z].color;
                        Destroy(blocks[(int)oldCubeIndex.x, (int)oldCubeIndex.y, (int)oldCubeIndex.z].blockTransform.gameObject);
                        blocks[(int)oldCubeIndex.x, (int)oldCubeIndex.y, (int)oldCubeIndex.z] = null;

                        previewAction = new BlockAction()
                        {
                            delete = true,
                            index = oldCubeIndex,
                            color = previousColor
                        };
                    }
                    
                    return;
                }

                Vector3 index = BlockPosition(hit.point);

                int x = (int)index.x, y = (int)index.y, z = (int)index.z;

                if (blocks[x, y, z] == null)
                {
                    GameObject go = CreateBlock();
                    go.transform.localScale = Vector3.one * blockSize;
                    PositionBlock(go.transform, index);

                    blocks[x, y, z] = new Block
                    {
                        blockTransform = go.transform,
                        color = selectedColor
                    };

                    previewAction = new BlockAction()
                    {
                        delete = false,
                        index = new Vector3 (x,y,z),
                        color = selectedColor
                    };
                }
                else
                {
                    GameObject go = CreateBlock();
                    go.transform.localScale = Vector3.one * blockSize;

                    Vector3 newIndex = BlockPosition(hit.point + (hit.normal * blockSize));
                    blocks[(int)newIndex.x, (int)newIndex.y, (int)newIndex.z] = new Block
                    {
                        blockTransform = go.transform,
                        color = selectedColor
                    };
                    PositionBlock(go.transform, newIndex);

                    previewAction = new BlockAction()
                    {
                        delete = false,
                        index = newIndex,
                        color = selectedColor
                    };
                }
            }
        }
    }

    private GameObject CreateBlock()
    {
        GameObject go = Instantiate(blockPrefab) as GameObject;
        go.GetComponent<Renderer>().material = blockMaterials[(int)selectedColor];
        return go;
    }

    private Vector3 BlockPosition(Vector3 hit)
    {
        int x = (int)(hit.x / blockSize);
        int y = (int)(hit.y / blockSize);
        int z = (int)(hit.z / blockSize);

        return new Vector3(x, y, z);
    }

    private void PositionBlock(Transform t, Vector3 index)
    {
        t.position = ((index * blockSize) + blockOffset) + (foundationObject.transform.position - foundationCenter);
    }

    public void ChangeBlockColor(int color)
    {
        isDeleting = false;
        selectedColor = (BlockColor)color;
    }

    public void ToggleDelete()
    {
        isDeleting = !isDeleting;
    }

    public void Undo()
    {
        if (previewAction.delete)
        {
            //Spawn back
            GameObject go = CreateBlock();
            
            blocks[(int)previewAction.index.x, (int)previewAction.index.y, (int)previewAction.index.z] = new Block
            {
                blockTransform = go.transform,
                color = selectedColor
            };
            PositionBlock(go.transform, previewAction.index);

            previewAction = new BlockAction()
            {
                delete = false,
                index = previewAction.index,
                color = previewAction.color
            };
        }
        else
        {
            Destroy(blocks[(int)previewAction.index.x, (int)previewAction.index.y, (int)previewAction.index.z].blockTransform.gameObject);
            blocks[(int)previewAction.index.x, (int)previewAction.index.y, (int)previewAction.index.z] = null;

            previewAction = new BlockAction()
            {
                delete = true,
                index = previewAction.index,
                color = previewAction.color
            };
        }
    }

    public void ResetGrid()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; i < 20; j++)
            {
                for (int k = 0; i < 20; k++)
                {
                    Destroy(blocks[i, j, k].blockTransform.gameObject);
                    blocks[i, j, k] = null;
                }
            }
        }
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
