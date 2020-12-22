using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public TowerBtn towerBtnPressed { get; set; }
    DataGame dataGame;

    Collider2D buildTile;
    SpriteRenderer spriteRenderer; //На префаб TowerManager в инспекторе добавили компонент Sprite Renderer

    void Start()
    {
        buildTile = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Считываем положение мыши
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero); //Луч идёт от позиции мыши к нулевой координате
            if(hit.collider.tag == "TowerSide")
            {
                buildTile = hit.collider; // Говорим что buildTile будет тем самым объектом который находит RaycastHit2D hit
                buildTile.tag = "NoTowerSide"; //Меняем тэг что бы запретить повторную установку башен на это место
            }
        }
        if (spriteRenderer.enabled)  //Если есть картинка (spriteRenderer включён), то она должна следовать за курсором.
        {
            FollowMouse();
        }
    }

    public void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Находим положение курсора
        transform.position = new Vector2(transform.position.x, transform.position.y); //Следуем за курсором
    }

    public void SelectedTower(TowerBtn towerSelected)
    {
        if (towerSelected.TowerPrice <= dataGame.TotalMoney)
        {
            towerBtnPressed = towerSelected;
            EnableDrag(towerBtnPressed.DragSprite);
        }
    }

    public void EnableDrag(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }

    public void DisableDreag()
    {
        spriteRenderer.enabled = false;
    }

    public void PlaceTower(RaycastHit2D hit)
    {

    }

}
