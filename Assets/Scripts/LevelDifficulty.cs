using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficulty : MonoBehaviour
{
    [SerializeField] private LevelSettings _levelSettings;
    [SerializeField] private CellsSpawner _cellsSpawner;
    public void Easylevel(IReadOnlyList<Sprite> sprites)
    {
        _levelSettings.EasyLevelSettings();
        _cellsSpawner.CreateLevel(sprites);
    }
    public void MediumLevel(IReadOnlyList<Sprite> sprites)
    {
        _levelSettings.MediumLevelSettings();
        _cellsSpawner.CreateLevel(sprites);
    }
    public void HardLevel(IReadOnlyList<Sprite> sprites)
    {
        _levelSettings.HardLevelSettings();
        _cellsSpawner.CreateLevel(sprites);
    }
}
