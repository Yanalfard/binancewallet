using System.Collections.Generic;

namespace Services.Api
{
    public interface ISocket
    {
        double GetTotalMoney();
        List<(string assetName, double assetAmount, double assetAmountUsdt)> GetAllAssets();
    }
}