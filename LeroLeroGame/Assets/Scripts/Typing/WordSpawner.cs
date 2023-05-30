using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public RectTransform boxBG;
    public Canvas wordCanvas;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public WordDisplay SpawnWord()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();

        GameObject wordObj = Instantiate(wordPrefab, spawnPosition, Quaternion.identity, wordCanvas.transform);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }

    private Vector3 GetRandomSpawnPosition()
    {
          // Get Image Size
          Vector2 imageSize = boxBG.rect.size;
          imageSize.x *= boxBG.lossyScale.x;
          imageSize.y *= boxBG.lossyScale.y;

          // Image Position
          Vector3 imageCenter = boxBG.position;

          float minX = imageCenter.x - imageSize.x * 0.5f + wordPrefab.GetComponent<RectTransform>().rect.width * 0.5f;
          float maxX = imageCenter.x + imageSize.x * 0.5f - wordPrefab.GetComponent<RectTransform>().rect.width * 0.5f;

          float spawnX = Random.Range(minX, maxX);
          float spawnY = imageCenter.y + imageSize.y * 0.5f;

          Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

          return spawnPosition;
    }
}












