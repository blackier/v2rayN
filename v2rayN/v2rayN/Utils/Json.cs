using System.IO;
using System.Text.Json;

namespace v2rayN
{
    partial class Utils
    {
        /// <summary>
        /// 反序列化，默认不区分属性名称大小写
        /// </summary>
        public static T FromJson<T>(string strJson, bool caseInsensitive = false)
        {
            JsonSerializerOptions serializer_opts = caseInsensitive ? new JsonSerializerOptions() { PropertyNameCaseInsensitive = true } : new JsonSerializerOptions();
            T obj = JsonSerializer.Deserialize<T>(strJson, serializer_opts);
            return obj;
        }

        /// <summary>
        /// 序列化，默认保持属性名称不变，否则使用驼峰命名法。
        /// </summary>
        public static string ToJson(object obj, bool useCamelCase = false)
        {
            JsonSerializerOptions serializer_opts = useCamelCase ? new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase } : new JsonSerializerOptions();
            string result = JsonSerializer.Serialize(obj, obj.GetType(), new JsonSerializerOptions { WriteIndented = true, IgnoreNullValues = true });
            return result;
        }

        /// <summary>
        /// 保存成json文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int ToJsonFile(object obj, string filePath, bool nullValue = true, bool caseInsensitive = false)
        {
            int result;
            try
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializerOptions serializer_opts;
                    if (nullValue)
                    {
                        serializer_opts = new JsonSerializerOptions() { WriteIndented = true };
                    }
                    else
                    {
                        serializer_opts = new JsonSerializerOptions() { WriteIndented = true, IgnoreNullValues = true };
                    }
                    if (caseInsensitive)
                    {
                        serializer_opts.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    }

                    file.Write(JsonSerializer.Serialize(obj, obj.GetType(), serializer_opts));
                }
                result = 0;
            }
            catch
            {
                result = -1;
            }
            return result;
        }
    }
}
