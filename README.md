# eFacturacionColombia_V2.Firma (C#)

[![version](https://img.shields.io/badge/version-3.0-blue.svg)](#) [![build](https://img.shields.io/badge/build-passing-brightgreen.svg)](#)



**eFacturacionColombia_V2.Firma** es un módulo desarrollado en C#, que permite firmar los documentos XML (facturas, notas de crédito/débito y eventos) que se presentan a la DIAN de Colombia para el proceso de facturación electrónica (versión Validación Previa).
También permite firmar los documentos relacionados a la nómina electrónica y el documento soporte.


### Uso

La clase `FirmaElectronica` contiene un sencillo método (en tres variantes) para firmar cada uno de los documentos electrónicos; retorna un array de bytes correspondiente al documento firmado.
El método permite, de manera opcional, que se le indique el índice del nodo `UBLExtension` donde se desea generar la firma (nodo `Signature`).

```csharp

// namespace del módulo
using eFacturacionColombia_V2.Firma


// crear instancia
var firma = new FirmaElectronica
{
	RolFirmante = RolFirmante.EMISOR,
	RutaCertificado = "path/to/certificate.p12",
	ClaveCertificado = "password here"
	// también puedes optar por colocar tu certificado directamente:
	// Certificado = new X509Certificate2(BYTES_CERTIFICADO, CLAVE_CERTIFICADO)
	// útil cuando no almacenas los certificados en carpetas locales
};

// usar horario colombiano
var fecha = DateTime.Now;


// factura, variante 1:
// firmar archivo (FileInfo)
var archivoFactura = new FileInfo("path/to/unsigned-invoice.xml");
var bytesFacturaFirmada = firma.FirmarFactura(archivoFactura, fecha);
// guardar xml firmado
File.WriteAllBytes("path/to/signed-invoice.xml", bytesFacturaFirmada);


// nota de crédito, variante 2:
// firmar contenido xml (string)
var xmlNotaCredito = File.ReadAllText("path/to/unsigned-credit-note.xml");
var bytesNotaCreditoFirmada = firma.FirmarNotaCredito(xmlNotaCredito, fecha);
// guardar xml firmado
File.WriteAllBytes("path/to/signed-credit-note.xml", bytesNotaCreditoFirmada);


// nota de débito, variante 3:
// firmar array de bytes (byte[])
var bytesNotaDebito = File.ReadAllBytes("path/to/unsigned-debit-note.xml");
var bytesNotaDebitoFirmada = firma.FirmarNotaDebito(bytesNotaDebito, fecha);
// guardar xml firmado
File.WriteAllBytes("path/to/signed-debit-note.xml", bytesNotaDebitoFirmada);


// evento, variante 2:
// firmar contenido xml (string)
var xmlEvento = File.ReadAllText("path/to/unsigned-application-response.xml");
var bytesEventoFirmado = firma.FirmarEvento(bytesEventoFirmado, fecha);
// guardar xml firmado
File.WriteAllBytes("path/to/signed-application-response.xml", eventoFirmado);

```

**Nota:** Los bytes resultantes del proceso no se deben modificar antes de procesarlos con el servicio web de la DIAN porque se invalidará la firma.



### Reconocimientos

Este proyecto utiliza las siguientes librerías:

- [Microsoft.Xades](#reconocimientos) por *Microsoft France*
- [BouncyCastle.Crypto](https://www.bouncycastle.org/csharp/) por *The Legion Of The Bouncy Castle*
- [FirmaXadesNet45](https://github.com/ctt-gob-es/FirmaXadesNet45) por *el Dpto. de Nuevas Tecnologías de la Dirección General de Urbanismo del Ayto. de Cartagena*



### Autor

Miguel Huertas <contacto@miguel-huertas.net>



### Licencia

Revisar detalles en el archivo [LICENSE](LICENSE.txt).





> El autor de este proyecto, por cuestiones de tiempo, no brindará soporte para la implementación al menos que se trate de algo simple (sin estar obligado a ello).
>
> **Por otra parte, el autor de este proyecto, pone a su disposición una solución .NET de paga para todo el proceso de facturación electrónica, así como asesoría para su implementación**.