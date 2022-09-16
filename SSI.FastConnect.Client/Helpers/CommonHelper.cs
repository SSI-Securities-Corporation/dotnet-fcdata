using System;
using System.IO;
using ProtoBuf;

namespace SSI.FastConnect.Client.Helpers
{
    public class CommonHelper
    {
        public static byte[] ProtoSerialize<T>(T record)
        {
            if (null == record)
            {
                return null;
            }
            using (var stream = new MemoryStream())
            {
                try
                {
                    Serializer.Serialize(stream, record);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return stream.ToArray();
            }
        }

        public static T ProtoDeserialize<T>(byte[] data)
        {
            try
            {
                if (null == data)
                {
                    return default(T);
                }
                using (var stream = new MemoryStream(data))
                {
                    return Serializer.Deserialize<T>(stream);
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static T DeserializeObjFromByteData<T>(byte[] data, string secret, byte[] key) where T : class
        {
            try
            {
                var decrypt = CipherHelper.DecryptText(data, secret, key);
                return decrypt != null ? ProtoDeserialize<T>(decrypt) : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static byte[] AddSerialization2Obj<T>(T obj, string secret, byte[] key) where T : class
        {
            var objByte = ProtoSerialize(obj);
            var encrypted = CipherHelper.EncryptText(objByte, secret, key);
            return encrypted;
        }
    }
}