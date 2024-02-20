using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ProjectileAnimator : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float frameDelay;
    [SerializeField] float startDelay;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;
        StartCoroutine(Animate());
    }

    // Update is called once per frame
    public IEnumerator Animate(){
        transform.position += offset;
        yield return new WaitForSeconds(startDelay);
        for (int i = 0; i<sprites.Length; i++){
            yield return new WaitForSeconds(frameDelay);
            spriteRenderer.sprite = sprites[i];
        }
        Destroy(gameObject);
    }
}
