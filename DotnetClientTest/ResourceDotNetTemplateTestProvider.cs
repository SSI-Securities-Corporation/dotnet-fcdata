using System;
using System.Text;

namespace DotnetClientTest
{
    public class ResourceDotNetTemplateTestProvider
    {
        private static string _resource;
        public static string ResourceText
        {
            get
            {
                if (string.IsNullOrEmpty(_resource))
                {
                    _resource = GetResource();
                }
                return _resource;
            }
            private set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        private static string GetResource()
        {
            var data = Properties.Resources.ResourceManager.GetObject("ResourceTestTemplate");
            var result = data is byte[] bytes ? Encoding.UTF8.GetString(bytes) : (string)data;
            return result;
        }
    }
}
