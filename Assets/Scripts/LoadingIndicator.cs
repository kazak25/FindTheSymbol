using JetBrains.Annotations;
using OpenAI;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class LoadingIndicator : MonoBehaviour
{
    [SerializeField] private Image _circleLoading;
    [SerializeField] private TextMeshProUGUI _loadingPercent;
    [SerializeField] private DallE _dalle;
    private float _percent;

    private void Start()
    {
        _circleLoading.fillAmount = 0;
        _loadingPercent.text = "0%  Loading";
        _percent = 100/_dalle.picturesCount;
    }
    [UsedImplicitly]
    public void loadingStage()
    {
        _circleLoading.fillAmount += _percent * 0.01f;
        var tempView = _circleLoading.fillAmount;
        _loadingPercent.text = tempView.ToString("P0") + " Loading";
    }
}
