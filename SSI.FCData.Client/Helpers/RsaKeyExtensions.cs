using System;
using System.Security.Cryptography;
using System.Xml;
using Newtonsoft.Json;

namespace SSI.FCData.Helpers
{
    internal static class RsaKeyExtensions
    {
        #region JSON
        internal static void FromJsonString(this RSA rsa, string jsonString)
        {
            var paramsJson = JsonConvert.DeserializeObject<RsaParametersJson>(jsonString);

            var parameters = new RSAParameters
            {
                Modulus = paramsJson.Modulus != null ? Convert.FromBase64String(paramsJson.Modulus) : null,
                Exponent = paramsJson.Exponent != null ? Convert.FromBase64String(paramsJson.Exponent) : null,
                P = paramsJson.P != null ? Convert.FromBase64String(paramsJson.P) : null,
                Q = paramsJson.Q != null ? Convert.FromBase64String(paramsJson.Q) : null,
                DP = paramsJson.DP != null ? Convert.FromBase64String(paramsJson.DP) : null,
                DQ = paramsJson.DQ != null ? Convert.FromBase64String(paramsJson.DQ) : null,
                InverseQ = paramsJson.InverseQ != null ? Convert.FromBase64String(paramsJson.InverseQ) : null,
                D = paramsJson.D != null ? Convert.FromBase64String(paramsJson.D) : null
            };

            rsa.ImportParameters(parameters);
        }

        internal static string ToJsonString(this RSA rsa, bool includePrivateParameters)
        {
            var parameters = rsa.ExportParameters(includePrivateParameters);

            var parasJson = new RsaParametersJson()
            {
                Modulus = parameters.Modulus != null ? Convert.ToBase64String(parameters.Modulus) : null,
                Exponent = parameters.Exponent != null ? Convert.ToBase64String(parameters.Exponent) : null,
                P = parameters.P != null ? Convert.ToBase64String(parameters.P) : null,
                Q = parameters.Q != null ? Convert.ToBase64String(parameters.Q) : null,
                DP = parameters.DP != null ? Convert.ToBase64String(parameters.DP) : null,
                DQ = parameters.DQ != null ? Convert.ToBase64String(parameters.DQ) : null,
                InverseQ = parameters.InverseQ != null ? Convert.ToBase64String(parameters.InverseQ) : null,
                D = parameters.D != null ? Convert.ToBase64String(parameters.D) : null
            };

            return JsonConvert.SerializeObject(parasJson);
        }
        #endregion

        #region XML

        public static void FromXmlString(this RSA rsa, string xmlString)
        {
            var parameters = new RSAParameters();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            if (xmlDoc.DocumentElement != null && xmlDoc.DocumentElement.Name.Equals("RSAKeyValue"))
            {
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "Modulus": parameters.Modulus = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "Exponent": parameters.Exponent = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "P": parameters.P = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "Q": parameters.Q = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "DP": parameters.DP = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "DQ": parameters.DQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "InverseQ": parameters.InverseQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                        case "D": parameters.D = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    }
                }
            }
            else
            {
                throw new Exception("Invalid XML RSA key.");
            }

            rsa.ImportParameters(parameters);
        }

        public static string ToXmlString(this RSA rsa, bool includePrivateParameters)
        {
            var parameters = rsa.ExportParameters(includePrivateParameters);
            return $"<RSAKeyValue" +
                   $"><Modulus>{(parameters.Modulus != null ? Convert.ToBase64String(parameters.Modulus) : null)}</Modulus>" +
                   $"<Exponent>{(parameters.Exponent != null ? Convert.ToBase64String(parameters.Exponent) : null)}</Exponent>" +
                   $"<P>{(parameters.P != null ? Convert.ToBase64String(parameters.P) : null)}</P>" +
                   $"<Q>{(parameters.Q != null ? Convert.ToBase64String(parameters.Q) : null)}</Q>" +
                   $"<DP>{(parameters.DP != null ? Convert.ToBase64String(parameters.DP) : null)}</DP>" +
                   $"<DQ>{(parameters.DQ != null ? Convert.ToBase64String(parameters.DQ) : null)}</DQ>" +
                   $"<InverseQ>{(parameters.InverseQ != null ? Convert.ToBase64String(parameters.InverseQ) : null)}</InverseQ>" +
                   $"<D>{(parameters.D != null ? Convert.ToBase64String(parameters.D) : null)}</D>" +
                   $"</RSAKeyValue>";
        }

        #endregion
    }
}