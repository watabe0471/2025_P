using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBrakeScript : MonoBehaviour
{
    public Material changedMaterial;
    [SerializeField] private GameObject G_Material;
    private Dictionary<GameObject, Material> originalMaterial = new Dictionary<GameObject, Material>();

    private void OnCollisionEnter(Collision collision)
    {
        // ボールがぶつかってきた場合のみ処理
        if (collision.gameObject.CompareTag("Ball"))
        {
            string blockTypeTag = this.gameObject.tag;  // タグ

            // 同じ種類のブロックをすべて取得
            GameObject[] sameTypeBlocks = GameObject.FindGameObjectsWithTag(blockTypeTag);

            foreach (GameObject block in sameTypeBlocks)
            {
                // Debug.Log("球が壊れない壁に当たった");
                Vector3 AnimePos = new Vector3(block.transform.position.x, block.transform.position.y, block.transform.position.z + -0.55f);
                Instantiate(G_Material, AnimePos, Quaternion.identity);



                /*Renderer rend = block.GetComponent<Renderer>();
                if (rend != null)
                {
                    if(!originalMaterial.ContainsKey(block))
                    {
                        originalMaterial[block] = rend.material;
                    }

                    rend.material = changedMaterial;
                }
                */
            }

            StartCoroutine(RestoreMaterialAfterDelay(sameTypeBlocks, 5f));
        }
    }

    private IEnumerator RestoreMaterialAfterDelay(GameObject[] blocks,float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach(GameObject block in blocks)
        {
            Renderer rend = block.GetComponent<Renderer>();
            if(rend != null && originalMaterial.ContainsKey(block))
            {
                rend.material = originalMaterial[block];
            }
        }

        foreach(GameObject block in blocks)
        {
            if (originalMaterial.ContainsKey(block))
                originalMaterial.Remove(block);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
