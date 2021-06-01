using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using FirmaXadesNet;
using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature.Parameters;

namespace eFacturacionColombia_V2.Firma
{
    public class FirmaElectronica
    {
        public RolFirmante RolFirmante { get; set; }

        public string RutaCertificado { get; set; }

        public string ClaveCertificado { get; set; }

        public X509Certificate2 Certificado { get; set; }


        public byte[] FirmarFactura(FileInfo archivo, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarFactura(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarFactura(string xml, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarFactura(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarFactura(byte[] bytesXml, DateTime fecha, int numExtension = 2)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:Invoice/ext:UBLExtensions/ext:UBLExtension[" + numExtension + "]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }


        public byte[] FirmarNotaCredito(FileInfo archivo, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarNotaCredito(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarNotaCredito(string xml, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarNotaCredito(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarNotaCredito(byte[] bytesXml, DateTime fecha, int numExtension = 2)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:CreditNote/ext:UBLExtensions/ext:UBLExtension[" + numExtension + "]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }


        public byte[] FirmarNotaDebito(FileInfo archivo, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarNotaDebito(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarNotaDebito(string xml, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarNotaDebito(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarNotaDebito(byte[] bytesXml, DateTime fecha, int numExtension = 2)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:DebitNote/ext:UBLExtensions/ext:UBLExtension[" + numExtension + "]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }


        public byte[] FirmarEvento(FileInfo archivo, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarEvento(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarEvento(string xml, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarEvento(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarEvento(byte[] bytesXml, DateTime fecha, int numExtension = 2)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:ApplicationResponse/ext:UBLExtensions/ext:UBLExtension[" + numExtension + "]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }


        public byte[] FirmarNominaIndividual(FileInfo archivo, DateTime fecha, int numExtension = 1)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarNominaIndividual(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarNominaIndividual(string xml, DateTime fecha, int numExtension = 1)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarNominaIndividual(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarNominaIndividual(byte[] bytesXml, DateTime fecha, int numExtension = 1)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("nei", "dian:gov:co:facturaelectronica:NominaIndividual");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/nei:NominaIndividual/ext:UBLExtensions/ext:UBLExtension[" + numExtension + "]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }


        public byte[] FirmarAjusteNominaIndividual(FileInfo archivo, DateTime fecha, int numExtension = 1)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarAjusteNominaIndividual(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarAjusteNominaIndividual(string xml, DateTime fecha, int numExtension = 1)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarAjusteNominaIndividual(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarAjusteNominaIndividual(byte[] bytesXml, DateTime fecha, int numExtension = 1)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("anei", "dian:gov:co:facturaelectronica:NominaIndividualDeAjuste");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/anei:NominaIndividualDeAjuste/ext:UBLExtensions/ext:UBLExtension[" + numExtension + "]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }


        public byte[] FirmarDocumentoSoporte(FileInfo archivo, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarDocumentoSoporte(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarDocumentoSoporte(string xml, DateTime fecha, int numExtension = 2)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarDocumentoSoporte(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarDocumentoSoporte(byte[] bytesXml, DateTime fecha, int numExtension = 2)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:Invoice/ext:UBLExtensions/ext:UBLExtension[" + numExtension + "]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }


        public byte[] FirmarContenedor(FileInfo archivo, DateTime fecha, int numExtension = 1)
        {
            var bytesXml = File.ReadAllBytes(archivo.FullName);

            return FirmarContenedor(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarContenedor(string xml, DateTime fecha, int numExtension = 1)
        {
            var bytesXml = Encoding.UTF8.GetBytes(xml);

            return FirmarContenedor(bytesXml, fecha, numExtension);
        }

        public byte[] FirmarContenedor(byte[] bytesXml, DateTime fecha, int numExtension = 1)
        {
            var xpathExpression = new SignatureXPathExpression();
            xpathExpression.Namespaces.Add("fe", "urn:oasis:names:specification:ubl:schema:xsd:AttachedDocument-2");
            xpathExpression.Namespaces.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xpathExpression.Namespaces.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xpathExpression.Namespaces.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xpathExpression.Namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xpathExpression.Namespaces.Add("sts", "dian:gov:co:facturaelectronica:Structures-2-1");
            xpathExpression.Namespaces.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
            xpathExpression.Namespaces.Add("xades141", "http://uri.etsi.org/01903/v1.4.1#");
            xpathExpression.XPathExpression = "/fe:AttachedDocument/ext:UBLExtensions/ext:UBLExtension[" + numExtension + "]/ext:ExtensionContent";

            return FirmarDocumento(bytesXml, fecha, xpathExpression);
        }


        protected byte[] FirmarDocumento(byte[] bytesXml, DateTime fecha, SignatureXPathExpression xpathExpression)
        {
            var xadesService = new XadesService();

            var parametros = new SignatureParameters();
            parametros.SignatureMethod = SignatureMethod.RSAwithSHA256;
            parametros.DigestMethod = DigestMethod.SHA256;
            parametros.SigningDate = fecha;

            parametros.SignerRole = new SignerRole();
            var signerRole = (RolFirmante == RolFirmante.EMISOR ? "supplier" : "third party");
            parametros.SignerRole.ClaimedRoles.Add(signerRole);

            parametros.SignatureDestination = xpathExpression;

            parametros.SignaturePolicyInfo = new SignaturePolicyInfo();
            parametros.SignaturePolicyInfo.PolicyIdentifier = "https://facturaelectronica.dian.gov.co/politicadefirma/v2/politicadefirmav2.pdf";
            parametros.SignaturePolicyInfo.PolicyHash = "dMoMvtcG5aIzgYo0tIsSQeVJBDnUnfSOfBpxXrmor0Y=";
            parametros.SignaturePolicyInfo.PolicyDigestAlgorithm = DigestMethod.SHA256;

            parametros.SignaturePackaging = SignaturePackaging.ENVELOPED;
            parametros.DataFormat = new DataFormat { MimeType = "text/xml" };

            using (parametros.Signer = new Signer(Certificado ?? new X509Certificate2(RutaCertificado, ClaveCertificado)))
            {
                using (var stream = new MemoryStream(bytesXml))
                {
                    var signatureDocument = xadesService.Sign(stream, parametros);

                    var output = new MemoryStream();
                    signatureDocument.Save(output);

                    return output.ToArray();
                }
            }
        }
    }
}
