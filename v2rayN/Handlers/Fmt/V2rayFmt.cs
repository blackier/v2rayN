using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using v2rayN.Config;
using V2rayConfig = Shadowsocks.Interop.V2Ray.Config;

namespace v2rayN.Handlers.Fmt;

internal class V2rayFmt : BaseFmt
{
    public static List<ProfileItem>? ResolveFullArray(string strData, string? subRemarks)
    {
        var configObjects = Json.FromJson<Object[]>(strData);
        if (configObjects != null && configObjects.Length > 0)
        {
            List<ProfileItem> lstResult = [];
            foreach (var configObject in configObjects)
            {
                var objectString = Json.ToJson(configObject);
                var v2rayCon = Json.FromJson<V2rayConfig>(objectString);
                if (v2rayCon?.Inbounds?.Count > 0 && v2rayCon.Outbounds?.Count > 0 && v2rayCon.Routing != null)
                {
                    var fileName = WriteAllText(objectString);

                    var profileIt = new ProfileItem { address = fileName, remarks = "v2ray_custom", };
                    lstResult.Add(profileIt);
                }
            }
            return lstResult;
        }
        return null;
    }

    public static ProfileItem? ResolveFull(string strData, string? subRemarks)
    {
        var v2rayConfig = Json.FromJson<V2rayConfig>(strData);
        if (v2rayConfig?.Inbounds?.Count > 0 && v2rayConfig.Outbounds?.Count > 0 && v2rayConfig.Routing != null)
        {
            var fileName = WriteAllText(strData);

            var profileItem = new ProfileItem { address = fileName, remarks = "v2ray_custom" };

            return profileItem;
        }
        return null;
    }
}
