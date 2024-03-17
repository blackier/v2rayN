using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v2rayN;

public class I18N_zh_Hans : I18N
{

    private Dictionary<string, string> _i18nDict_zh_Hans = new() {

        {"BatchExportSubscriptionSuccessfully"
        ,"批量导出订阅内容至剪贴板成功"},

        {"BatchExportURLSuccessfully"
        ,"批量导出分享URL至剪贴板成功"},

        {"CheckServerSettings"
        ,"请先检查服务器设置"},

        {"ConfigurationFormatIncorrect"
        ,"配置格式不正确"},

        {"CustomServerTips"
        ,"注意,自定义配置完全依赖您自己的配置，不能使用所有设置功能。在自定义配置inbound中有socks port等于设置中的port时，系统代理才可用"},

        {"Downloading"
        ,"下载开始..."},

        {"downloadSpeed"
        ,"下载"},

        {"DownloadYesNo"
        ,"是否下载? {0}"},

        {"FailedConversionConfiguration"
        ,"转换配置文件失败"},

        {"FailedGenDefaultConfiguration"
        ,"生成默认配置文件失败"},

        {"FailedGetDefaultConfiguration"
        ,"取得默认配置失败"},

        {"FailedImportedCustomServer"
        ,"导入自定义配置服务器失败"},

        {"FailedReadConfiguration"
        ,"读取配置文件失败"},

        {"FillCorrectAlterId"
        ,"请填写正确格式额外ID"},

        {"FillCorrectServerPort"
        ,"请填写正确格式服务器端口"},

        {"FillKcpParameters"
        ,"请正确填写KCP参数"},

        {"FillLocalListeningPort"
        ,"请填写本地监听端口"},

        {"FillPassword"
        ,"请填写密码"},

        {"FillServerAddress"
        ,"请填写服务器地址"},

        {"FillUUID"
        ,"请填写用户ID"},

        {"IncorrectClientConfiguration"
        ,"不是正确的客户端配置文件，请检查"},

        {"Incorrectconfiguration"
        ,"不是正确的配置，请检查"},

        {"IncorrectServerConfiguration"
        ,"不是正确的服务端配置文件，请检查"},

        {"InitialConfiguration"
        ,"初始化配置"},

        {"IsLatestCore"
        ,"{0} 已是最新版本。"},

        {"IsLatestN"
        ,"{0} 已是最新版本。"},

        {"LvAddress"
        ,"地址"},

        {"LvAlias"
        ,"别名"},

        {"LvEncryptionMethod"
        ,"加密方式"},

        {"LvPort"
        ,"端口"},

        {"LvServiceType"
        ,"类型"},

        {"LvSubscription"
        ,"订阅"},

        {"LvTestResults"
        ,"测试结果"},

        {"LvTodayDownloadDataAmount"
        ,"今日下载"},

        {"LvTodayUploadDataAmount"
        ,"今日上传"},

        {"LvTotalDownloadDataAmount"
        ,"总下载"},

        {"LvTotalUploadDataAmount"
        ,"总上传"},

        {"LvTransportProtocol"
        ,"传输协议"},

        {"MediumFresh"
        ,"中等"},

        {"MsgClearSubscription"
        ,"清除原订阅内容"},

        {"MsgDownloadV2rayCoreSuccessfully"
        ,"下载V2ray成功"},

        {"MsgDownloadDomainListSuccessfully"
        ,"下载域名列表成功"},

        {"MsgReplaceDomainListSuccessfully"
        ,"替换域名列表成功"},

        {"MsgDownloadIPListSuccessfully"
        ,"下载IP列表成功"},

        {"MsgReplaceIPListSuccessfully"
        ,"替换IP列表成功"},

        {"MsgFailedImportSubscription"
        ,"导入订阅内容失败"},

        {"MsgGetSubscriptionSuccessfully"
        ,"获取订阅内容成功"},

        {"MsgNoValidSubscription"
        ,"未设置有效的订阅"},

        {"MsgPACUpdateFailed"
        ,"PAC更新失败"},

        {"MsgPACUpdateSuccessfully"
        ,"PAC更新成功"},

        {"MsgParsingSuccessfully"
        ,"解析{0}成功"},

        {"MsgSimplifyPAC"
        ,"简化PAC成功"},

        {"MsgStartGettingSubscriptions"
        ,"开始获取订阅内容"},

        {"MsgStartUpdating"
        ,"开始更新 {0}..."},

        {"MsgStartUpdatingPAC"
        ,"开始更新 PAC..."},

        {"MsgSubscriptionDecodingFailed"
        ,"订阅内容解码失败(非BASE64码)"},

        {"MsgUnpacking"
        ,"正在解压......"},

        {"MsgUpdateSubscriptionEnd"
        ,"更新订阅结束"},

        {"MsgUpdateSubscriptionStart"
        ,"更新订阅开始"},

        {"MsgUpdateV2rayCoreSuccessfully"
        ,"更新V2rayCore成功"},

        {"MsgUpdateV2rayCoreSuccessfullyMore"
        ,"更新V2rayCore成功！正在重启服务..."},

        {"NeedHttpGlobalProxy"
        ,"此功能依赖Http全局代理,请先设置正确。"},

        {"NonvmessOrssProtocol"
        ,"非vmess或ss协议"},

        {"NonVmessService"
        ,"非Vmess服务，此功能无效"},

        {"NotFoundCore"
        ,"找不到 v2ray-core，下载地址: {0}"},

        {"NoValidQRcodeFound"
        ,"扫描完成,未发现有效二维码"},

        {"OperationFailed"
        ,"操作失败，请检查重试"},

        {"PleaseFillRemarks"
        ,"请填写备注"},

        {"PleaseSelectEncryption"
        ,"请选择加密方式"},

        {"PleaseSelectProtocol"
        ,"请选择协议"},

        {"PleaseSelectServer"
        ,"请先选择服务器"},

        {"QuickFresh"
        ,"快"},

        {"RemoveDuplicateServerResult"
        ,"服务器去重完成。原数量: {0}，现数量: {1}"},

        {"RemoveServer"
        ,"是否确定移除服务器?"},

        {"SaveClientConfigurationIn"
        ,"客户端配置文件保存在:{0}"},

        {"SaveServerConfigurationIn"
        ,"服务端配置文件保存在:{0}"},

        {"SlowFresh"
        ,"慢"},

        {"SpeedServerTips"
        ,"注意：此功能依赖Http全局代理!测试完成后,请手工调整Http全局代理和活动节点。"},

        {"StartPacFailed"
        ,"PAC服务启动失败,请用管理员启动"},

        {"StartService"
        ,"启动服务({0})..."},

        {"SuccessfulConfiguration"
        ,"配置成功\n{0}"},

        {"SuccessfullyImportedCustomServer"
        ,"成功导入自定义配置服务器"},

        {"SuccessfullyImportedServerViaClipboard"
        ,"成功从剪贴板导入 {0} 个服务器"},

        {"SuccessfullyImportedServerViaScan"
        ,"扫描导入URL成功"},

        {"TestMeOutput"
        ,"当前服务的真连接延迟: {0}"}
    };

    public override string GetString(string key)
    {
        if (_i18nDict_zh_Hans.ContainsKey(key))
            return _i18nDict_zh_Hans[key];
        else
            return key;
    }
}
