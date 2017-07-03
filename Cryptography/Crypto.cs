/****************************************
 * Credits to: http://www.c-sharpcorner.com/UploadFile/4088a7/using-cryptography-in-portable-xamarin-formswindows-phone/
 ****************************************/

using System;
using PCLCrypto;
using System.Text;

namespace Cryptography
{
    public static class Crypto
    {
        //private static byte[] salt = Encoding.UTF8.GetBytes("Xamarin.iOS.Cryptography.AON");
        private static byte[] salt = WinRTCrypto.CryptographicBuffer.GenerateRandom(16);
        private static string password = "P@ssw0rd";

        private static byte[] CreateDerivedKey(int keyLengthInBytes = 32, int iterations = 1000)
		{
			byte[] key = NetFxCrypto.DeriveBytes.GetBytes(password, salt, iterations, keyLengthInBytes);
			return key;
		}

        public static byte[] EncryptAes(string data)
		{
			byte[] key = CreateDerivedKey();

			ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
			ICryptographicKey symetricKey = aes.CreateSymmetricKey(key);
			var bytes = WinRTCrypto.CryptographicEngine.Encrypt(symetricKey, Encoding.UTF8.GetBytes(data));

			return bytes;
		}

		public static string DecryptAes(byte[] data)
		{
			byte[] key = CreateDerivedKey();

			ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
			ICryptographicKey symetricKey = aes.CreateSymmetricKey(key);
			var bytes = WinRTCrypto.CryptographicEngine.Decrypt(symetricKey, data);

			return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
		}
	}
}
