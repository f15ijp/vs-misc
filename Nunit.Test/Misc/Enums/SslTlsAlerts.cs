using System.ComponentModel;


namespace Examples.Misc.Enums {
	public class SslTlsAlerts {

		public enum AlertLevel {
			Warning = 1,
			Fatal = 2
		}

		/*
		 * Made with details from
		 * https://blogs.msdn.microsoft.com/kaushal/2012/10/05/ssltls-alert-protocol-the-alert-codes/
		 * https://botan.randombit.net/doxygen/classBotan_1_1TLS_1_1Alert.html
		 */
		public enum AlertDescription {
			[Description("Notifies the recipient that the sender will not send any more messages on this connection.")]
			CloseNotify = 0,
			[Description("Received an inappropriate message This alert should never be observed in communication between proper implementations. This message is always fatal.")]
			UnexpectedMessage = 10,
			[Description("Received a record with an incorrect MAC. This message is always fatal.")]
			BadRecordMac = 20,
			[Description("Decryption of a TLSCiphertext record is decrypted in an invalid way: either it was not an even multiple of the block length or its padding values, when checked, were not correct. This message is always fatal.")]
			DecryptionFailed = 21,
			[Description("Received a TLSCiphertext record which had a length more than 2^14+2048 bytes, or a record decrypted to a TLSCompressed record with more than 2^14+1024 bytes. This message is always fatal.")]
			RecordOverflow = 22,
			[Description("Received improper input, such as data that would expand to excessive length, from the decompression function. This message is always fatal.")]
			DecompressionFailure = 30,
			[Description("Indicates that the sender was unable to negotiate an acceptable set of security parameters given the options available. This is a fatal error.")]
			HandshakeFailure = 40,
			[Description("There is a problem with the certificate, for example, a certificate is corrupt, or a certificate contains signatures that cannot be verified.")]
			BadCertificate = 42,
			[Description("Received an unsupported certificate type.")]
			UnsupportedCertificate = 43,
			[Description("Received a certificate that was revoked by its signer.")]
			CertificateRevoked = 44,
			[Description("Received a certificate has expired or is not currently valid.")]
			CertificateExpired = 45,
			[Description("An unspecified issue took place while processing the certificate that made it unacceptable.")]
			CertificateUnknown = 46,
			[Description("Violated security parameters, such as a field in the handshake was out of range or inconsistent with other fields. This is always fatal.")]
			IllegalParameter = 47,
			[Description("Received a valid certificate chain or partial chain, but the certificate was not accepted because the CA certificate could not be located or could not be matched with a known, trusted CA. This message is always fatal.")]
			UnknownCa = 48,
			[Description("Received a valid certificate, but when access control was applied, the sender did not proceed with negotiation. This message is always fatal.")]
			AccessDenied = 49,
			[Description("A message could not be decoded because some field was out of the specified range or the length of the message was incorrect. This message is always fatal.")]
			DecodeError = 50,
			[Description("Failed handshake cryptographic operation, including being unable to correctly verify a signature, decrypt a key exchange, or validate a finished message.")]
			DecryptError = 51,
			[Description("Detected a negotiation that was not in compliance with export restrictions; for example, attempting to transfer a 1024 bit ephemeral RSA key for the RSA_EXPORT handshake method. This message is always fatal.")]
			ExportRestriction = 60,
			[Description("The protocol version the client attempted to negotiate is recognized, but not supported. For example, old protocol versions might be avoided for security reasons. This message is always fatal.")]
			ProtocolVersion = 70,
			[Description("Failed negotiation specifically because the server requires ciphers more secure than those supported by the client. Returned instead of handshake_failure. This message is always fatal.")]
			InsufficientSecurity = 71,
			[Description("An internal error unrelated to the peer or the correctness of the protocol makes it impossible to continue, such as a memory allocation failure. The error is not related to protocol. This message is always fatal.")]
			InternalError = 80,
			[Description("Cancelled handshake for a reason that is unrelated to a protocol failure. If the user cancels an operation after the handshake is complete, just closing the connection by sending a close_notify is more appropriate. This alert should be followed by a close_notify. This message is generally a warning.")]
			UserCancelled = 90,
			[Description("Sent by the client in response to a hello request or sent by the server in response to a client hello after initial handshaking. Either of these would normally lead to renegotiation; when that is not appropriate, the recipient should respond with this alert; at that point, the original requester can decide whether to proceed with the connection. One case where this would be appropriate would be where a server has spawned a process to satisfy a request; the process might receive security parameters (key length, authentication, and so on) at start-up and it might be difficult to communicate changes to these parameters after that point. This message is always a warning.")]
			NoRenegotiation = 100,
			UnsupportedExtension2 = 110,
			CertificateUnobtainable = 111,
			UnrecognizedName = 112,
			BadCertificateStatusResponse = 113,
			BadCertificateHashValue = 114,
			UnknownPskIdentity = 115,
			CertificateRequired = 116, // RFC 8446
			NoApplicationProtocol = 120, // RFC 7301
			UnsupportedExtension = 255,
			NullAlert = 256
		}

	}
}
